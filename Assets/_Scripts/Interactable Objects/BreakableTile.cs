using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public GameObject brokenTile;
    public float fallingDistance = 1;
    public float fallingSpeed = 1;
 
    private bool broken;
    private bool destroyed;
    private float initVerticalPosition;

    private void Start() {
        initVerticalPosition = transform.position.y;
    }
 

    private void Update() {
        if(broken) {
            GameObject brokenGameObject = Instantiate(brokenTile, transform.position, transform.rotation);

            // transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            // transform.position =new Vector3(
            //     transform.position.x,
            //     transform.position.y + fallingDistance,
            //     transform.position.z);
            // Rigidbody rb = GetComponent<Rigidbody>();
            // rb.useGravity = true;
            // if (rb == null) {
            //     Debug.Log("RB not found");
            // }
            Debug.Log("get broken tile");
            // broken = false;
            Destroy(gameObject);

            broken = false;

            // float distanceTravelled = Mathf.Abs(initVerticalPosition - transform.position.y);
            // if(distanceTravelled < fallingDistance) {
            //     transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            // } else {
            //     FinalizeDestroyingTile();
            //     // TODO Finalize Destroying maybe by pooling
            //     destroyed = true;
            // }
        }
    }

    private void FinalizeDestroyingTile() {
        
        
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player") {
            DestroyTile();
        }
        Debug.Log("Check");
    }

    private void DestroyTile() {
        broken = true;
        GetComponent<Collider>().enabled = false;
        //GetComponent<Renderer>().material.mainTexture = brokenTexture;
        
        // TODO change texture and do animation maybe
    }
}
