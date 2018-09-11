using UnityEngine;
using System.Collections;
///<summary>
///@ version 1.0 /2017.0216/ :选择场景的读表信息类
///@ author gong
///@ version 1.1 /2017./ :
///@ author gong
///@ version 1.2 /2017./ :
///@ author gong
///@ version 1.3 /2017./ :
///@ author gong
///</summary>
public class StudyChapterTable  {
	/// <summary>
	/// 章节的编号
	/// </summary>
	public readonly int ID;
	/// <summary>
	/// 章节的中文名
	/// </summary>
	public readonly string name;
	/// <summary>
	/// 章节在学习场景的状态
	/// </summary>
	public readonly string studystate;
	/// <summary>
	/// 章节在练习场景的状态
	/// </summary>
	public readonly string practisestate;
	/// <summary>
	/// 章节在考试场景的状态
	/// </summary>
	public readonly string teststate;
	/// <summary>
	/// 章节的详细步骤表名
	/// </summary>
	public readonly string chapter_step;

}
