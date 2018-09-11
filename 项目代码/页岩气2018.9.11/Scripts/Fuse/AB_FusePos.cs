using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器的绑定位置
     /// </summary>
     public abstract class AB_FusePos : MonoBehaviour
     {

          public E_FusePosName m_fusePosName = E_FusePosName.e_null;
          public abstract GameObject fn_getConnect(E_FusePosName _name);

     } 
}
