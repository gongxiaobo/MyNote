using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.TableMode;
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
               if (S_SceneMessage.Instance.m_TableMode== E_TableMode.e_learn)
               {//训练模式下，关闭操作
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
