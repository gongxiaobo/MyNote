using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的操作界面的参数项控制类
     /// </summary>
    public abstract class AB_bumpparam : MonoBehaviour, I_bumpparam,I_Control
    {


        internal float coefficient=1;//校正系数
        internal float offset = 0;//偏移量

        internal float original_value;
        private N_HandleEvent_init hander;
        protected virtual void Awake() {
            hander = GetComponent<N_HandleEvent_init>();
        }
        protected virtual void Start() { }
        /// <summary>
        /// 更新参数
        /// </summary>
        /// <param name="_call"></param>
        /// <param name="bumpid"></param>
        public abstract void fn_update_param(Action<int, string> _call, int bumpid);


        public int param_id
        {
            get {
                 if (hander==null)
                 {
                      hander = GetComponent<N_HandleEvent_init>();
                 }
                 if (hander!=null)
                 {
                 return hander.ID.m_ID;
                 }
                 return 0;
            }
         
        }

        #region I_Control
        public virtual void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
        {
        } 
        #endregion

        /// <summary>
        /// 获取参数范围
        /// </summary>
        /// <param name="unit_range"></param>
        /// <returns></returns>
        public abstract Vector2 fn_get_unit_range(Action<Vector2> unit_range);
        /// <summary>
        /// 设置bool类型参数
        /// </summary>
        /// <param name="set_call"></param>
        /// <param name="bumpid"></param>
        /// <param name="value"></param>
        public virtual void fn_set_param(Action<int, string> set_call, int bumpid, bool value)
        {
        }
        /// <summary>
        /// 设置浮点类型参数
        /// </summary>
        /// <param name="set_call"></param>
        /// <param name="bumpid"></param>
        /// <param name="value"></param>
        public virtual void fn_set_param(Action<int, string> set_call, int bumpid, float value)
        {
        }

        /// <summary>
        /// 获取当前参数值
        /// </summary>
        /// <returns></returns>
        public string fn_get_param_value()
        {
            return hander.fn_getMainValue();
        }
    }
}