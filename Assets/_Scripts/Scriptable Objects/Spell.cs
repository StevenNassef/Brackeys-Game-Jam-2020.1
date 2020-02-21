using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/New Spell")]
[System.Serializable]
public class Spell : ScriptableObject
{
    [SerializeField] private SpellType _spellType;
    [ColorUsage(true, true)] [SerializeField] private Color _spellColor;
    [SerializeField] private Texture _spellActivationSymbol;
    [SerializeField] private Texture _spellEffectSymbol;

    public SpellType SpellType => _spellType;
    public Color SpellColor => _spellColor;
    public Texture SpellActivationSymbol => _spellActivationSymbol;
    public Texture SpellEffectSymbol => _spellEffectSymbol;

}

public enum SpellType
{
    Death_Hole, Telekinesis, Creator, Manipulator, Soul_Shifter
}
