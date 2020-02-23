using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorSpellCubeController : SpellLogicController
{
    [SerializeField] private MoveToTarget moveToTargetScript;
    [SerializeField] private GameObject _HoleGFX;

    public override void SpellTileMouseDown()
    {
        moveToTargetScript.enabled = true;
        _HoleGFX.SetActive(true);
    }
}
