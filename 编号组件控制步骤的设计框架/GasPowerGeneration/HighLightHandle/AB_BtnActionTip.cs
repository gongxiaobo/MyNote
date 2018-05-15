using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 这是提示用户的操作方式，是旋转了还是上下移动了
     /// </summary>
     public abstract class AB_BtnActionTip : MonoBehaviour
     {

          public abstract void fn_light();
          public abstract void fn_endLight();
          public E_ActionTip m_ActionTipName = E_ActionTip.e_null;
     } 
}
