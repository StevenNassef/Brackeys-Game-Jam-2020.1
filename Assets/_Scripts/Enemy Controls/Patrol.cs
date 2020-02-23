// Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;
    using System;

    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        private FieldOfView fov;
        public GameObject target;
        private bool targetDetected = false;
        public float speedFactorChange = 2.0f;
        public float deltaHeightThereshold = 0.5f;

        public GameObject soundObject;
        void Start () {
            agent = GetComponent<NavMeshAgent>();
            fov = GetComponent<FieldOfView>();
            GetComponent<Animator>().SetBool("IsIdle", true);
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = true;

            soundObject.GetComponent<GeneralSounds>().playZombieSound();

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0 || (points.Length == 1 && (points[0].transform.position -transform.position).magnitude < 0.5f)){
                GetComponent<Animator>().SetBool("IsIdle", true);
                return;
            }
            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;
            GetComponent<Animator>().SetBool("IsIdle", false);
            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        void OnTriggerEnter(Collider other) {
            // Checking if the collision occurs by comparing with the Player tag
            float deltaHeight = Math.Abs(other.transform.position.z - transform.position.z);
            Debug.Log(deltaHeight < deltaHeightThereshold);
            if(other.gameObject.CompareTag("Player") && deltaHeight < deltaHeightThereshold) {
                // Call Gameover Logic
                Debug.Log("Gameover!");
                GetComponent<Animator>().SetBool("IsAttack", true);
            }
        }

        void OnCollisionEnter(Collision other) {
            Debug.Log("dss");
            // Checking if the collision occurs by comparing with the Player tag
            float deltaHeight = Math.Abs(other.transform.position.y - transform.position.y);
            if(other.gameObject.CompareTag("Player") && deltaHeight < deltaHeightThereshold) {
                // Call Gameover Logic
                Debug.Log("Gameover!");
                GetComponent<Animator>().SetBool("IsAttack", true);
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
                GetComponent<Animator>().SetBool("IsIdle", false);
            }
            else if (!agent.pathPending && agent.remainingDistance < 1f) {
                if(targetDetected) {
                    agent.speed = agent.speed / speedFactorChange;
                    targetDetected = false;
                }
                GetComponent<Animator>().SetBool("IsAttack", false);
                GotoNextPoint();
            }
        }
    }