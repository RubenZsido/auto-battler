using System;
using UnityEngine;

[Serializable]
public class TriggerableFloat : TriggerableBase
{
    [field: SerializeReference]
    public BaseFloatAction action;
    public FloatGameEventType eventType;
    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        action.Init(parentEntity, parentAbility);
        parentEntity.events.floatEvents.GetListElement(eventType).RegisterListener(action.Activate);
    }
}