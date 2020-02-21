using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Spells/New Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] private Spells _spellName;
    [ColorUsage(true, true)] [SerializeField] private Color _spellColor;
    [SerializeField] private Sprite _spellSymbol;

    public Spells SpellName() => _spellName;
    public Color SpellColor() => _spellColor;
    public Sprite SpellSymbol() => _spellSymbol;

}

public enum Spells
{
    Death_Hole,Telekinesis,Creator,Manipulator,Soul_Shifter
}
