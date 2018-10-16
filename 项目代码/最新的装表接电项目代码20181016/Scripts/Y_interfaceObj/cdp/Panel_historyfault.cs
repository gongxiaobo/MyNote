using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GasPowerGeneration;
namespace cdp
{
    public class CDPrandomtime
    {

        public string getrandomtime { get; set; }

        public CDPrandomtime()
        {
            System.Random random = new System.Random();
            string month = random.Next(1, 12).ToString("00");
            string date = random.Next(1, 29).ToString("00");
            string year = random.Next(0, 18).ToString("00");
            string mdy = month + date + year;
            string hour = random.Next(0, 24).ToString();
            string minute = random.Next(0, 60).ToString();
            string second = random.Next(0, 60).ToString();

            getrandomtime = mdy + "    " + hour + " H " + minute + " Min " + second + " S ";
        }
    }
    public class Panel_historyfault : N_CDPPanel
    {


        protected Text group_name;
        protected Text fault_index;
        protected Text param_name;
        protected Text time_info;
        
        /// <summary>
        /// 当前组索引
        /// </summary>
        public int group_index = 1002;
        /// <summary>
        /// 当前参数索引
        /// </summary>
        public int param_index =1;
        /// <summary>
        /// 当前组最大参数数
        /// </summary>
        private int max_param;

        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            group_name = TransformHelper.FindChild(transform, "group_name").GetComponent<Text>();
            param_name = TransformHelper.FindChild(transform, "param_name").GetComponent<Text>();
            fault_index = TransformHelper.FindChild(transform, "fault_index").GetComponent<Text>();
            time_info = TransformHelper.FindChild(transform, "time_info").GetComponent<Text>();
            blink = TransformHelper.FindChild(transform, "blink");

        }
        /// <summary>
        /// 显示该界面时触发
        /// </summary>
        public override void fn_show_panel()
        {
            base.fn_show_panel();
            fn_set_initstate();
        }

        private void fn_set_initstate() {
            if (CDPctrl_manager.Instance.last_fault_group.Count == 0)
            {
                fault_index.text = "1";
                param_name.text = "";
                time_info.text = "   H   Min  S";
                param_index = 0;
                max_param = 0;
                return;
            }

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
                    if (param_index >1)
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
        public override void btn_upup(bool press)
        {
            base.btn_upup(press);
            if (press)
                CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
        }

        public override void btn_downdown(bool press)
        {
            base.btn_downdown(press);
            if (press)
                CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
        }


        public override void btn_reset(bool press)
        {
            base.btn_reset(press);
            if (press)
            {
                CDPctrl_manager.Instance.last_fault_group.Clear();
                fni_level(2);//设置历史故障状态为清空
                fn_set_initstate();//刷新显示
            }
        }
        /// <summary>
        /// 显示当前参数信息
        /// </summary>
        private void fn_show_group_info()
        {

            group_name.text = S_CDPControl.Instance.fn_getGroupName(group_index);
            param_name.text = S_CDPControl.Instance.fn_getMemberName(group_index, param_index);
            //time_info.text=CDPctrl_manager.Instance.last_fault_group.
            foreach (var item in CDPctrl_manager.Instance.last_fault_group)
            {
                if (item.Key == param_index)
                    time_info.text = item.Value;
            } 
                
            fault_index.text = param_index.ToString();
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
            StateValueString state = (StateValueString)m_handler.fn_get("level");
            state.m_date = _level.ToString();
            m_handler.fn_set(state);
        }
    }
}