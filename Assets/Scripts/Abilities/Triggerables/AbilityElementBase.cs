using System;
using UnityEngine;

[Serializable]
public abstract class AbilityElementBase
{
    [HideInInspector]
    protected Entity parentEntity;
    [HideInInspector]
    protected Ability parentAbility;
    public virtual void Init(Entity parentEntity, Ability parentAbility)
    {
        this.parentAbility = parentAbility;
        this.parentEntity = parentEntity;
    }
}