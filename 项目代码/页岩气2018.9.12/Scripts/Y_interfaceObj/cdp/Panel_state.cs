using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdp;
using GasPowerGeneration;
public class Panel_state : Panel_paramset
{


    private cdp_showitem show_item;
	// Use this for initialization

    protected override void Start()
    {
        base.Start();
        changehandler = fn_init_info;
        CDPctrl_manager.Instance.fn_panel_sendmsg(changehandler, cdp_panel_type.signal);
    }
    public override void btn_enter(bool press)
    {
        if (press)
        {
            changehandler(group_index, param_index);
            CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
            fni_level(2);
            changehandler = fn_init_info;
            CDPctrl_manager.Instance.fn_panel_sendmsg(changehandler, cdp_panel_type.signal);
        }
    }
    public override void btn_act(bool press)
    {
        base.btn_act(press);
        fn_cancelcurrentstate();
        CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
    }
    public override void btn_par(bool press)
    {
        base.btn_par(press);
        fn_cancelcurrentstate();
        CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
    }
    public override void btn_drive(bool press)
    {
        base.btn_drive(press);
        fn_cancelcurrentstate();
        CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
    }
    public override void btn_func(bool press)
    {
        base.btn_func(press);
        fn_cancelcurrentstate();
        CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
    }

    public override void fn_show_panel()
    {
        base.fn_show_panel();
    }
    public void fn_init_info(int group_index,int param_index)
    {
        this.group_index = group_index;
        this.param_index = param_index;
        
        group_name.text = S_CDPControl.Instance.fn_getGroupName(group_index);
        param_name.text = S_CDPControl.Instance.fn_getMemberName(group_index, param_index);
        param_value.text = S_CDPControl.Instance.fn_getMemberValue(group_index, param_index);
        param_unit.text = S_CDPControl.Instance.fn_getMemberUnit(group_index, param_index);
        print(group_name.text + "____" + param_name.text + "____" + param_value.text + "____" + param_unit.text);
    }

   protected override void fn_cancelcurrentstate() {
        handler = null;
    }

    public override void fn_changepanelmsg(ChangeHandler changehandler)
    {
        base.fn_changepanelmsg(changehandler);
        this.changehandler = changehandler;
        fni_level(0);

    }

    public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
    {
        base.fni_level(_level, _controlType);
        StateValueString state = (StateValueString)m_handler.fn_get("level");
        state.m_date = _level.ToString();
        m_handler.fn_set(state);
    }
}
