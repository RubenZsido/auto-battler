using UnityEngine;

public class TriggerableEntity : AbilityElementBase
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
