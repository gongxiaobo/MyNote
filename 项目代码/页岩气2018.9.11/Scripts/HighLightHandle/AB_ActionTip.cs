using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_ActionTip : MonoBehaviour
     {
          public abstract void fn_show(E_ActionTip _tip);
          public abstract void fn_hide(E_ActionTip _tip);
          public abstract void fn_hide();
     }
     public enum E_ActionTip
     {
          e_null = 0,
          e_trigger = 1,
          e_pad = 2,
          e_rotate = 3,
     } 
}
