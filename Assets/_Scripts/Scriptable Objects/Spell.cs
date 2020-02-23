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
    [SerializeField] [TextArea] private string _description;
    [SerializeField] private Sprite symbolSprite;
    public SpellType SpellType => _spellType;
    public Color SpellColor => _spellColor;
    public Texture SpellActivationSymbol => _spellActivationSymbol;
    public Texture SpellEffectSymbol => _spellEffectSymbol;
    public string Description => _description;
    public Sprite SymbolSprite => symbolSprite;

}

public enum SpellType
{
    Death_Hole, Telekinesis, Creator, Manipulator, Soul_Shifter
}
