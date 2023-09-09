using UnityEngine;

public class TriggerableFloatEntity : TriggerableBase
{
    [field: SerializeReference]
    public BaseFloatEntityAction action;
    public FloatEntityGameEventType eventType;
    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        parentEntity.events.floatEntityEvents.GetListElement(eventType).RegisterListener(action.Activate);
    }

}
