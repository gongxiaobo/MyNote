using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public interface I_paramshow
     {
          void fn_show_param(int value);

          void fn_show_param(float value);

          void fn_show_unit();

          RectTransform fn_getrect();
     } 
}
