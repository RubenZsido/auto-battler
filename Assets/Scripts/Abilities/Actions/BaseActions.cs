using System;

public abstract class BaseAction : AbilityElementBase
{

}

[Serializable]
public abstract class BaseEmptyAction : BaseAction
{
    public abstract void Activate();
}
[Serializable]
public abstract class BaseFloatAction : BaseAction
{
    public abstract void Activate(float value);
}

[Serializable]
public abstract class BaseEntityAction : BaseAction
{
    public abstract void Activate(Entity entity);
}

[Serializable]
public abstract class BaseFloatEntityAction : BaseAction
{
    public abstract void Activate(float value, Entity entity);
}

[Serializable]
public abstract class BaseFloatEntityEntityAction : BaseAction
{
    public abstract void Activate(float value, Entity entity1, Entity entity2);
}