using UnityEngine;
using System.Collections;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 用于开始创建项目时，生成统一命名的文件夹
/// by gong 20170331 V1.0
/// </summary>
public class N_GenerateFloders : MonoBehaviour {


#if UNITY_EDITOR

     [MenuItem("MyTool/CreateFolder")]
	private static void CreateFolder(){
		fns_generateFloder (1);
	}


	private static void fns_generateFloder(int _flag){
	
		string t_path=Application.dataPath+"/";
		if (!Directory.Exists(t_path+"Audio"))
		Directory.CreateDirectory (t_path + "Audio");
		if (!Directory.Exists(t_path+"Prefabs"))
		Directory.CreateDirectory (t_path + "Prefabs");
		if (!Directory.Exists(t_path+"Materials"))
		Directory.CreateDirectory (t_path + "Materials");
		if (!Directory.Exists(t_path+"Resources"))
		Directory.CreateDirectory (t_path + "Resources");
		if (!Directory.Exists(t_path+"Scripts"))
		Directory.CreateDirectory (t_path + "Scripts");
		if (!Directory.Exists(t_path+"Textures"))
		Directory.CreateDirectory (t_path + "Textures");
		if (!Directory.Exists(t_path+"Scenes"))
		Directory.CreateDirectory (t_path + "Scenes");
		if (!Directory.Exists(t_path+"Meshes"))
		Directory.CreateDirectory (t_path + "Meshes");
		if (!Directory.Exists(t_path+"Shaders"))
		Directory.CreateDirectory (t_path + "Shaders");
		if (!Directory.Exists(t_path+"GUI"))
		Directory.CreateDirectory (t_path + "GUI");
		if (!Directory.Exists(t_path+"StreamingAssets"))
		Directory.CreateDirectory (t_path + "StreamingAssets");
          if (!Directory.Exists(t_path + "Animation"))
             Directory.CreateDirectory(t_path + "Animation");
          if (!Directory.Exists(t_path + "Editor"))
               Directory.CreateDirectory(t_path + "Editor");
          if (!Directory.Exists(t_path + "Word"))
               Directory.CreateDirectory(t_path + "Word");
		AssetDatabase.Refresh ();
	
	
	}

#endif
}
