using UnityEngine;
using System.Collections;
using UnityEditor;

namespace RootMotion {

	[CustomEditor(typeof(Comments))]
	public class CommentsInspector : Editor {
	
		private Comments script { get { return target as Comments; }}
		private GUIStyle style = new GUIStyle();
		
		// Black and white
		//private static Color pro = new Color(0.7f, 0.7f, 0.7f, 1f);
		//private static Color free = new Color(0, 0, 0, 1);
          private static Vector3 mycolor = new Vector3(0, 114, 255);
		// Colors
          //private static Color pro = new Color(0.066f, 0.474f, 0.239f, 1f);
          //private static Color pro = new Color(0.5f, 0.7f, 0.3f, 1f);
          //private static Color pro = new Color(0.066f, 0.474f, 0.239f, 1f);
          private static Color pro = new Color(mycolor.x / 255, mycolor.y / 255, mycolor.z / 255, 1f);
          //private static Color free = new Color(0.2f, 0.3f, 0.1f, 1f);
          private static Color free = pro;
		
		public override void OnInspectorGUI() {
			if (serializedObject == null) return;
			
			style.wordWrap = true;
			style.normal.textColor = EditorGUIUtility.isProSkin? pro: free;
			
			serializedObject.Update();
			EditorGUILayout.Space();
			
			string text = EditorGUILayout.TextArea(script.text, style);
			if (text != script.text) {
				Undo.RecordObject(script, "Edit Comments");
				script.text = text;
			}
			
			EditorGUILayout.Space();
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}
