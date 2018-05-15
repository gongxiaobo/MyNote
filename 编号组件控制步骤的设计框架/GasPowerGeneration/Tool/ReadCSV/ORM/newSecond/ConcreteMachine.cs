using UnityEngine;
using System.Collections;
///<summary>
///@ version 1.0 /2017.0216/ :具体机器的按键列表信息
///@ author gong
///@ version 1.1 /2017.0302/ :加入btn_state，用于初始状态
///@ author gong
///@ version 1.2 /2017./ :
///@ author gong
///@ version 1.3 /2017./ :
///@ author gong
///</summary>
public class ConcreteMachine  {
	/// <summary>
	/// 按键编号，int型
	/// </summary>
	public readonly int btn_id;
	/// <summary>
	/// 按键的中文名
	/// </summary>
	public readonly string btn_name;
	/// <summary>
	/// 按键的类型，int 型
	/// </summary>
	public readonly int btn_type;
	/// <summary>
	/// 按键描述语音名
	/// </summary>
	public readonly string btn_voice;
	/// <summary>
	/// 按键的文字解释
	/// </summary>
	public readonly string btn_txt;
	/// <summary>
	/// 按键的初始状态
	/// </summary>
	public readonly string btn_state;

}
