using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 namespace GasPowerGeneration
{
    public interface I_bumpparam
    {

    int param_id { get;  }
    void fn_update_param(Action<int, string> _call, int bumpid);
    Vector2 fn_get_unit_range(Action<Vector2> unit_range=null);
    void fn_set_param(Action<int, string> set_call, int bumpid,bool value);
    void fn_set_param(Action<int, string> set_call, int bumpid,float value);
    string fn_get_param_value();
    }
}