using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Control;

public class HidingObject : MonoBehaviour
{
    public Material _transparent;

    private Material _original;

    public GameObject player;
    private PlayerControllerEngine playerControllerEngine;
    private Renderer rend;
 
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        playerControllerEngine = player.GetComponent<PlayerControllerEngine>();
        rend = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if ((transform.position - Camera.main.transform.position).sqrMagnitude < playerControllerEngine.GetDistanceFromScreen())
        {
            _original = rend.material;
            rend.material = _transparent;
        }
        else
        {
            rend.material = _original;
        }
    }
 
}

