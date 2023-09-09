using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Sets/ConfigEnemies")]
public class ConfigEnemies : RuntimeSet<EnemyConf>
{
    public void OnEnable()
    {
        Items.Clear();
    }
}
