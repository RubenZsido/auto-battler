using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "new Ability")]
public class Ability : ScriptableObject
{
    public Entity parentEntity;
    [TabGroup("Basics")]
    public string Name;
    [TabGroup("Basics")]
    public string Description;
    [TabGroup("Basics")]
    public int Cost;
    [PreviewField(300)]
    [TabGroup("Basics")]
    public Sprite Image;
    [TabGroup("Basics")]
    public Rarity Rarity;

    [field: SerializeReference]
    [TabGroup("Passives")]
    public List<PassiveBase> Passives;

    [field: SerializeReference]
    [TabGroup("Activatables")]
    public List<ActivatableBase> Activatables;

    [field: SerializeReference]
    [TabGroup("Triggerables")]
    public List<TriggerableBase> Triggerables;
    public void Init(Entity parentEntity)
    {
        this.parentEntity = parentEntity;
        if (parentEntity == null)
        {
            Messenger.Instance.Log("Ability " + Name + " has no parent");
        }
        InitPassives();
        InitActivatables();
        InitTriggerables();
    }
    private void InitPassives()
    {
        Passives.ForEach(passive => passive.Init(parentEntity, this));
    }
    private void InitActivatables()
    {
        Activatables.ForEach(activateable => activateable.Init(parentEntity, this));
    }
    private void InitTriggerables()
    {
        Triggerables.ForEach(triggerable => triggerable.Init(parentEntity, this));
    }
    public void TryActivate()
    {
        Activatables.ForEach(a => a.TryActivate());
    }

}
