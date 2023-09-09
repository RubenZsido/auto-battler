using System;
using UnityEngine;
[Serializable]
public class TriggerableEmpty : TriggerableBase
{
    [field: SerializeReference]
    public BaseEmptyAction action;
    public EmptyGameEventType eventType;

    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        parentEntity.events.emptyEvents.GetListElement(eventType).RegisterListener(action.Activate);
    }

}