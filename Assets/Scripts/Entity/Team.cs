using System;
using System.Collections.Generic;

[Serializable]
public class Team : EntityComponent
{
    public List<Entity> createdEntities;
    public List<Entity> GetAllEntities()
    {
        List<Entity> combinedList = new List<Entity>();
        if (createdEntities != null)
        {
            combinedList.AddRange(createdEntities);
        }
        combinedList.Add(parentEntity);
        return combinedList;
    }
    public void AddEntity(Entity entity)
    {
        createdEntities.Add(entity);
        parentEntity.events.entityEvents.GetListElement(EntityGameEventType.EntityCreated).Raise(entity);
    }
    public void RemoveEntity(Entity entity)
    {
        createdEntities.Remove(entity);
    }

}
