// Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        private FieldOfView fov;
        public GameObject target;
        private bool targetDetected = false;
        public float speedFactorChange = 2.0f;
        void Start () {
            agent = GetComponent<NavMeshAgent>();
            fov = GetComponent<FieldOfView>();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = true;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        void OnCollisionEnter(Collision other) {
            //Debug.Log("Gameover!");
            // Checking if the collision occurs with layer 11(Player) then gameover
            if(other.gameObject.layer == 11) {
                // Call Gameover Logic
                Debug.Log("Gameover!");
            }
        }
        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if(fov.FindVisibleTarget()){
                agent.destination = target.transform.position;
                if(!targetDetected){
                    agent.speed = agent.speed * speedFactorChange;
                    targetDetected = true;
                }
            }
            else if (!agent.pathPending && agent.remainingDistance < 1f) {
                if(targetDetected) {
                    agent.speed = agent.speed / speedFactorChange;
                    targetDetected = false;
                }
                GotoNextPoint();
            }
        }
    }