public class AddStatModifierAction : BaseEmptyAction
{
    public StatType statType;
    public float Flat;
    public float PercentAdd;
    public float PercentMult;
    public override void Activate()
    {
        Stat stat = parentEntity.stats.GetStat(statType);
        if (stat == null)
        {
            Messenger.Instance.Log("Stat " + statType.ToString() + " Not found");
            return;
        }
        if (Flat != 0)
        {
            stat.AddStatModifier(new StatModifier(Flat, StatModType.Flat, parentAbility));
        }
        if (PercentAdd != 0)
        {
            stat.AddStatModifier(new StatModifier(PercentAdd, StatModType.PercentAdd, parentAbility));
        }
        if (PercentMult != 0)
        {
            stat.AddStatModifier(new StatModifier(PercentMult, StatModType.PercentMult, parentAbility));
        }
        parentEntity.events.statEvents.GetListElement(StatGameEventType.StatChanged).Raise(statType);
    }
}
