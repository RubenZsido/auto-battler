using UnityEngine;

public abstract class EntityComponent : MonoBehaviour
{
    public Entity parentEntity;

    public virtual void Init(Entity parentEntity)
    {
        this.parentEntity = parentEntity;
    }
}
