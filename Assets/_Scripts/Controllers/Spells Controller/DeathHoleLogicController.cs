using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHoleLogicController : SpellLogicController
{
    [SerializeField] private GameObject HolePrefab;
    private DeathHoleSpellParent parent;
    private bool mouseLock;
    private Camera mainCamera;
    [SerializeField] private LayerMask mask;
    void Start()
    {
        parent = DeathHoleSpellParent.instance;
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if(parent.SpellActivated)
        {
            SpawnHoles();
        }
    }

    private void SpawnHoles()
    {
        if(Input.GetMouseButtonDown(0) && !mouseLock)
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition),out hit, 50f, mask, QueryTriggerInteraction.Ignore))
            {
                Instantiate(HolePrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
