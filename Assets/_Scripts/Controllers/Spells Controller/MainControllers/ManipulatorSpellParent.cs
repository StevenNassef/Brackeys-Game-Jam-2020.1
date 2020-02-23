using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorSpellParent : ParentSpellController
{
    private static ManipulatorSpellParent _instance;
    public static ManipulatorSpellParent instance => _instance;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
