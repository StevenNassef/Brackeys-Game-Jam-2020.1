using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateSpellObjectsController : SpellLogicController
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationIncrements;
    [SerializeField] private Vector3 rotationAxis;
    private Vector3 initialRotation;
    private Quaternion initialRotationQuat;
    void Start()
    {
        initialRotation = transform.eulerAngles;
        initialRotationQuat = transform.localRotation;

        //Debug.Log(initialRotation);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public override void SpellTileMouseUp()
    {
        TriggerMovement();
    }
    private void TriggerMovement()
    {
        PlayerManager.instance.soundManage.playCubeSound();
        initialRotationQuat = Quaternion.AngleAxis(rotationIncrements, rotationAxis) * transform.rotation;
    }

    private void move()
    {
        // Debug.Log(transform.eulerAngles);
        // if ((transform.eulerAngles - initialRotation).sqrMagnitude > 10f)
        // {
        //     transform.Rotate(rotationAxis, speed * Time.deltaTime, Space.World);
        // }
        // else
        // {
        //     transform.eulerAngles = initialRotation;
        // }
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotationQuat, Time.deltaTime * speed);
    }
}
