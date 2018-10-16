using UnityEngine;
using System.Collections;
using System;
namespace GasPowerGeneration.update
{
	public class UpdateCom : AB_UpdateCom {

		protected Action m_call;
		protected bool m_run = false;
		// Update is called once per frame
		void MyUpdate () {
			if (m_run) {
				if (m_call != null) {
					m_call ();
				} else {
					fn_kill ();
				}
			}
		}
		public override void fn_init (Action _call)
		{
			S_update.Instance.M_update = MyUpdate;
			if (_call != null) {
				m_call += _call;
				m_run = true;
			} else {
				fn_kill ();
			}
		}
		public override void fn_init (Action _call, bool _only)
		{
			if (_only) {
				m_call = null;
				fn_init (_call);
			} else {
				fn_init (_call);
			}
		}

		public override void fn_kill ()
		{

			m_run = false;
			if (m_call != null) {
				m_call = null;
			}
			S_update.Instance.fn_remove (MyUpdate);
			Destroy (this);

		}
		public override void fn_pause (bool _bl)
		{
			if (_bl) {
				m_run = false;
			} else {
				m_run = true;
			}
		}
		public override void fn_remove (Action _func)
		{
			if (_func!=null) {
				m_call -= _func;
			}
		}
	}
}
