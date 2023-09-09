using System;
using UnityEngine;

[Serializable]
public class TriggerableEntity : TriggerableBase
{
    [field: SerializeReference]
    public BaseEntityAction action;
    public EntityGameEventType eventType;
    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        action.Init(parentEntity, parentAbility);
        parentEntity.events.entityEvents.GetListElement(eventType).RegisterListener(action.Activate);
    }
}
