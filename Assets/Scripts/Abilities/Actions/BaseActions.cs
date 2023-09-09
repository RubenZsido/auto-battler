using System;

[Serializable]
public abstract class BaseEmptyAction : AbilityElementBase
{
    public abstract void Activate();
}
[Serializable]
public abstract class BaseFloatAction : AbilityElementBase
{
    public abstract void Activate(float value);
}

[Serializable]
public abstract class BaseEntityAction : AbilityElementBase
{
    public abstract void Activate(Entity entity);
}

[Serializable]
public abstract class BaseFloatEntityAction : AbilityElementBase
{
    public abstract void Activate(float value, Entity entity);
}

[Serializable]
public abstract class BaseFloatEntityEntityAction : AbilityElementBase
{
    public abstract void Activate(float value, Entity entity1, Entity entity2);
}