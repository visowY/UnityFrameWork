using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorScriptableManager 
{
    [MenuItem("Assets/Create/Framework/DefaultConfigScripTable")]
   public static void CreateDefaultEditorConfig()
   {
       ProjectDefaultConfig asset = ScriptableObject.CreateInstance<ProjectDefaultConfig>();
       AssetDatabase.CreateAsset(asset, "Assets/FrameWork/Editor/Config/ProjectDefaultConfig.asset");
       AssetDatabase.SaveAssets();
       
       EditorUtility.FocusProjectWindow();
       Selection.activeObject = asset;
   }

    public static ProjectDefaultConfig GetDefaultConfig()
    {
        ProjectDefaultConfig asset = AssetDatabase.LoadAssetAtPath<ProjectDefaultConfig>("Assets/FrameWork/Editor/Config/ProjectDefaultConfig.asset");
        return asset;
    }
}
