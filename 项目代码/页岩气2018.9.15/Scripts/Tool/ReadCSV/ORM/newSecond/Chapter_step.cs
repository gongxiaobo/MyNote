using UnityEngine;
using System.Collections;
///<summary>
///@ version 1.0 /2017.0216/ :科目的步骤配置
///@ author gong
///@ version 1.1 /2017.0225/ :新增科目名 title
///@ author gong
///@ version 1.2 /2017.0302/ : tgt_state 类型改为string,这样适合状态的很多变化
///@ author gong
///@ version 1.3 /2017.0421/ :加入新的字段，机器的所属机器名称
///@ author gong
///</summary>
public class Chapter_step  {
	/// <summary>
	/// 科目步骤，int
	/// </summary>
	public readonly int step_id;
	/// <summary>
	/// 要控制的机器名称，这要和机器的描述表名称一直,string
	/// </summary>
	public readonly string m_name;
	/// <summary>
	/// 控制机器上的哪个按钮的编号,int
	/// </summary>
	public readonly int btn_id;
	/// <summary>
	/// 希望按钮改变的目标状态,string
	/// </summary>
	public readonly string tgt_state;
	/// <summary>
	/// 语音解说文件名
	/// </summary>
	public readonly string voice_name;
	/// <summary>
	/// 文字描述
	/// </summary>
	public readonly string text;
	/// <summary>
	/// 标题描述
	/// </summary>
	public readonly string title;
	/// <summary>
	/// 所属汽车的名称
	/// </summary>
	public readonly string car_name;

}
