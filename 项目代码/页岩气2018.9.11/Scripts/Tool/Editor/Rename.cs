using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
public class Rename :EditorWindow {

    [MenuItem("MyTool/RenameEffect")]
    static void Apply()
    {
        Rect wr = new Rect(0, 0, 200 , 200);
        MyEditorTool window = (MyEditorTool)EditorWindow.GetWindowWithRect(typeof(Rename),
             wr, true, "rename");
        window.Show();
    }
    static void Renames()
    {
       
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
            if (!(o is Object))
                continue;
            //string[] temp = o.name.Split('_');
            //string i = temp[1];
            //string i = o.name.Remove(0,2);
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(o), rename + a);
            a = ((int.Parse(a)) + 1).ToString();
        }
    }

    static string rename = "";
    static string a = "1";
    void OnGUI()
    {

        #region make prefab
        GUILayout.Label("明名名称：", EditorStyles.boldLabel);
        rename = EditorGUILayout.TextField(rename);
        GUILayout.Label("编号起点：", EditorStyles.boldLabel);
        a = EditorGUILayout.TextField(a);
        if (GUILayout.Button("重命名"))
        {

            Renames();
        }
        #endregion




    }
}
