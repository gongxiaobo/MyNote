using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using GasPowerGeneration;
namespace cdp
{
    //public class Panel_signal : N_CDPPanel
    //{

    //    private cdp_showitem[] itemarray=new cdp_showitem[3];
    //    //初始化时默认显示的参数信息设置
    //    public Vector2[] defaut_param = new Vector2[3];
    //    public Transform[] param_item = new Transform[3];
    //    /// <summary>
    //    /// 当前编辑参数索引
    //    /// </summary>
    //    public int edit_param_index=0;
    //    bool paramchange=true;
    //    // Use this for initialization
    //    protected override void Awake()
    //    {
    //        base.Awake();
    //        blink = TransformHelper.FindChild(transform, "blink");
    //    }
    //    public override void fn_show_panel()
    //    {
    //        base.fn_show_panel();
    //        edit_param_index = 0;
    //        if (paramchange == true)
    //        {
    //            for (int i = 0; i < 3; i++)
    //            {
    //                fn_showitem((int)defaut_param[i].x, (int)defaut_param[i].y);
    //                param_item[i].GetChild(0).GetComponent<Text>().text = itemarray[i].param_name;
    //                param_item[i].GetChild(1).GetComponent<Text>().text = itemarray[i].param_value;
    //                param_item[i].GetChild(2).GetComponent<Text>().text = itemarray[i].param_unit;
    //                edit_param_index++;
    //            }
    //            paramchange = false;
    //        }
    //        edit_param_index = 0;
    //        blink.position = param_item[edit_param_index].position;
    //        fn_effect_blink();
    //        //
    //    }
    //    /// <summary>
    //    /// 修改默认显示的参数
    //    /// </summary>
    //    /// <param name="itemindex">参数索引</param>
    //    /// <param name="groupindex"></param>
    //    /// <param name="name_index"></param>
    //    public void fn_changeitem( int groupindex, int name_index) {
    //        fn_showitem( groupindex, name_index);
    //        defaut_param[edit_param_index].x = groupindex;
    //        defaut_param[edit_param_index].y = name_index;
    //        paramchange = true;
    //    }
    //    /// <summary>
    //    /// 初始化时显示参数
    //    /// </summary>
    //    /// <param name="itemindex"></param>
    //    /// <param name="group_index"></param>
    //    /// <param name="name_index"></param>
    //    private void fn_showitem( int group_index, int name_index)
    //    {
    //        itemarray[edit_param_index] = new cdp_showitem(group_index, name_index);

    //    }

    //    public override void btn_up(bool press)
    //    {
    //        base.btn_up(press);
    //        if (press)
    //        {
    //            if (edit_param_index > 0)
    //            {
    //                fn_effect_blink();
    //                edit_param_index--;
    //                blink.position = param_item[edit_param_index].position;

    //            }
    //            else
    //            {
    //                //fn_stop_blink();
    //            }
    //        }
    //    }

    //    public override void btn_down(bool press)
    //    {
    //        base.btn_down(press);
    //        if (press)
    //        {
    //            if (edit_param_index < 3)
    //            {
    //                fn_effect_blink();
    //                edit_param_index++;
    //                blink.position = param_item[edit_param_index].position;

    //            }
    //            else
    //            {
    //                //fn_stop_blink();
    //            }
    //        }
    //    }

    //    public override void btn_enter(bool press)
    //    {
    //        base.btn_enter(press);
    //        if (press)
    //        {
    //            CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.state);
    //            changehandler = fn_changeitem;
    //            CDPctrl_manager.Instance.fn_panel_sendmsg(changehandler);
    //        }
    //    }
    //    public override void fn_effect_blink()
    //    {
    //        base.fn_effect_blink();
    //        handler += () =>
    //        {
    //            if ((int)Time.time % 2 == 0)
    //            {
    //                blink.gameObject.SetActive(true);
    //            }
    //            else
    //            {
    //                blink.gameObject.SetActive(false);
    //            }
    //        };
    //        StartCoroutine(update_data(1f));
    //    }
    //    /// <summary>
    //    /// 停止高亮
    //    /// </summary>
    //    public override void fn_stop_blink()
    //    {
    //        base.fn_stop_blink();
    //        blink.gameObject.SetActive(false);
    //    }
    //}
    public class Panel_signal : N_CDPPanel
    {

        private cdp_showitem[] itemarray = new cdp_showitem[2];
        //初始化时默认显示的参数信息设置
        public Vector2[] defaut_param = new Vector2[2];
        public Transform[] param_item = new Transform[2];
        protected Transform blink_rpm;
        protected Transform blink_param;

        protected Text stateinu_text;

        private bool edit_rpm;

        private I_CDPSet current_cdpinfo;
        /// <summary>
        /// 当前编辑参数索引
        /// </summary>
        public int edit_param_index = 0;
        bool paramchange = true;
        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            blink_rpm = TransformHelper.FindChild(transform, "blink_rpm");
            blink_param = TransformHelper.FindChild(transform, "blink");
            stateinu_text = TransformHelper.FindChild(transform, "stateinu").GetComponent<Text>(); ;

        }
        /// <summary>
        /// 显示界面时刷新信息
        /// </summary>
        public override void fn_show_panel()
        {
            base.fn_show_panel();
            //当默认参数发生改变时 刷新页面
            edit_param_index = 0;
            if (paramchange == true)
            {
                fn_update_paramshow();
            }
            //编辑参数归零
            edit_param_index = 0;

            //高亮位置重置
            blink = blink_param;
            blink.position = param_item[edit_param_index].position;
            stateinu_text.text = S_CDPControl.Instance.fn_getMemberValue(1003,1);
            //开始高亮
            fn_effect_blink();
            handler += fn_getstateinu_state;
         
            //
        }

        private void fn_update_paramshow() {
            for (int i = 0; i < 2; i++)
            {
                fn_showitem((int)defaut_param[i].x, (int)defaut_param[i].y);
                //param_item[i].GetChild(0).GetComponent<Text>().text = itemarray[i].param_name;


                Text name=param_item[i].GetChild(0).GetComponent<Text>();
                int namelength = itemarray[i].param_name.Length;
                name.text = namelength > 8 ? itemarray[i].param_name.Remove(8) : itemarray[i].param_name;
                param_item[i].GetChild(1).GetComponent<Text>().text = itemarray[i].param_value;
                param_item[i].GetChild(2).GetComponent<Text>().text = itemarray[i].param_unit;
                edit_param_index++;
            }
            paramchange = false;
        }
        /// <summary>
        /// 修改默认显示的参数
        /// </summary>
        /// <param name="itemindex">参数索引</param>
        /// <param name="groupindex"></param>
        /// <param name="name_index"></param>
        public void fn_changeitem(int groupindex, int name_index)
        {
            fn_showitem(groupindex, name_index);
            defaut_param[edit_param_index].x = groupindex;
            defaut_param[edit_param_index].y = name_index;
            paramchange = true;
        }
        /// <summary>
        /// 根据组名 参数id设置参数
        /// </summary>
        /// <param name="itemindex"></param>
        /// <param name="group_index"></param>
        /// <param name="name_index"></param>
        private void fn_showitem(int group_index, int name_index)
        {
            itemarray[edit_param_index] = new cdp_showitem(group_index, name_index);

        }

        public override void btn_up(bool press)
        {
            base.btn_up(press);
            if (!edit_rpm)
            {
                if (press)
                {
                    if (edit_param_index > 0)
                    {
                        // fn_effect_blink();
                        fni_level(3);
                        edit_param_index--;
                        blink.position = param_item[edit_param_index].position;

                    }
                    else
                    {
                        //fn_stop_blink();
                    }
                }
            }
            else {
                if (press)
                {
                    current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(1000, 1);
                    current_cdpinfo.fni_UpArrow_start(fn_paramvalue_change);
                }
                else
                {
                    current_cdpinfo.fni_UpArrow_end();
                    current_cdpinfo.fni_Confirm();
                }
            }
        }

        public override void btn_down(bool press)
        {
            base.btn_down(press);
            if (!edit_rpm)
            {
                if (press)
                {
                    if (edit_param_index < 1)
                    {
                        fni_level(3);
                        //fn_effect_blink();
                        edit_param_index++;
                        blink.position = param_item[edit_param_index].position;

                    }
                    else
                    {
                        //fn_stop_blink();
                    }
                }
            }
            else {
                if (press)
                {
                    current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(1000, 1);
                    current_cdpinfo.fni_DownArrow_start(fn_paramvalue_change);
                }
                else
                {

                    current_cdpinfo.fni_DownArrow_end();
                    current_cdpinfo.fni_Confirm();
                }
            }
        }
        public override void btn_upup(bool press)
        {
            base.btn_upup(press);
            
            if (edit_rpm)
            {
                if (press)
                {
                    current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(1000, 1);
                    current_cdpinfo.fni_DoubleUpArrow_start(fn_paramvalue_change);
                }
                else
                {
                    current_cdpinfo.fni_DoubleUpArrow_end();
                    current_cdpinfo.fni_Confirm();
                }
            }
            
        }
        public override void btn_downdown(bool press)
        {

            base.btn_downdown(press);
            if (edit_rpm)
            {
                if (press)
                {
                    current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(1000, 1);
                    current_cdpinfo.fni_DoubleDownArrow_start(fn_paramvalue_change);
                }
                else
                {
                    current_cdpinfo.fni_DoubleDownArrow_end();
                    current_cdpinfo.fni_Confirm();
                }
            }
           
        }

        public override void btn_enter(bool press)
        {
            base.btn_enter(press);
            if (press)
            {

                changehandler((int)defaut_param[edit_param_index].x, (int)defaut_param[edit_param_index].y);
                CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.state);
                changehandler = fn_changeitem;
                CDPctrl_manager.Instance.fn_panel_sendmsg(changehandler, cdp_panel_type.state);
            }
        }

        public override void btn_par(bool press)
        {
            base.btn_par(press);

            if (!press) return;
            if (!edit_rpm)
            {
                fn_cancelcurrentstate();
                CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.paramset);
            }
            else {
                fni_level(1);//界面切换到默认显示状态
                fn_stop_blink();
                blink = blink_param;
                fn_effect_blink();
                edit_rpm = false;
            }
        }

        public override void btn_ref(bool press)
        {
            base.btn_ref(press);
            if (!press) return;
            if (!edit_rpm)//如果rpm状态未编辑，进入编辑rpm模式
            {
                fni_level(4);//界面切换到转速控制状态
                fn_stop_blink();
                blink = blink_rpm;
                fn_effect_blink();
                edit_rpm = true;
            }
            else {
                fni_level(1);//界面切换到默认显示状态
                fn_stop_blink();
                blink = blink_param;
                fn_effect_blink();
                edit_rpm = false;
            }
        }


        public override void btn_act(bool press)
        {
            base.btn_act(press);
            if (!edit_rpm)
            {
                if (press)
                {
                    StartCoroutine(act_click_cal());//判断act按下时间



                }
                else
                {

                    StopCoroutine(act_click_cal());

                    if (act_press)
                    {
                        //按下act时间长时显示参数全称
                        fn_showshort_info();
                        act_press = false;
                        fni_level(1);//设置屏幕状态为显示
                    }
                    else
                    {//act按下时间短时触发单击效果
                        fn_cancelcurrentstate();
                        if (CDPctrl_manager.Instance.current_fault_group.Count == 0)
                            CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.historyfault);
                        else
                            CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.currentfault);
                    }
                }
            }
            else {
                fni_level(1);//界面切换到默认显示状态
                fn_stop_blink();
                blink = blink_param;
                fn_effect_blink();
                edit_rpm = false;
            }


            
        }

        public override void btn_func(bool press)
        {
            base.btn_func(press);
            if(!press)return;
            if(edit_rpm){
                fni_level(1);//界面切换到默认显示状态
                fn_stop_blink();
                blink = blink_param;
                fn_effect_blink();
                edit_rpm = false;
            }
        }

        public override void btn_drive(bool press)
        {
            base.btn_drive(press);
            if (!press) return;
            if (edit_rpm)
            {
                fni_level(1);//界面切换到默认显示状态
                fn_stop_blink();
                blink = blink_param;
                fn_effect_blink();
                edit_rpm = false;
            }
        }

        public override void btn_loc_rem(bool press)
        {
            base.btn_loc_rem(press);
            current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(1004, 1);
            if (press)
            { 
                if (current_cdpinfo.fni_getValue() == "L")
                    current_cdpinfo.fni_UpArrow_start(fn_local_remote_change);
                else {
                    current_cdpinfo.fni_DownArrow_start(fn_local_remote_change);
                }
            }
            else {
                current_cdpinfo.fni_DownArrow_end();
                current_cdpinfo.fni_Confirm();
            }
        }
        private bool act_press;

        private void fn_getstateinu_state() {
            stateinu_text.text = S_CDPControl.Instance.fn_getMemberValue(1003, 1);
        }
        private void fn_local_remote_change(string state) {
            local_remote.text = state;
        }
        IEnumerator act_click_cal() {
            yield return new WaitForSeconds(0.5f);
            fn_showcomplete_info();
            act_press = true;
            fni_level(2);//设置屏幕状态为显示全称

        }

        /// <summary>
        /// 显示完整数据名称
        /// </summary>
        private void fn_showcomplete_info() {
            for (int i = 0; i < 2; i++)
            {
                param_item[i].GetChild(0).GetComponent<Text>().text = itemarray[i].param_name;
                param_item[i].GetChild(1).GetComponent<Text>().text = "";
                param_item[i].GetChild(2).GetComponent<Text>().text = "";

            }
        }
        /// <summary>
        /// 显示数据名称简写
        /// </summary>
        private void fn_showshort_info() {
            for (int i = 0; i < 2; i++)
            {
                Text name = param_item[i].GetChild(0).GetComponent<Text>();
                int namelength = itemarray[i].param_name.Length;
                name.text = namelength > 8 ? itemarray[i].param_name.Remove(8) : itemarray[i].param_name;
                param_item[i].GetChild(1).GetComponent<Text>().text = itemarray[i].param_value;
                param_item[i].GetChild(2).GetComponent<Text>().text = itemarray[i].param_unit;

            }
        }
        /// <summary>
        /// 高亮
        /// </summary>
        public override void fn_effect_blink()
        {
            base.fn_effect_blink();
            handler += fn_blink_mode;

            StartCoroutine(update_data(1f));
        }
        /// <summary>
        /// 停止高亮
        /// </summary>
        public override void fn_stop_blink()
        {
            base.fn_stop_blink();
            blink.gameObject.SetActive(false);
            handler -= fn_blink_mode;
        }
        public override void fn_changepanelmsg(ChangeHandler changehandler)
        {
            base.fn_changepanelmsg(changehandler);
            this.changehandler = changehandler;

        }

        /// <summary>
        /// 界面参数变化显示
        /// </summary>
        /// <param name="value"></param>
        private void fn_paramvalue_change(string value)
        {
            rpm_text.text = value;
        }
        /// <summary>
        /// 取消当前状态
        /// </summary>
        protected override void fn_cancelcurrentstate()
        {
            base.fn_cancelcurrentstate();
            fn_stop_blink();
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