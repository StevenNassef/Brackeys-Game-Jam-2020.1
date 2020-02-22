using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateSpellObjectsController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float rotationIncrements;
    [SerializeField] private Vector3 rotationAxis;
    private Vector3 initialRotation;
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void TriggerMovement()
    {
        initialRotation += rotationAxis * rotationIncrements;
    }

    private void move()
    {
        if((transform.eulerAngles - initialRotation).sqrMagnitude > 5f)
        {
            transform.Rotate(rotationAxis, speed * Time.deltaTime, Space.World);
        }
        else
        {
            initialRotation = transform.eulerAngles;
        }
    }
}
