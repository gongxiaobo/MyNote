using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
    public interface I_bumpshowparam
    {

        int param_index { get; }

        void fn_set_value(string value);
    }
}