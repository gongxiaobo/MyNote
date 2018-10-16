using UnityEngine;
using System.Collections;
//using Xreal;
//using GCode;
/// <summary>
/// 初始存档工具
/// </summary>
public class SaveTool : MonoBehaviour {
	private ArrayList m_alText=new ArrayList();
	private string m_strFileNametxt="SaveDate";
	// Use this for initialization
	void Start () {
//		m_alText.Add(new SMessage()
		init();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

//     private Message addSMessage(Message _msg){
////		Message temp = new Message ();
////		temp.name = _name;
////		temp.type = _type;
////		temp.blPara = _date;
//          return _msg;
//     }
//	private SMessage addSMessage(string _name,string _type,float _date){
//		SMessage temp = new SMessage ();
//		temp.name = _name;
//		temp.type = _type;
//		temp.flPara = _date;
//		return temp;
//	}
//	private SMessage addSMessage(string _name,string _type,int  _date){
//		SMessage temp = new SMessage ();
//		temp.name = _name;
//		temp.type = _type;
//		temp.intPara = _date;
//		return temp;
//	}
//	private SMessage addSMessage(string _name,string _type,string _date){
//		SMessage temp = new SMessage ();
//		temp.name = _name;
//		temp.type = _type;
//		temp.strPara = _date;
//		return temp;
//	}

	void init(){

//		m_alText.Add (JsonUtility.ToJson (addSMessage ("HookUpPoint","f",30f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("HookDownPoint","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("StandpipeUpperLimit","f",30f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("StandpipeLowerLimit","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("TempAlarmSet","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("HumidityAlarmSet","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("MotorMode","b",false)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("DWMode","b",false)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("TotalStrokes1","i",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("TotalStrokes2","i",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("TotalStrokes3","i",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("AllStrokes","i",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("MonkeyBoardPro","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("DrillSpeedLimit","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("RateHookload","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("ResAlarm","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("ResFault","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("LinesStrung","i",2)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("MudFlowUp","f",0f)));
//		m_alText.Add (JsonUtility.ToJson (addSMessage ("AlarmXStop","i",3)));
//		ContrlTxt.fnAdd (m_strFileNametxt, m_alText);

	
	}
}
