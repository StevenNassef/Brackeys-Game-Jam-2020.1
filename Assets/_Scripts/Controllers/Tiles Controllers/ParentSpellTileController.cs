using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpellTileController : MonoBehaviour
{
    [SerializeField] private bool _isActivatingTile;

    protected ParentSpellController spellController;
    protected Material _tileMaterial;
    protected SpellType spellType;
    void Start()
    {
        spellController = GetComponentInParent<ParentSpellController>();
        _tileMaterial = GetComponent<MeshRenderer>().material;
        SetTileColor(spellController.CurrentSpell.SpellColor);
        spellType = spellController.CurrentSpell.SpellType;
        if (_isActivatingTile)
            _tileMaterial.SetTexture("Albedo", spellController.CurrentSpell.SpellActivationSymbol);
        else
            _tileMaterial.SetTexture("Albedo", spellController.CurrentSpell.SpellEffectSymbol);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void SetTileColor(Color color)
    {
        _tileMaterial.SetColor("GlowColor", color);
        _tileMaterial.SetColor("AlbedoBase", color);
    }

    protected void isGlowing(bool enable)
    {
        int input = enable ? 1 : 0;
        _tileMaterial.SetInt("EnableGlow", input);
    }

    protected void ActivateSpell(Collider player)
    {
        isGlowing(true);
    }

    protected void DeactivateSpell(Collider player)
    {
        isGlowing(false);

    }

    private void OnEnable()
    {
        if (spellController == null)
        {
            spellController = GetComponentInParent<ParentSpellController>();
        }
        spellController.OnSpellTileEnter += ActivateSpell;
        spellController.OnSpellTileExit += DeactivateSpell;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivatingTile && other.gameObject.CompareTag("Player"))
        {
            Spell currentSpell = other.GetComponent<PlayerManager>().CurrentAnkhController.CurrentAnkhSpell;

            if (currentSpell != null && currentSpell.SpellType == spellType)
            {
                spellController.SpellEnter(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isActivatingTile && other.gameObject.CompareTag("Player"))
        {
            spellController.SpellExit(other);
        }
    }
}
