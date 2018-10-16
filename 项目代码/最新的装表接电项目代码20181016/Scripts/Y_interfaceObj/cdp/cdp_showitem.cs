using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
public class cdp_showitem  {

    public string param_group { get; set; }

    public string param_name { get; set; }

    public string param_value { get; set; }

    public string param_unit { get; set; }

    public cdp_showitem(int group_index, int name_index) {
        param_group = S_CDPControl.Instance.fn_getGroupName(group_index);
        param_name = S_CDPControl.Instance.fn_getMemberName(group_index, name_index);
        param_value = S_CDPControl.Instance.fn_getMemberValue(group_index, name_index);
        param_unit = S_CDPControl.Instance.fn_getMemberValueWithUnit(group_index, name_index);
    }

    public string fn_getparam_value()
    {
        return "";
    }
}
