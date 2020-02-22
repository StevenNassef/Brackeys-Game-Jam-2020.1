using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingTile : MonoBehaviour
{

    public float breakingSpeed = 10.0f;
    public float breakingTime = 1.0f;
    // TODO use breakingTime

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
{
            GameObject brokenPiece = transform.GetChild(i).gameObject;
            // brokenPiece.GetComponent<Rigidbody>()
            //         .AddExplosionForce(breakingForce,
            //                         brokenPiece.transform.position,
            //                         breakingRadius);

            float direction = -1.0f;
            if(Random.Range(0,1) > 0.5) {
                direction = 1.0f;
            } 
            brokenPiece.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * breakingSpeed*direction);
            Debug.Log("Breaking force at " + i);
        }
    }
}
