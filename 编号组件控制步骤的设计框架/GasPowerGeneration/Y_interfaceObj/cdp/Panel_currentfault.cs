using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using GasPowerGeneration;
namespace cdp
{
    public class Panel_currentfault : N_CDPPanel
    {
        protected Text group_name;
        protected Text fault_value;

        /// <summary>
        /// 当前组索引
        /// </summary>
        public int group_index = 1002;
        /// <summary>
        /// 当前参数索引
        /// </summary>
        public int param_index = 1;
        /// <summary>
        /// 当前组最大参数数
        /// </summary>
        private int max_param;

        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            group_name = TransformHelper.FindChild(transform, "group_name").GetComponent<Text>();
            fault_value = TransformHelper.FindChild(transform, "fault_value").GetComponent<Text>();
            blink = TransformHelper.FindChild(transform, "blink");

        }
        /// <summary>
        /// 显示该界面时触发
        /// </summary>
        public override void fn_show_panel()
        {
            base.fn_show_panel();
           
            fn_setmax_info();
            fn_show_group_info();
        }
        /// <summary>
        /// 设置组数和参数数最大值
        /// </summary>
        private void fn_setmax_info()
        {
            max_param = CDPctrl_manager.Instance.fn_getmaxparam_count(group_index);
        }

        /// <summary>
        /// 按下上时执行
        /// </summary>
        /// <param name="press"></param>
        public override void btn_up(bool press)
        {
            base.btn_up(press);
            if (press)
            {
                handler = () =>
                {
                    if (param_index > 1)
                    {
                        param_index--;
                        fn_show_group_info();
                    }
                };
                StartCoroutine(update_data(0.1f));
            }
            else
            {
                handler();
                handler = null;
                StopCoroutine(update_data(0.1f));
            }

        }


        public override void btn_down(bool press)
        {
            base.btn_up(press);
            if (press)
            {
                handler = () =>
                {
                    if (param_index < max_param)
                    {
                        param_index++;
                        fn_show_group_info();
                    }
                };
                StartCoroutine(update_data(0.1f));
            }
            else
            {
                handler();
                handler = null;
                StopCoroutine(update_data(0.1f));
            }


        }



        public override void btn_reset(bool press)
        {
            base.btn_reset(press);
            if (press)
            {
                if (CDPctrl_manager.Instance.current_fault_group.ContainsKey(param_index))
                {
                    CDPctrl_manager.Instance.current_fault_group.Remove(param_index);
                    if(!CDPctrl_manager.Instance.last_fault_group.ContainsKey(param_index))
                        CDPctrl_manager.Instance.last_fault_group.Add(param_index, new CDPrandomtime().getrandomtime);
                }
                fn_show_group_info();
            }
        }
        /// <summary>
        /// 显示当前参数信息
        /// </summary>
        private void fn_show_group_info()
        {
            Dictionary <int,string > dic=CDPctrl_manager.Instance.current_fault_group;


            if (dic.Count != 0)
            {
                //int minkey = dic.Keys.Select(x => new { x, y = dic.Keys }).OrderBy(x => x.x).First(x => x.x > param_index).x;

                var minkey = dic.FirstOrDefault(d => d.Key > param_index);
                if (dic.ContainsKey(param_index))
                {
                    fault_value.text = dic[param_index];
                }
                else
                {
                    fault_value.text = dic[minkey.Key];
                    param_index = minkey.Key;
                }

            }

            else
            {
                fni_level(2);
                CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.historyfault);
             
            }
        }


        /// <summary>
        /// 取消选中 高亮等状态
        /// </summary>
        protected override void fn_cancelcurrentstate()
        {
            base.fn_cancelcurrentstate();
            handler = null;
        }
        public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
        {
            base.fni_level(_level, _controlType);
            if (_controlType == E_ControlType.e_init)
            {
                if (_level == 2)
                    CDPctrl_manager.Instance.current_fault_group.Clear();
            }
            else {
                StateValueString state = (StateValueString)m_handler.fn_get("level");
                state.m_date = _level.ToString();
                m_handler.fn_set(state);
            }
        }
    }
}
