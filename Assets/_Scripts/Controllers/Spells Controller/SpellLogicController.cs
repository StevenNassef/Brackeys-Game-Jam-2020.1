using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  SpellLogicController : MonoBehaviour
{
    public virtual void SpellTileMouseDown() {}
    public virtual void SpellTileMouseDrag() {}
    public virtual void SpellTileMouseUp() {}
}
