using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public Texture brokenTexture;
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
            float distanceTravelled = Mathf.Abs(initVerticalPosition - transform.position.y);
            if(distanceTravelled < fallingDistance) {
                transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            } else {
                // TODO Finalize Destroying maybe by pooling
                destroyed = true;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player") {
            DestroyTile();
        }
    }

    private void DestroyTile() {
        broken = true;
        GetComponent<Collider>().enabled = false;
        //GetComponent<Renderer>().material.mainTexture = brokenTexture;
        
        // TODO change texture and do animation maybe
    }
}
