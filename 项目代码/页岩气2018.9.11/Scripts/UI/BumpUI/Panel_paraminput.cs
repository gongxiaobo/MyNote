using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace GasPowerGeneration
{
    /// <summary>
    /// 设置参数的类型
    /// </summary>
    public enum input_type
    {
        param_value = 1,//设置参数
        coefficient = 2,//设置系数
        offset = 3,//设置偏移量
    }
    public class Panel_paraminput : N_bumpUI
    {
        private input_type type;
        public Action<int, string> _callback;
        public Action<int, string, string> _coe_off_back;
        //当前操作UI的索引值（itemid的后两位）
        [HideInInspector]
        public int control_ui_index;
        //输入的值
        string input_value;
        Text title, value, range;

        bool set_offset;

        protected override void Awake()
        {
            base.Awake();
            title = transform.Find("title").GetComponent<Text>();
            value = transform.Find("value").GetComponent<Text>();
            range = transform.Find("range").GetComponent<Text>();
        }
        protected override void Start()
        {
            base.Start();

        }
        public override void fn_show()
        {
             base.fn_show();
        }
        
        /// <summary>
        /// 按钮的点击
        /// 根据名称来保存输入信息
        /// </summary>
        /// <param name="go"></param>
        /// <param name="press"></param>
        protected override void fn_btn_press(GameObject go, bool press)
        {
            base.fn_btn_press(go, press);
            if (!press) return;
            switch (go.name)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    input_value += go.name;
                    value.text = input_value;
                    break;
                case "point":
                    input_value += ".";
                    value.text = input_value;
                    break;
                case "devide":
                    input_value += "-";
                    value.text = input_value;
                    break;
                case "back":
                    fnp_back();
                    break;
                case "esc":
                    fn_hide();
                    input_value = "";
                    break;
                case "enter":
                    fn_confirm();
                    break;

            }
        }

        private void fnp_back()
        {
             if (input_value.Length == 0 || input_value.Length==1)
             {
                  input_value = "";
                  value.text = input_value;
                  return;
             }
             input_value = input_value.Substring(0, input_value.Length - 1);
             value.text = input_value;
        }
        /// <summary>
        /// 确认面板的传值
        /// </summary>
        private void fn_confirm()
        {
            float temp;
            //如果输入值为空，隐藏界面，取消设置
            if (!float.TryParse(input_value, out temp))
            {
                fn_hide();
                return;
            }
            //泵的ID
            int _id = BumpUI_manager.Instance.current_bump_id;

            switch (type)
            {
                case input_type.param_value:
                    BumpParam_manager.Instance.fn_change_bump_param(_callback, _id, control_ui_index, input_value);
                    fn_hide();
                    break;
                case input_type.offset:
                    float offset = float.Parse(input_value);
                    BumpParam_manager.Instance.fn_set_param_offset(offset, _id, control_ui_index, _coe_off_back);
                    fn_hide();
                    break;
                case input_type.coefficient:
                    float coefficient = float.Parse(input_value);
                    BumpParam_manager.Instance.fn_set_param_coefficient(coefficient, _id, control_ui_index, _coe_off_back);
                    fn_hide();
                    break;
            }
        }


        public override void fn_hide()
        {
            base.fn_hide();
            fn_clear_info();
        }
        /// <summary>
        /// 设置参数信息的显示
        /// </summary>
        /// <param name="ui_index"></param>
        /// <param name="_call"></param>
        public void fn_set_info(int ui_index, Action<int, string> _call)
        {
            //string title=
            type = input_type.param_value;
            //根据ID后两位作为后缀去找到语言表格对应的语言
            string title_sign = "full_bump_param_name" + ui_index;
            UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, title_sign);
            if (lang != null)
            {
                title.text = lang.CurrentLan();
            }
            //确定回调函数
            _callback = _call;
            control_ui_index = ui_index;
            //显示参数当前值
            value.text = BumpParam_manager.Instance.fn_get_bump_param(BumpUI_manager.Instance.current_bump_id, ui_index);

            Vector2 param_range = BumpParam_manager.Instance.fn_get_unit_range(ui_index);
            //显示参数的数值范围
            range.text = param_range.x.ToString() + "~" + param_range.y.ToString();



        }
        /// <summary>
        /// 设置偏移量
        /// </summary>
        /// <param name="ui_index"></param>
        /// <param name="_call"></param>
        public void fn_set_offset(int ui_index, Action<int, string, string> _call)
        {
            control_ui_index = ui_index;
            type = input_type.offset;
            _coe_off_back = _call;
        }
        /// <summary>
        /// 设置系数值
        /// </summary>
        /// <param name="ui_index"></param>
        /// <param name="_call"></param>
        public void fn_set_coefficient(int ui_index, Action<int, string, string> _call)
        {
            control_ui_index = ui_index;
            type = input_type.coefficient;
            _coe_off_back = _call;
        }
        /// <summary>
        /// 清除信息
        /// </summary>
        private void fn_clear_info()
        {
            title.text = "";
            value.text = "";
            range.text = "";
            input_value = "";
            set_offset = false;
        }


    }
}
