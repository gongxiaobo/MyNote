using UnityEngine;
using System.Collections;
using UnityEditor;
/// <summary>
/// Apply material textures.
/// --made by gong --2016.8.1- v1.0
/// </summary>
namespace GCode{
public class ApplyMaterialTextures : EditorWindow {
	public static string[] config = { 
		".PNG",".png",".JPG",".jpg",".TGA",".tga",".PSD"};
	public enum textureType{
		diffmap=1,
		metalmap,
		nlmap,
		aomap};
	[MenuItem("MyWindows/ApplyMaterialTextures")]
	static void Apply()
	{
		Rect wr = new Rect (0, 0, 250, 250);
		ApplyMaterialTextures window = (ApplyMaterialTextures)EditorWindow.GetWindowWithRect (typeof(ApplyMaterialTextures), 
			wr, true, "随便版");
		window.Show ();
	}
	void OnGUI()
	{
		if (GUILayout.Button ("关联贴图")) {
			ApplyTexture ();
		}
	}
	void ApplyTexture()
	{
		
		if (Selection.activeGameObject != null) {
			foreach (GameObject g in Selection.gameObjects) {
				MeshRenderer[] renders = g.GetComponentsInChildren<MeshRenderer> ();
				foreach (MeshRenderer mr in renders) {
					if (mr != null) {
						foreach (Object ob in mr.sharedMaterials) {
						
							string path = AssetDatabase.GetAssetPath (ob);

							Material tmr = AssetDatabase.LoadAssetAtPath (path, typeof(Material))as Material;
							if (tmr == null)
								continue;
							string path1=path.Substring(0,(path.Length-(ob.name.Length+14)));
                                   Texture diffuse = GetTexture(GetTextureName(ob.name, textureType.diffmap), path1);
                                   if (diffuse != null)
                                   {
                                        tmr.mainTexture = diffuse;
                                   }
							Texture metalmap = GetTexture (GetTextureName (ob.name, textureType.metalmap), path1);
							if (metalmap!= null) {
								tmr.SetTexture("_MetallicGlossMap", metalmap);
							}
							Texture normalmap = GetTexture (GetTextureName (ob.name, textureType.nlmap), path1);
							if (normalmap!= null) {
								tmr.SetTexture("_BumpMap", normalmap);
							}
							Texture aomap = GetTexture (GetTextureName (ob.name, textureType.aomap), path1);
							if (aomap!= null) {
								tmr.SetTexture("_OcclusionMap", aomap);
							}								
//							string path1=path.Remove((path.Length-(ob.name.Length+5)),path.Length


						}
					}
				}
			}

	}
		Debug.Log("完成材质贴图关联!!!!!!!!!!!!!");
}
	//
	static Texture GetTexture(string name,string path)
	{
          Debug.Log("<color=blue>path:</color>" + path);
		foreach (string type in config) {
			Texture tx = AssetDatabase.LoadAssetAtPath (path + name + type, typeof(Texture))as Texture;
			if (tx != null)
				return tx;
			
		}
          
          Debug.Log("<color=red>没有找到贴图</color>");
     
		return null;
	}
	/// <summary>
	/// 传入材质球的名字
	/// </summary>
	/// <returns>The texture name.</returns>
	/// <param name="name">Name.</param>
	static string GetTextureName(string name,textureType _textureType)
	{
		int tlength = name.Length;
          //Debug.Log(tlength.ToString());
		string namebase = name.Substring (4, tlength-4);
          Debug.Log(namebase);
          //Debug.Log (namebase);
		switch (_textureType) {
		case textureType.diffmap:
			return"t_d_"+namebase;
		case textureType.nlmap:
			return"t_n_"+namebase;
		case textureType.metalmap:
			return"t_m_"+namebase;
		case textureType.aomap:
			return"t_a_"+namebase;
		}
		
		return"";
	}

}
}