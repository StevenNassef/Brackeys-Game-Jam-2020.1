using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblitySpellParent : ParentSpellController
{
    private static InvisiblitySpellParent _instance;
    public static InvisiblitySpellParent instance => _instance;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
