using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AbilityEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("Tools/Ability Editor")]
    private static void OpenWindow()
    {
        GetWindow<AbilityEditorWindow>().Show();
    }
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        tree.AddAllAssetsAtPath("Ability Editor", "Assets/ScriptableObjects/", typeof(Ability), true);
        return tree;
    }


}
