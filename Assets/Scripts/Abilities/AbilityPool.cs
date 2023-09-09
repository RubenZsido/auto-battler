using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu(menuName = "new AbilityPool")]
public class AbilityPool : RuntimeSet<Ability>
{
    [Button("Add all abilities")]
    public void AddAllAbilities()
    {
        Items.Clear();
        Items = Helper.FindAllScriptableObjectsOfType<Ability>("t: Ability");
    }

}
