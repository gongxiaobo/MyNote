using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGUI : MonoBehaviour {
     public string m_name = "good";
     void OnGUI()
     {
          GUI.Box(new Rect(10, 10, 100, 90), m_name);
          GUI.Label(new Rect(10, 10, 30, 30), m_name);
     }
}
