using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHider : MonoBehaviour
{
    public Transform WatchTarget;
    public LayerMask OccluderMask;
    //This is the material with the Transparent/Diffuse With Shadow shader
    public Material HiderMaterial;

    private Dictionary<Transform, Material> _LastTransforms;

    void Start () {
        _LastTransforms = new Dictionary<Transform, Material>();
    }

    void Update () {
        //reset and clear all the previous objects
        if(_LastTransforms.Count > 0){
            foreach(Transform t in _LastTransforms.Keys){
                t.GetComponent<Renderer>().material = _LastTransforms[t];
            }
            _LastTransforms.Clear();
        }

        //Cast a ray from this object's transform the the watch target's transform.
        RaycastHit[] hits = Physics.RaycastAll(
            transform.position,
            WatchTarget.transform.position - transform.position,
            Vector3.Distance(WatchTarget.transform.position, transform.position),
            OccluderMask
            );

        // Debug.DrawRay(
        //     transform.position,
        //     WatchTarget.transform.position - transform.position,
        //     Color.blue,
        //     OccluderMask
        // );

        //Loop through all overlapping objects and disable their mesh renderer
        if(hits.Length > 0){
            foreach(RaycastHit hit in hits){
                Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();
                Debug.Log("gameobject = " + hit.collider.gameObject.name);
                if(hit.collider.gameObject.transform != WatchTarget && hit.collider.transform.root != WatchTarget){
                    _LastTransforms.Add(hit.collider.gameObject.transform, renderer.material);
                    renderer.material = HiderMaterial;
                }

                // Transform parent = hit.collider.gameObject.transform.parent;

                // for (int i = 0; i < parent.childCount; i++)
                // {
                //     Renderer renderer = parent.GetChild(i).gameObject.GetComponent<Renderer>();
                //     if(hit.collider.gameObject.transform != WatchTarget && hit.collider.transform.root != WatchTarget){
                //     _LastTransforms.Add(hit.collider.gameObject.transform, renderer.material);
                //     renderer.material = HiderMaterial;
                //     }
                // }
            }
        }
    }
}
