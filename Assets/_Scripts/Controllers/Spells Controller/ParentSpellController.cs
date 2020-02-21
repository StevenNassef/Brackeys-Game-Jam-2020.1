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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpellEnter(Collider player)
    {
        if (OnSpellTileEnter != null)
        {
            OnSpellTileEnter.Invoke(player);
        }
    }

    public void SpellExit(Collider player)
    {
        if (OnSpellTileExit != null)
        {
            OnSpellTileExit.Invoke(player);
        }
    }





}
