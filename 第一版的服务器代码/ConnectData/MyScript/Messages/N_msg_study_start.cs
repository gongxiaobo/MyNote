using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 学习场景开始记录
/// c to s 
/// </summary>
class N_msg_study_start : A_baseMsg
{
    public string m_studentID="";
    public string m_chapterID="";
    public UInt16 m_lastStepID=0;
    public UInt16 m_allStep=0;
    public Byte m_progress=0;
    public N_msg_study_start() { }

}

