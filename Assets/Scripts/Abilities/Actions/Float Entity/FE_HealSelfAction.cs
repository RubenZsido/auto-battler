public class FE_HealSelfAction : BaseFloatEntityAction
{
    public override void Activate(float value, Entity entity)
    {
        if (entity == parentEntity)
        {
            parentEntity.health.Heal(value, parentEntity);
        }
    }
}
