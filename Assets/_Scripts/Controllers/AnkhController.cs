using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnkhController : MonoBehaviour
{
    [SerializeField] private GameObject gemGFX;
    [ColorUsage(true, true)] [SerializeField] private Color currentColor;
    private Material gemMaterial;
    [SerializeField] private Spell _currentAnkhSpell;
    [SerializeField] private List<Spell> spells;
    public Spell CurrentAnkhSpell => _currentAnkhSpell;

    void Start()
    {
        gemMaterial = gemGFX.GetComponent<MeshRenderer>().material;
        if (_currentAnkhSpell != null)
        {
            SetAnkhSpell(_currentAnkhSpell);
        }
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        //Code here for Editor only.
        SwitchSpells();
#endif
    }

    private void SwitchSpells()
    {
        int selectedSpell = 100;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSpell = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSpell = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSpell = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSpell = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSpell = 4;
        }

        if (spells.Count > selectedSpell)
        {
            SetAnkhSpell(spells[selectedSpell]);
        }
    }


    public void SetAnkhSpell(Spell newSpell)
    {
        if (newSpell == null)
        {
            SetAnkhColor(Color.black);
            isGlowing(false);
        }
        else
        {
            isGlowing(true);
            SetAnkhColor(newSpell.SpellColor);
            _currentAnkhSpell = newSpell;
        }
    }

    public void SetAnkhColor(Color color)
    {
        gemMaterial.SetColor("GlowColor", color);
        gemMaterial.SetColor("AlbedoBase", color);
    }

    public void isGlowing(bool enable)
    {
        int input = enable ? 1 : 0;
        gemMaterial.SetInt("EnableGlow", input);
    }
}
