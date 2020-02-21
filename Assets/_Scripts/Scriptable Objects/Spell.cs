using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/New Spell")]
[System.Serializable]
public class Spell : ScriptableObject
{
    [SerializeField] private SpellType _spellType;
    [ColorUsage(true, true)] [SerializeField] private Color _spellColor;
    [SerializeField] private Sprite _spellActivationSymbol;
    [SerializeField] private Sprite _spellEffectSymbol;

    public SpellType SpellType => _spellType;
    public Color SpellColor => _spellColor;
    public Sprite SpellActivationSymbol => _spellActivationSymbol;
    public Sprite SpellEffectSymbol => _spellEffectSymbol;

}

public enum SpellType
{
    Death_Hole, Telekinesis, Creator, Manipulator, Soul_Shifter
}
