using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.ConnectLimit
{
     /// <summary>
     /// 对接口或者划片类型进行限制操作
     /// </summary>
     class N_ClosePortOrSlice : MonoBehaviour
     {
          void Start()
          {
               if (s_ConnectLimit.fn_canTrigger(GetComponent<AB_HandleEvent>())==false)
               {//限制操作
                    BoxCollider t_box = GetComponent<BoxCollider>();
                    if (t_box!=null)
                    {
                         t_box.enabled = false;
                    }
               }
               Destroy(this);
          }
     }
}
