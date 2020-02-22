using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorSpellCubeController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    void Start()
    {
        
    }
    void Update()
    {
        MoveCube();   
    }

    private void MoveCube()
    {
        Vector3 direction = target.localPosition - transform.localPosition;
        
        if(direction.sqrMagnitude > 0.1f)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = target.position;
        }
    }
}
