using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.ConnectLimit
{
     class N_CloseUI : MonoBehaviour
     {
          void Start()
          {
               if (s_ConnectLimit.fn_canUITrigger() == false)
               {//限制操作
                    BoxCollider t_box = GetComponent<BoxCollider>();
                    if (t_box != null)
                    {
                         t_box.enabled = false;
                    }
               }
               Destroy(this);
          }


     }
}
