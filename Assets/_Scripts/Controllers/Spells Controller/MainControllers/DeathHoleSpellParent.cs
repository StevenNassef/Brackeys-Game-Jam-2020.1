using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHoleSpellParent : ParentSpellController
{
    private static DeathHoleSpellParent _instance;
    public static DeathHoleSpellParent instance => _instance;

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
