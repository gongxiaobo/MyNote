using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 开门关门在开始运行时关闭，在渲染时和编辑场景处于打开模式
     /// </summary>
     public class N_CloseStart : MonoBehaviour
     {
          public bool m_AutoOpen = false;
          // Use this for initialization
          void Start()
          {
               transform.localRotation = Quaternion.identity;
               if (m_AutoOpen)
               {
                    Invoke("fnp_setDoorOpen", 1.5f);
               }
               else
               {
                    Destroy(this);
               }

          }
          protected void fnp_setDoorOpen()
          {
               AB_Spanner t_spanner = GetComponent<AB_Spanner>();
               if (t_spanner != null)
               {
                    t_spanner.fn_setTo(1f);
                    t_spanner = null;
               }
               //Destroy(this);
          }
          //// Update is called once per frame
          //void Update () {

          //}
          public void fn_OpenDoor()
          {
               AB_Spanner t_spanner = GetComponent<AB_Spanner>();
               if (t_spanner != null)
               {
                    t_spanner.fn_setTo(0f);
                    t_spanner = null;
               }
          }
          public void fn_CloseDoor()
          {
                 AB_Spanner t_spanner = GetComponent<AB_Spanner>();
               if (t_spanner != null)
               {
                    t_spanner.fn_setTo(1f);
                    t_spanner = null;
               }
          }
     } 
}
