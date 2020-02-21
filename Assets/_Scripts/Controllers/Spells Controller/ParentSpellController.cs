using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpellController : MonoBehaviour
{
    [SerializeField] protected Spell _currentSpell;
    public Spell CurrentSpell => _currentSpell;
    public delegate void OnSpellEvent(Collider player);
    public event OnSpellEvent OnSpellTileEnter;
    public event OnSpellEvent OnSpellTileExit;
    private bool _spellActivated;
    public bool SpellActivated => _spellActivated;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpellEnter(Collider player)
    {
        if (OnSpellTileEnter != null && !SpellActivated)
        {
            _spellActivated = true;
            OnSpellTileEnter.Invoke(player);
        }
    }

    public void SpellExit(Collider player)
    {
        if (OnSpellTileExit != null && SpellActivated)
        {
            _spellActivated = true;
            OnSpellTileExit.Invoke(player);
        }
    }





}
