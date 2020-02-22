using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblitySpellLogicController : SpellLogicController
{
    // Start is called before the first frame update
    [SerializeField] private float invisibleTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SpellTileMouseUp()
    {
        StopAllCoroutines();
        StartCoroutine(DoThingsOverTimeInternal());
    }
    private void ToggleInvisibleMode(bool enable)
    {
        if (enable)
        {
            PlayerManager.instance.gameObject.tag = "InvisiblePlayer";
            PlayerManager.instance.sheildGFX.SetActive(true);
        }
        else
        {
            PlayerManager.instance.gameObject.tag = "Player";
            PlayerManager.instance.sheildGFX.SetActive(false);
        }
    }
    private IEnumerator DoThingsOverTimeInternal()
    {
        ToggleInvisibleMode(true);
        yield return new WaitForSeconds(invisibleTimer);
        ToggleInvisibleMode(false);
    }
}
