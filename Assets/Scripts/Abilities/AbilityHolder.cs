using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AbilityHolder : EntityComponent
{
    public List<Ability> abilities;

    public override void Init(Entity parentEntity)
    {
        base.Init(parentEntity);
        abilities.ForEach(ability => ability.Init(parentEntity));
    }
    public void Add(Ability ability)
    {
        Ability a = ScriptableObject.Instantiate(ability);
        a.Init(parentEntity);
        abilities.Add(a);
    }

    public void Remove(Ability ability)
    {
        abilities.Remove(ability);
    }

    public void ClearAbilities()
    {
        foreach (Ability ability in abilities)
        {
            Remove(ability);
        }
    }
}
