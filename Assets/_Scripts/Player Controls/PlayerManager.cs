using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Control;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private AnkhController _ankhController;
    [SerializeField] private PlayerControllerEngine _playerController;
    
    private static PlayerManager _instance;
    public static PlayerManager instance => _instance;
    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }


    public AnkhController CurrentAnkhController => _ankhController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
