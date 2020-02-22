using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorSpellCubeController : SpellLogicController
{
    [SerializeField] private MoveToTarget moveToTargetScript;

    public override void SpellTileMouseDown()
    {
        moveToTargetScript.enabled = true;
    }
}
