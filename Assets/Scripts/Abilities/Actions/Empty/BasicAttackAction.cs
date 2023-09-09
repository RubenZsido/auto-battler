using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicAttackAction : BaseEmptyAction
{
    public float baseDamage;
    public float energyCost;
    public TargetingType TargetingType;
    public bool canTargetSelf;
    public List<StatType> plusStat;
    public List<StatType> multipliedByStat;
    public float distanceToMove;
    public override void Activate()
    {
        if (parentEntity == null)
        {
            Messenger.Instance.Log("Basic Attack Action has no parent");
        }
        Entity target = EntityManager.Instance.GetTarget(parentEntity, TargetingType, canTargetSelf);
        if (target == null)
        {
            Messenger.Instance.Log("No valid target for " + parentAbility.Name);
            return;
        }
        float finalDamage = baseDamage + plusStat.Sum(x => parentEntity.stats.GetStatValue(x));
        finalDamage *= Mathf.Max(1, multipliedByStat.Sum(x => parentEntity.stats.GetStatValue(x)));
        target.health.TryHit(finalDamage, parentEntity);
        Vector3 dir = parentEntity.transform.position - target.transform.position;
        parentEntity.transform.DOMove(parentEntity.transform.position + dir.normalized * distanceToMove, 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
