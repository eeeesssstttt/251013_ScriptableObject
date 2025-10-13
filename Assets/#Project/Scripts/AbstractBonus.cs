using UnityEngine;

public abstract class AbstractBonus : ScriptableObject
{
    public abstract void ApplyBonus(PlayerController player);
    public abstract void ApplyColor(ZoneBehavior zone);
}
