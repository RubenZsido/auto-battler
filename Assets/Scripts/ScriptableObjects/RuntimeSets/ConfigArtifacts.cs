using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Sets/ConfigArtifacts")]
public class ConfigArtifacts : RuntimeSet<ArtifactConf>
{
    public void OnEnable()
    {
        Items.Clear();
    }
}
