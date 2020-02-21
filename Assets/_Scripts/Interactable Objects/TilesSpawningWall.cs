using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSpawningWall : MonoBehaviour
{    
    public enum MovementAxis {
        XAxis,YAxis,ZAxis
    }
    public enum MovementDirection {
        Going = 1, Coming = -1
    }

    public FloatingTile floatingTile;

    public float tilesTranslationSpeed = 0.0f;
    public MovementAxis movementAxis = MovementAxis.ZAxis;
    public MovementDirection movementDirection = MovementDirection.Going;
    private Vector3 axisNormVector;
    public GameObject invisibleFrontend;
    public float frontendAwayDistance;

    [ExecuteInEditMode]
    void Start()
    {
        switch(movementAxis) {
            case MovementAxis.XAxis:
                axisNormVector = Vector3.right;
                break;
            case MovementAxis.YAxis:
                axisNormVector = Vector3.up;
                break;
            case MovementAxis.ZAxis:
                axisNormVector = Vector3.forward;
                break;
        }

        if(invisibleFrontend != null) {
            invisibleFrontend.transform.position = transform.position +
                axisNormVector*frontendAwayDistance*(int)movementDirection;
        }

    }

    void Update()
    {
        floatingTile.gameObject.transform.Translate(
            axisNormVector*Time.deltaTime*tilesTranslationSpeed*(int)movementDirection);
    }

    public void ChangeDirection() {
        movementDirection = (MovementDirection) ((int)movementDirection*-1);
    }

}
