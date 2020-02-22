using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteoObject : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private ColorWheelManager colorWheelManager;
    // Start is called before the first frame update
    void Start()
    {
        colorWheelManager = FindObjectOfType<ColorWheelManager>();
        if(colorWheelManager != null) {
            Debug.Log("Color Wheel Manager registered");
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.tag == PLAYER_TAG) {
            colorWheelManager.canActivate = true;
            Debug.Log("Activate WheelManager");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == PLAYER_TAG) {
            colorWheelManager.canActivate = false;
            Debug.Log("Deactivate WheelManager");
        }    
    }

}

