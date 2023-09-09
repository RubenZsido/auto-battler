using System;
using UnityEngine;

[Serializable]
public class ActivatableBase : AbilityElementBase
{
    [field: SerializeReference]
    public BaseEmptyAction action;
    public bool activateAtStart = true;
    public float cooldown;
    private float nextActivationTime;
    public override void Init(Entity parentEntity, Ability parentAbility)
    {
        base.Init(parentEntity, parentAbility);
        action.Init(parentEntity, parentAbility);
        if (activateAtStart)
        {
            nextActivationTime = Time.time;
        }
        else
        {
            nextActivationTime = Time.time + cooldown;
        }
    }
    public void TryActivate()
    {
        //if we are before next activation time
        if (Time.time < nextActivationTime)
        {
            return;
        }
        nextActivationTime = Time.time + cooldown;
        action.Activate();
    }
}

