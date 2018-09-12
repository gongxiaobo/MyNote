using UnityEngine;
using System.Collections;
//using GCode;
using System;

namespace GasPowerGeneration.update
{
	///<summary>
	///@ version 1.0 /2017.0602/ :统一的update ,fixedupdate调用
	///@ author gong
	///@ version 1.1 /2017.0619/ :跳转场景时销毁更新对象，
	///@ author gong
	///@ version 1.2 /2017./ :
	///@ author gong
	///@ version 1.3 /2017./ :
	///@ author gong
	///</summary>
	public class S_update : GenericSingletonClass<S_update>
	{
	

		#region Update

		private Action m_update;

		public Action M_update {
			private get {
				return m_update;
			}
			set {
				if (value!=null) {
					m_update += value;
				}
			}
		}

		public void fn_remove (Action _fuc)
		{
			if (_fuc!=null) {
				m_update -= _fuc;
			}
		}
		// Update is called once per frame
		void Update ()
		{
			if (m_killed) {
				return;
			}
			if (m_update != null) {
				m_update ();
			}
//			Debug.Log ("<color=blue>update=</color>"+Time.deltaTime);
		}

		#endregion

		#region FixedUpdate

		private Action m_fixedupdate;

		public Action M_fixedupdate {
			private get {
				return m_fixedupdate;
			}
			set {
				if (value!=null) {
					m_fixedupdate += value;
				}
			}
		}

		public void fn_removeFixed (Action _fuc)
		{
			if (_fuc!=null) {
				m_fixedupdate -= _fuc;
			}
		}

		void FixedUpdate ()
		{
			if (m_killed) {
				return;
			}
			if (m_fixedupdate != null) {
				m_fixedupdate ();
			}
//			Debug.Log ("<color=blue>FixedUpdate=</color>"+Time.deltaTime);
		}

		#endregion
		private bool m_killed = false;
		public void fn_kill(){
			m_killed = true;
			m_update = null;
			m_fixedupdate = null;
			Destroy (this);
			Destroy (this.gameObject);
		}

	}
}
