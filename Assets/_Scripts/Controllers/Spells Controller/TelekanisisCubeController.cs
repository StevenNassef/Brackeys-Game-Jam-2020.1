using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekanisisCubeController : SpellLogicController
{
    [SerializeField] GameObject dummyCube;
    [SerializeField] TelekanisiDummyCube dummyCubeController;
    [SerializeField] GameObject holeGFX;
    void Start()
    {
        dummyCubeController = dummyCube.GetComponent<TelekanisiDummyCube>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SpellTileMouseUp()
    {
        if(dummyCubeController.isSafe)
        {
            transform.position = dummyCube.transform.position;
            holeGFX.SetActive(true);
        }
        dummyCube.SetActive(false);
        dummyCube.transform.position = transform.position;
    }

    public override  void SpellTileMouseDown()
    {
        dummyCube.SetActive(true);
    }

}
