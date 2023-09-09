using System;
using UnityEngine;

[Serializable]
public class PassiveBase : AbilityElementBase
{
    [field: SerializeReference]
    public BaseEmptyAction action;

    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        action.Init(parentEntity, parentAbility);
        action.Activate();
    }
}