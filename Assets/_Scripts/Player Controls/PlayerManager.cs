using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Control;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private AnkhController _ankhController;
    [SerializeField] private PlayerControllerEngine _playerController;

    public AnkhController CurrentAnkhController =>_ankhController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
