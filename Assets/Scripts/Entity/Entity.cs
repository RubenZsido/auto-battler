using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<Ability> startingAbilities;
    public EntityStats stats;
    public AbilityHolder abilities;
    public EntityEvents events;
    public EntityHealth health;
    public HealthBar healthBar;
    public Team team;
    bool canAttack = false;

    public void FixedUpdate()
    {
        if (canAttack)
        {
            TryActivatingAbilities();
        }
    }

    public void Awake()
    {
        //init scripts
        events.Init();
        stats.Init(this);
        abilities.Init(this);
        health.Init(this);
        team.Init(this);
    }
    private void Start()
    {
        foreach (Ability ability in startingAbilities)
        {
            abilities.Add(ability);
        }

    }

    public void ResetEntity()
    {

    }
    public void EnableEntity()
    {
        canAttack = true;
    }
    public void DisableEntity()
    {
        canAttack = false;
    }

    private void TryActivatingAbilities()
    {
        abilities.abilities.ForEach(ability => ability.TryActivate());
    }
}
