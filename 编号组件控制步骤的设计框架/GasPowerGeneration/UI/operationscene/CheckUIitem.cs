using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 提示UI项
     /// </summary>
     public class CheckUIitem : MonoBehaviour
     {
          #region
          //public Text name;
          //public Text state;
          //private Trigger_choosebtn correct;
          //private Trigger_choosebtn error;
          //private N_HandleEvent_init thishandler;
          //void Start() {
          //    name = transform.GetChild(0).GetComponent<Text>();
          //    state = transform.GetChild(1).GetComponent<Text>();
          //    correct = transform.GetChild(2).GetComponent<Trigger_choosebtn>();
          //    error = transform.GetChild(3).GetComponent<Trigger_choosebtn>();
          //    correct.onClick += fn_choose_correct;
          //    error.onClick += fn_choose_error;
          //}

          //public void fn_init(N_HandleEvent_init handler)
          //{
          //    thishandler = handler;
          //    name.text = handler.ID.m_ID.ToString();//后面修改 根据读表显示内容
          //    switch (handler.GetComponent<N_state>().m_ItemValueType) { 
          //        case E_valueType.e_inter_floatvalue:
          //            state.text = ((StateValueString)handler.fn_get("floatvalue")).m_date;
          //            break;
          //        case E_valueType.e_inter_onoff:
          //            state.text = ((StateValueString)handler.fn_get("onoff")).m_date;
          //            break;
          //        case E_valueType.e_inter_level:
          //            state.text = "";
          //            break;

          //    }
          //    string checktype=handler.fn_get("check").Type;
          //    if ( checktype== "correct")
          //        correct.GetComponent<Image>().color = Color.green;
          //    else if(checktype=="error")
          //        error.GetComponent<Image>().color = Color.green;

          //}

          //public void fn_choose_correct(GameObject go) {
          //    btn_reset();
          //    CheckUImanager.Instance.fn_changehandlerstate(thishandler, "correct");
          //    correct.GetComponent<Image>().color = Color.green;
          //}
          //public void fn_choose_error(GameObject go) {
          //    btn_reset();
          //    CheckUImanager.Instance.fn_changehandlerstate(thishandler, "error");
          //    error.GetComponent<Image>().color = Color.green;
          //}
          //private void btn_reset() {
          //    correct.GetComponent<Image>().color = Color.white;
          //    error.GetComponent<Image>().color = Color.white;
          //}
          #endregion



          public Text name;
          //public Text state;
          private Trigger_choosebtn correct;
          private Trigger_choosebtn error;
          private int thishandler_id;
          private I_CheckValue get_info;

          void Start()
          {
               name = TransformHelper.FindChild(transform, "name").GetComponent<Text>();
               //state = transform.GetChild(1).GetComponent<Text>();
               correct = TransformHelper.FindChild(transform, "correct").GetComponent<Trigger_choosebtn>();
               error = TransformHelper.FindChild(transform, "error").GetComponent<Trigger_choosebtn>();
               correct.onClick += fn_choose_correct;
               error.onClick += fn_choose_error;
               get_info = S_SceneMagT1.Instance;
          }
          /// <summary>
          /// 生成item项信息
          /// </summary>
          /// <param name="handler_id"></param>
          public void fn_init(int handler_id)
          {
               thishandler_id = handler_id;
               name.text = handler_id.ToString();//后面修改 根据读表显示内容
               AB_Message t_sceneMsg = S_SceneMessage.Instance.fn_getMsg("sceneMsg");
               //加载itemname表格 显示物体信息
               if (t_sceneMsg != null)
               {
                    string itemtable_name = ((StateValueString)t_sceneMsg.fn_getContent("item_name")).m_date;
                    UpdateLanguage(itemtable_name, handler_id);

               }
               string checktype = S_SceneMagT1.Instance.fni_checkDate(handler_id, E_StateValueType.e_check);
               btn_reset();
               if (checktype == "right")
                    correct.GetComponent<Image>().color = Color.white;
               else if (checktype == "error")
                    error.GetComponent<Image>().color = Color.white;

          }
          /// <summary>
          /// 更新语言
          /// </summary>
          /// <param name="itemtable_name"></param>
          /// <param name="handler_id"></param>
          private void UpdateLanguage(string itemtable_name, int handler_id)
          {
               if (S_SceneMessage.Instance.fn_getLanguage() == "Chinese")
                    name.text = S_LoadTable.Instance.fn_getItemName(itemtable_name, handler_id).m_ch_name;
               else
                    name.text = S_LoadTable.Instance.fn_getItemName(itemtable_name, handler_id).m_en_name;
          }
          /// <summary>
          /// 选择正确按钮
          /// </summary>
          /// <param name="go"></param>
          public void fn_choose_correct(GameObject go)
          {
               btn_reset();
               CheckUImanager.Instance.fn_changehandlerstate(thishandler_id, "right");
               correct.GetComponent<Image>().color = Color.white;
          }
          /// <summary>
          /// 选择错误按钮
          /// </summary>
          /// <param name="go"></param>
          public void fn_choose_error(GameObject go)
          {
               btn_reset();
               CheckUImanager.Instance.fn_changehandlerstate(thishandler_id, "error");
               error.GetComponent<Image>().color = Color.white;
          }
          /// <summary>
          /// 按钮状态重置
          /// </summary>
          /// <param name="go"></param>
          private void btn_reset()
          {
               correct = TransformHelper.FindChild(transform, "correct").GetComponent<Trigger_choosebtn>();
               error = TransformHelper.FindChild(transform, "error").GetComponent<Trigger_choosebtn>();
               correct.GetComponent<Image>().color = name.color;
               error.GetComponent<Image>().color = name.color;
          }

     }

}