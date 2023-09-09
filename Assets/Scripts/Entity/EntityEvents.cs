using UnityEngine;

public class EntityEvents : MonoBehaviour
{
    public EnumList<EmptyGameEventType, GameEvent> emptyEvents;
    public EnumList<FloatGameEventType, GameEvent<float>> floatEvents;
    public EnumList<StatGameEventType, GameEvent<StatType>> statEvents;
    public EnumList<EntityGameEventType, GameEvent<Entity>> entityEvents;
    public EnumList<FloatEntityGameEventType, GameEvent<float, Entity>> floatEntityEvents;

    public void Init()
    {
        emptyEvents = new();
        floatEvents = new();
        statEvents = new();
        entityEvents = new();
        floatEntityEvents = new();
    }
}





