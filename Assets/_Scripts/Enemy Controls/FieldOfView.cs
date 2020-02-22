using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    private bool currentlyDetected = false;
    public float radiusIncreaseFactor = 2.0f;

    private float changingViewAngle;

    void Start() {
        changingViewAngle = viewAngle;
    }

    public float GetChangingViewAngle() {
        return changingViewAngle;
    }
    public bool FindVisibleTarget()
    {
        Collider[] targetInView = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targetInView.Length > 0)
        {
            Transform target_transform = targetInView[0].transform;
            Vector3 dirToTarget = (target_transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < changingViewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target_transform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    if(!currentlyDetected){
                        viewRadius = radiusIncreaseFactor * viewRadius;
                        currentlyDetected = true;
                        changingViewAngle = 360.0f;
                    }
                    return true;    
                }
            }
        }
        if(currentlyDetected) {
            currentlyDetected = false;
            viewRadius = viewRadius / radiusIncreaseFactor;
            changingViewAngle = viewAngle;
        }
        return false;
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
