using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace GasPowerGeneration
{
    public class Panel_bumpparamset : N_bumpUI
    {
        private Text set_text;
        protected override void Start()
        {
            base.Start();
            fn_findall_showparam(transform);
            Invoke("Init", 4f);
        }
        void Init()
        {
            BumpParam_manager.Instance.fn_change_select_bump(fn_updateto_current_bump, 1);
        }

        protected override void fn_btn_press(GameObject go, bool press)
        {
            base.fn_btn_press(go, press);
            if (!press) return;
            AB_showbumpparam param = go.GetComponent<AB_showbumpparam>();
            if (param == null)
                param = go.GetComponentInParent<AB_showbumpparam>();
            int btn_index = 0;
            if (param != null)
                btn_index = param.index;

           
            switch (go.name) { 
                case "coefficient":
                    //BumpUI_manager.Instance.fn_show_set_panel(fn_set_offset, btn_index);
                    set_text = go.GetComponentInChildren<Text>();
                    BumpUI_manager.Instance.fn_show_set_panel(fn_set_coefficient, btn_index,input_type.coefficient);
                    break;
                case "offset":
                    set_text = go.GetComponentInChildren<Text>();
                    BumpUI_manager.Instance.fn_show_set_panel(fn_set_offset, btn_index,input_type.offset);
                    break;

                case "4":
                case "4.5":
                case "5":
                    BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id, btn_index, go.name);
                    break;
                case "back":
                    fn_hide();
                    break;
            }
        }
        private void fn_findall_showparam(Transform trans)
        {
            //递归查找所有子物体
            I_bumpshowparam param = trans.GetComponent<I_bumpshowparam>();
            if (param != null && !show_params.Contains(param)) show_params.Add(param);
            for (int i = 0; i < trans.childCount; i++)
            {
                param = trans.GetChild(i).GetComponent<I_bumpshowparam>();
                if (param != null && !show_params.Contains(param))
                    show_params.Add(param);
                fn_findall_showparam(trans.GetChild(i));

            }
        }
        public void fn_set_offset(int item_index, string value, string offset_value)
        {
            foreach (var item in show_params)
            {
                if (item.param_index == item_index)
                {
                        item.fn_set_value(value);
                        set_text.text = offset_value;
              
                }
            }
            BumpParam_manager.Instance.fn_update_bump_page();
        }
        public void fn_set_coefficient(int item_index, string value, string coefficient_vale)
        {
            foreach (var item in show_params)
            {
                if (item.param_index == item_index)
                {
                    item.fn_set_value(value);
                    set_text.text = coefficient_vale;
                }
            }
            BumpParam_manager.Instance.fn_update_bump_page();
        }
    }
}