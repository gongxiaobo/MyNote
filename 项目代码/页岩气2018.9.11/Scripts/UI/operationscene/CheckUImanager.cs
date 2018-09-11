using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     /// <summary>
     /// 判断提示UI管理类
     /// </summary>
     public class CheckUImanager : GenericSingletonClass<CheckUImanager>
     {

          #region
          //List<int> current_handlers = new List<int>();
          //private GameObject head;
          //private Canvas ui_canvas;
          //private CheckUIitem item;
          //private GameObject[] temps;
          //// Use this for initialization
          //void Start()
          //{
          //    ui_canvas = GetComponentInChildren<Canvas>();
          //    head = GameObject.Find("Camera (eye)");
          //    item = TransformHelper.FindChild(transform, "item").GetComponent<CheckUIitem>();
          //}
          ///// <summary>
          ///// 接收需要处理的handler
          ///// </summary>
          ///// <param name="handlers"></param>
          //public void fn_recive_handlers(List<N_HandleEvent_init> handlers)
          //{
          //    if (handlers == null) return;
          //    if (current_handlers.Count > 0)
          //    {
          //        print(current_handlers.Count);
          //        current_handlers.Clear();
          //    }
          //    print("收到handlers");
          //    foreach (var item in handlers)
          //    {
          //        current_handlers.Add(item);
          //    }
          //}


          ///// <summary>
          ///// 确定手部位置 显示ui
          ///// </summary>
          ///// <param name="trans"></param>
          //public void fn_checkhandpos(Transform trans)
          //{
          //    fn_showUI(trans);
          //}
          ///// <summary>
          ///// 隐藏UI
          ///// </summary>
          //public void fn_hideUI()
          //{
          //    if (ui_canvas.gameObject.activeSelf==true)
          //      ui_canvas.gameObject.SetActive(false);
          //}

          //private void fn_showUI(Transform handpos)
          //{
          //    fn_move_target(handpos);
          //    ui_canvas.gameObject.SetActive(true);
          //    if (current_handlers.Count == 1) {
          //        item.fn_init(current_handlers.ToArray()[0]);
          //    }
          //    else if (current_handlers.Count > 1) {

          //        N_HandleEvent_init[] array=current_handlers.ToArray();
          //        print(array.Length);
          //        item.fn_init(array[0]);
          //        temps = new GameObject[array.Length-1];
          //        for (int i = 1; i < array.Length; i++)
          //        {
          //            GameObject temp = GameObject.Instantiate(item.gameObject, item.transform.parent);
          //            temp.GetComponent<CheckUIitem>().fn_init(array[i]);
          //            temps[i] = temp;
          //        }
          //    }
          //    //Invoke("fn_hideUI", current_handlers.Count * 3);
          //}
          ///// <summary>
          ///// 修改handler的状态值
          ///// </summary>
          ///// <param name="handler"></param>
          ///// <param name="state"></param>
          //public void fn_changehandlerstate(N_HandleEvent_init handler, string state)
          //{
          //    handler.fn_set(new StateValueString("check", state));

          //    foreach (var item in current_handlers)
          //    {
          //        print(((StateValueString)item.fn_get("check")).m_date);
          //        //if (((StateValueString)item.fn_get("check")).m_date == "idle")
          //        //{

          //        //    return;
          //        //}
          //    }
          //    //fn_hideUI();
          //}

          ///// <summary>
          ///// 移动到手部位置目标点   根据UI效果待修改
          ///// </summary>
          ///// <param name="trans"></param>
          //private void fn_move_target(Transform trans)
          //{
          //    if (trans.position != null && head != null)
          //    {
          //        transform.position = trans.position;
          //        transform.LookAt(head.transform);
          //    }
          //}
          #endregion


          List<int> current_handlers = new List<int>();
          private GameObject head;
          private Canvas ui_canvas;
          private CheckUIitem item;
          private GameObject[] temps;
          private Transform bottom;
          private Transform uipos;

          private GuideLine guideline;
          // Use this for initialization
          void Start()
          {
               ui_canvas = GetComponentInChildren<Canvas>();
               head = GameObject.Find("Camera (eye)");
               item = TransformHelper.FindChild(transform, "item").GetComponent<CheckUIitem>();
               bottom = TransformHelper.FindChild(transform, "bottom");
               guideline = GetComponent<GuideLine>();
               transform.DOScale(new Vector3(0, 0, 0), 0.1f);
          }
          /// <summary>
          /// 接收需要处理的handler
          /// </summary>
          /// <param name="handlers"></param>
          public void fn_recive_handlers(List<int> handlers)
          {
               if (handlers == null) return;
               if (current_handlers.Count > 0)
               {
                    print(current_handlers.Count);
                    current_handlers.Clear();
                    if (temps != null)
                    {
                         foreach (var item in temps)
                         {
                              Destroy(item);
                         }
                    }
               }
               //print("收到handlers");
               foreach (var item in handlers)
               {
                    current_handlers.Add(item);
               }
          }


          /// <summary>
          /// 确定手部位置 显示ui
          /// </summary>
          /// <param name="trans"></param>
          public void fn_checkhandpos(Transform trans)
          {
               if (trans == null)
                    print("<color=blue>物体下没有找到checkuipos</color>");
               if (uipos == trans)
               {
                    uipos = null;
                    fn_hideUI();
               }
               else
               {
                    uipos = trans;
                    fn_showUI(trans);
               }
          }
          /// <summary>
          /// 隐藏UI
          /// </summary>
          public void fn_hideUI()
          {

               if (ui_canvas.gameObject.activeSelf == true)
               {
                    guideline.fn_hideline();
                    transform.DOScale(new Vector3(0, 0, 0), 0.1f);

                    ui_canvas.gameObject.SetActive(false);
               }

          }
          /// <summary>
          /// 显示UI
          /// </summary>
          /// <param name="uipos"></param>
          private void fn_showUI(Transform uipos)
          {

               guideline.fn_hideline();
               ui_canvas.gameObject.SetActive(true);
               if (bottom != null)
                    bottom.SetParent(item.transform.parent.parent);
               if (current_handlers.Count == 1)
               {
                    item.fn_init(current_handlers.ToArray()[0]);

               }
               else if (current_handlers.Count > 1)
               {

                    int[] array = current_handlers.ToArray();
                    print(array.Length);
                    item.fn_init(array[0]);
                    temps = new GameObject[array.Length];
                    for (int i = 1; i < array.Length; i++)
                    {
                         GameObject temp = GameObject.Instantiate(item.gameObject, item.transform.parent);
                         temp.GetComponent<CheckUIitem>().fn_init(array[i]);
                         temps[i] = temp;

                    }


               }
               if (bottom != null)
               {
                    bottom.SetParent(item.transform.parent);
                    bottom.localScale = item.transform.localScale;
               }
               fn_move_target(uipos);
               //Invoke("fn_hideUI", 1);
          }
          /// <summary>
          /// 修改handler的状态值
          /// </summary>
          /// <param name="handler"></param>
          /// <param name="state"></param>
          public void fn_changehandlerstate(int handler_id, string state)
          {
               AB_Message message = new N_Message();
               StateValueString check_state = new StateValueString("check", state);


               message.fn_init(E_MessageType.e_outside, new StateValue[1] { check_state }, "check", 0, handler_id);
               print("<color=red>修改id为:</color>" + handler_id + "<color=red>的item的check状态为</color>" + state);
               S_SceneMagT1.Instance.fn_ReceiveEvent(message);
          }

          /// <summary>
          /// 移动到手部位置目标点   根据UI效果待修改
          /// </summary>
          /// <param name="uipos"></param>
          private void fn_move_target(Transform uipos)
          {
               if (uipos.position != null && head != null)
               {

                    transform.position = uipos.position;
                    transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f);
                    transform.LookAt(head.transform);
                    Vector3 temp = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(new Vector3(0, temp.y, temp.z));
                    guideline.fn_showline(uipos, uipos.parent);
               }
          }


     }

}