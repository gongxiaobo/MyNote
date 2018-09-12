using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.test.Optimization
{
     
     public class testOptimization : MonoBehaviour
     {
          void Start()
          {
               //Invoke("fn_setPlayer", 1f);
               S_OpMesh.Instance.Player = this.gameObject.transform;
               
               Debug.Log("<color=red>把玩家位置加入到优化管理类中</color>");
     
          }
          protected void fn_setPlayer()
          {
               S_OpMesh.Instance.Player = this.gameObject.transform;
          }
          protected bool m_hide = false;
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.H))
               {

                    S_OpMesh.Instance.fn_HideOrShow("10kv", !m_hide);
                    m_hide = !m_hide;
                    
                    //Debug.Log("<color=blue>操作</color>");
     
               }
          }
     }
}
