using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Sets/ConfigWeapons")]
public class ConfigWeapons : RuntimeSet<WeaponConf>
{
    public void OnEnable()
    {
        Items.Clear();
    }
}
