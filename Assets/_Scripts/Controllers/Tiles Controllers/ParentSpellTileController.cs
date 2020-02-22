using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class ParentSpellTileController : MonoBehaviour
{
    [SerializeField] private GameObject _GFX;
    [SerializeField] private bool _isActivatingTile;
    [SerializeField] private bool _isEffectTile;

    [Space(20)]
    [Separator("Spell Type")]
    [SerializeField] protected SpellType spellType;
    [ConditionalField(nameof(spellType), false, SpellType.Telekinesis)] [SerializeField] private TelekanisisCubeController telekanisisCubeController;
    [ConditionalField(nameof(spellType), false, SpellType.Manipulator)] [SerializeField] private ManipulateSpellObjectsController manipulateSpellObjectsController;
    [ConditionalField(nameof(spellType), false, SpellType.Creator)] [SerializeField] private CreatorSpellCubeController creatorSpellCubeController;
    [ConditionalField(nameof(spellType), false, SpellType.Soul_Shifter)] [SerializeField] private InvisiblitySpellLogicController invisiblitySpellLogicController;


    private SpellLogicController currentSpellLogic;


    // public UnityEvent MouseDown;
    // public UnityEvent MouseDrag;
    // public UnityEvent MouseUp;
    public delegate void OnSpellTileEvent();
    // public event OnSpellTileEvent MouseDown;
    // public event OnSpellTileEvent MouseUp;
    // public event OnSpellTileEvent MouseDrag;


    protected ParentSpellController spellController;
    protected Material _tileMaterial;
    void Start()
    {
        // spellController = GetComponentInParent<ParentSpellController>();
        SelectSpell();
        _tileMaterial = _GFX.GetComponent<MeshRenderer>().material;
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
    private void SelectSpell()
    {
        if (spellController != null)
        {
            spellController.OnSpellTileEnter -= ActivateSpell;
            spellController.OnSpellTileExit -= DeactivateSpell;
        }

        if (_isEffectTile)
        {
            switch (spellType)
            {
                case SpellType.Creator:
                    // print("creator");
                    // print(CreatorSpellParent.instance);
                    currentSpellLogic = creatorSpellCubeController;
                    spellController = CreatorSpellParent.instance;
                    break;
                case SpellType.Death_Hole:
                    spellController = DeathHoleSpellParent.instance;
                    break;
                case SpellType.Manipulator:
                    currentSpellLogic = manipulateSpellObjectsController;
                    spellController = ManipulatorSpellParent.instance;
                    break;
                case SpellType.Soul_Shifter:
                    currentSpellLogic = invisiblitySpellLogicController;
                    spellController = InvisiblitySpellParent.instance;
                    break;
                case SpellType.Telekinesis:
                    currentSpellLogic = telekanisisCubeController;
                    spellController = TelekanisisSpellParent.instance;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (spellType)
            {
                case SpellType.Creator:
                    // print("creator");
                    // print(CreatorSpellParent.instance);
                    spellController = CreatorSpellParent.instance;
                    break;
                case SpellType.Death_Hole:
                    spellController = DeathHoleSpellParent.instance;
                    break;
                case SpellType.Manipulator:
                    spellController = ManipulatorSpellParent.instance;
                    break;
                case SpellType.Soul_Shifter:
                    spellController = InvisiblitySpellParent.instance;
                    break;
                case SpellType.Telekinesis:
                    spellController = TelekanisisSpellParent.instance;
                    break;
                default:
                    break;
            }
        }

        spellController.OnSpellTileEnter += ActivateSpell;
        spellController.OnSpellTileExit += DeactivateSpell;
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

    private void OnMouseDown()
    {
        if (spellController.SpellActivated && _isEffectTile)
        {
            Debug.Log("Spell Activated");
            currentSpellLogic.SpellTileMouseDown();
            PlayerManager.instance.TriggerSpellAnimation();
        }
    }
    private void OnMouseUp()
    {
        if (spellController.SpellActivated && _isEffectTile)
        {
            Debug.Log("Spell Activated");
            currentSpellLogic.SpellTileMouseUp();
        }
    }
    private void OnMouseDrag()
    {
        if (spellController.SpellActivated && _isEffectTile)
        {
            // Debug.Log("Spell Activated");
            currentSpellLogic.SpellTileMouseDrag();
        }
    }

    private void OnDisable()
    {
        if (spellController == null)
        {
            SelectSpell();
        }
    }

    private void OnEnable()
    {
        if (spellController == null)
        {
            SelectSpell();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivatingTile && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("InvisiblePlayer")))
        {
            Spell currentSpell = PlayerManager.instance.CurrentAnkhController.CurrentAnkhSpell;

            if (currentSpell != null && currentSpell.SpellType == spellType)
            {
                spellController.SpellEnter(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isActivatingTile && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("InvisiblePlayer")))
        {
            Spell currentSpell = PlayerManager.instance.CurrentAnkhController.CurrentAnkhSpell;

            if (currentSpell != null && currentSpell.SpellType == spellType)
            {
                spellController.SpellExit(other);
            }
        }
    }
}
