using System;
using UnityEngine;

[Serializable]
public class EntityHealth : EntityComponent
{
    public float health;
    public float maxHealth;
    public float shield;
    public float maxShield;
    public bool isAlive = true;
    public GameObject parryEffect;
    public GameObject dodgeEffect;

    public override void Init(Entity parentEntity)
    {
        base.Init(parentEntity);
        maxHealth = parentEntity.stats.GetStatValue(StatType.MaxHealth);
        health = maxHealth;
        maxShield = parentEntity.stats.GetStatValue(StatType.MaxShield);
        shield = 0;
        parentEntity.events.statEvents.GetListElement(StatGameEventType.StatChanged).RegisterListener(OnStatChanged);
    }

    private void OnStatChanged(StatType statType)
    {
        if (statType == StatType.MaxHealth)
        {
            float changeTo = parentEntity.stats.GetStatValue(StatType.MaxHealth);
            float difference = changeTo - maxHealth;
            maxHealth = changeTo;
            health += difference;
            parentEntity.events.floatEvents.GetListElement(FloatGameEventType.HealthChanged).Raise(health);
        }
    }
    public void TryHit(float damage, Entity attacker)
    {
        if (!isAlive)
        {
            Messenger.Instance.Log("You hit the corpse of " + parentEntity.gameObject.name);
            return;
        }
        float dodgeChance = parentEntity.stats.GetStatValue(StatType.DodgeChance);
        float randomValue = UnityEngine.Random.Range(0, 101);
        if (randomValue <= dodgeChance)
        {
            parentEntity.events.entityEvents.GetListElement(EntityGameEventType.Dodged).Raise(attacker);
            // dodged animation
            Instantiate(dodgeEffect);
            return;
        }
        float parryChance = parentEntity.stats.GetStatValue(StatType.DodgeChance);
        randomValue = UnityEngine.Random.Range(0, 101);
        if (randomValue <= parryChance)
        {
            parentEntity.events.entityEvents.GetListElement(EntityGameEventType.Parried).Raise(attacker);
            // parried animation
            Instantiate(parryEffect);
            return;
        }
        HitHealth(damage, attacker);
    }

    public void HitShield(float damage, Entity attacker)
    {
        shield -= damage;
    }
    public void HitHealth(float damage, Entity attacker)
    {
        parentEntity.events.floatEntityEvents.GetListElement(FloatEntityGameEventType.Damaged).Raise(damage, attacker);
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            onDie();
            attacker.events.entityEvents.GetListElement(EntityGameEventType.EnemyKilled).Raise(parentEntity);
        }
        parentEntity.events.floatEvents.GetListElement(FloatGameEventType.HealthChanged).Raise(health);
    }

    public void onDie()
    {
        isAlive = false;
        Messenger.Instance.Log(parentEntity.gameObject.name + " is Dead!");
        EntityManager.Instance.DestroyEntity(parentEntity);
        gameObject.SetActive(false);
    }

    public void Heal(float value, Entity entity)
    {
        parentEntity.events.floatEntityEvents.GetListElement(FloatEntityGameEventType.Healed).Raise(value, entity);
    }
}
