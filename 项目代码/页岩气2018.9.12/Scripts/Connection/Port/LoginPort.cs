using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 注册电线接口到集合中
     /// </summary>
     public class LoginPort : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               S_Ports.Instance.fn_login(this.gameObject);
               Destroy(this);
          }

     } 
}
