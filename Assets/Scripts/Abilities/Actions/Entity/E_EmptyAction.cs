using UnityEngine;

public class E_EmptyAction : BaseEntityAction
{
    [field: SerializeReference]
    BaseEmptyAction action;
    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        action.Init(parentEntity, parentAbility);
    }
    public override void Activate(Entity entity)
    {
        action.Activate();
    }
}
