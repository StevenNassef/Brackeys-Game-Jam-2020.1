using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
namespace Player.Control
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	[ExecuteInEditMode]
    public class PlayerControllerEngine : MonoBehaviour
    {
        [SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[Space(10)]
		[Separator("Jumping")]
		[SerializeField] float m_JumpPower = 12f;
		[Tooltip("How much the player will move in the direction of the jump")]
		[SerializeField] float m_HorizontalJumpSpeedModifier = 1;
		[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
		[Space(10)]
		[Separator("Animation")]
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[Space(10)]
		[Separator("Advanced")]
		[SerializeField] float m_GroundCheckDistance = 0.1f;
		[SerializeField] float essentialRotationAngleInYAxis = 45.0f;
		[SerializeField] float raycastCheckGroundOffset = 0.05f;

		Rigidbody m_Rigidbody;
		Animator m_Animator;
		bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;

		private Quaternion essentialRotation;
		private float sqrDistanceFromScreen;

		void Start()
		{
			m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;

			essentialRotation = Quaternion.Euler(0, essentialRotationAngleInYAxis, 0);

		}

		private void Update () {
			sqrDistanceFromScreen = (transform.position - Camera.main.transform.position).sqrMagnitude;
		}
	
		public float GetDistanceFromScreen()
		{
			return sqrDistanceFromScreen; 
		}

		public void Move(Vector3 move, bool jump)
		{

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (move.magnitude > 1f) move.Normalize();
			
			move = transform.InverseTransformDirection(move);
			move = essentialRotation*move;

			CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, m_GroundNormal);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;

			ApplyExtraTurnRotation();

			// control and velocity handling is different when grounded and airborne:
			if (m_IsGrounded)
			{
				HandleGroundedMovement(jump);
			}
			else
			{
				HandleAirborneMovement();
			}

			// send input and other state parameters to the animator
			UpdateAnimator(move);
			Debug.DrawRay(transform.position, move * 2f, Color.green, 0.1f);
		}

		void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.08f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool("OnGround", m_IsGrounded);
			if (!m_IsGrounded)
			{
				m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
			}

			// calculate which leg is behind, so as to leave that leg trailing in the jump animation
			// (This code is reliant on the specific run cycle offset in our animations,
			// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
			float runCycle =
				Mathf.Repeat(
					m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
			if (m_IsGrounded)
			{
				m_Animator.SetFloat("JumpLeg", jumpLeg);
			}

			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (m_IsGrounded && move.magnitude > 0)
			{
				m_Animator.speed = m_AnimSpeedMultiplier;
			}
			else
			{
				// don't use that while airborne
				m_Animator.speed = 1;
			}
		}


		void HandleAirborneMovement()
		{
			//If aircontrol enabled

			// apply extra gravity from multiplier:
			Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
			m_Rigidbody.AddForce(extraGravityForce);

			m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
		}


		void HandleGroundedMovement(bool jump)
		{
			// check whether conditions are right to allow a jump:
			if (jump && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
			{
				// jump!
				Vector3 jumpDirection = new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z);
				jumpDirection.Normalize();
				jumpDirection *= m_HorizontalJumpSpeedModifier;
				jumpDirection *= m_ForwardAmount;
				jumpDirection.y = m_JumpPower;
				m_Rigidbody.velocity = jumpDirection;
				m_IsGrounded = false;
				m_Animator.applyRootMotion = false;
				m_GroundCheckDistance = 0.1f;
			}
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (m_IsGrounded && Time.deltaTime > 0)
			{
				Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

				// we preserve the existing y part of the current velocity.
				v.y = m_Rigidbody.velocity.y;
				m_Rigidbody.velocity = v;
			}
		}

		[ExecuteInEditMode]
		void CheckGroundStatus()
		{
			// Debug.DrawLine(new Vector3(200,200,200), Vector3.zero, Color.green, 2, false);
			RaycastHit hitInfo;
// #if UNITY_EDITOR

// 			// helper to visualise the ground check ray in the scene view
// 			Debug.DrawRay((transform.position + (Vector3.up * raycastCheckGroundOffset))*essentialRotationAngleInYAxis,
// 						(transform.position +
// 						(Vector3.up * raycastCheckGroundOffset) +
// 						(Vector3.down * m_GroundCheckDistance))*essentialRotationAngleInYAxis,
// 						Color.green, 2, true);

// #endif
			Vector3 startVector = (transform.position + (Vector3.up * raycastCheckGroundOffset));
			// Debug.Log("StartVector " + startVector);

			Vector3 endVector = (transform.position +
								(Vector3.up * raycastCheckGroundOffset) +
								(Vector3.down * m_GroundCheckDistance));
			// Debug.Log("EndVector " + startVector);

			// Debug.DrawRay(startVector,
			// 	endVector,
			// 	Color.green, 2, true);

			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(startVector, Vector3.down,
				 out hitInfo, m_GroundCheckDistance))
			{
				m_GroundNormal = hitInfo.normal;
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
			}
			else
			{
				m_IsGrounded = false;
				m_GroundNormal = Vector3.up;
				m_Animator.applyRootMotion = false;
			}
		}
	}
}
