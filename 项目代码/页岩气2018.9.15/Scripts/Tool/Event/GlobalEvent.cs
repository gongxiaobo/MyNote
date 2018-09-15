using UnityEngine;
using System.Collections;
//namespace GCode
//{
	public class GlobalEvent  
	{
		public readonly bool _bool;
		public GlobalEvent(bool isbool)
		{
			_bool = isbool;
		}


	}
	/// <summary>
	/// 重置所有机器
	/// </summary>
	public class resetAllMachine
	{
		public readonly bool _bool;
		public resetAllMachine(bool isbool)
		{
			_bool = isbool;
		}
	}
	/// <summary>
	/// 顶驱的移动事件
	/// </summary>
	public class TdUpDown
	{
		public  float _float;
		public TdUpDown(float isfloat)
		{
			_float = isfloat;
		}
		public void setSpeed(float isfloat){
			_float = isfloat;
		}
	}
	/// <summary>
	/// 顶驱的挂点初始化。
	/// </summary>
	public class TDsetRigibody{
		public TDsetRigibody()
		{
		}
	}
	/// <summary>
	/// 松开吊卡卡瓦后检查顶驱旋转值
	/// 如果顶驱给定速度，重新启动TD_PipeRotatingCall任务
	/// </summary>
	public class TD_PipeRotatingCallEvent
	{
		public TD_PipeRotatingCallEvent(){}
	
	}
	/// <summary>
	/// 主钳旋转,触发钻杆的旋转
	/// </summary>
	public class IronMasterTongsRotate{
		public readonly int ID;
		public readonly float speedStart;
		public IronMasterTongsRotate(int id,float _speedStart){
			ID = id;
			speedStart = _speedStart;
		}
	}
	/// <summary>
	/// 顶驱触发器
	/// </summary>
	public struct ActiveTrigger{
		public bool active;

	}
	/// <summary>
	/// 顶驱绳子的链接点设置
	/// </summary>
	public class TDRopeEvent{
		public readonly Rigidbody connected;
		public TDRopeEvent(Rigidbody _connect){
			this.connected = _connect;
		}
	}
    public class N_getTransform
    {
        public Transform m_ropehandle;
        public N_getTransform(Transform _tra)
        {
            m_ropehandle = _tra;
        }
    }



//}

