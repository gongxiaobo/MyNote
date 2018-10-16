using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdp;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class N_handpanel : AB_handpanel
     {

          public UpdateHandler update_handler;

          public e_hand_ui_panel panel_type;

          protected GameObject handui;
          protected virtual void Awake()
          {
               rect = GetComponent<RectTransform>();
               handui = GameObject.Find("HandUI").gameObject;
          }

          protected virtual void Start()
          {
              

               fn_get_triggers(transform);
               foreach (var item in triggers)
               {
                    item.onPress += fn_btn_press;
               }
               fn_update_lan();
          }


          /// <summary>
          /// 找到panel下所有A_trigger （按钮或交互物体）
          /// </summary>
          /// <param name="trans"></param>
          protected override void fn_get_triggers(Transform trans)
          {
               //递归查找所有子物体
               Trigger_handui trg = trans.GetComponent<Trigger_handui>();
               if (trg != null && !triggers.Contains(trg)) triggers.Add(trg);
               for (int i = 0; i < trans.childCount; i++)
               {
                    trg = trans.GetChild(i).GetComponent<Trigger_handui>();
                    if (trg != null && !triggers.Contains(trg))
                         triggers.Add(trg);
                    fn_get_triggers(trans.GetChild(i));

               }


          }
          /// <summary>
          /// 按钮按下方法
          /// </summary>
          /// <param name="go"></param>
          /// <param name="press"></param>
          protected virtual void fn_btn_press(GameObject go, bool press)
          {
          }
          /// <summary>
          /// 更新语言信息
          /// </summary>
          public override void fn_update_lan()
          {
               foreach (var item in triggers)
               {

                    Text text = item.GetComponentInChildren<Text>();
                    if (text != null)
                    {
                         UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, item.name);

                         if (lang != null)
                         {
                              text.text = lang.CurrentLan();
                         }
                    }

               }
          }

          public override void fn_show()
          {
               rect.localScale = Vector3.one;
               fn_update_lan();
          }
          public override void fn_hide()
          {
               rect.localScale = Vector3.zero;
          }
          /// <summary>
          /// 更新执行
          /// </summary>
          /// <param name="time_interval"></param>
          /// <returns></returns>
          protected IEnumerator update_data(float time_interval)
          {

               while (update_handler != null)
               {
                    update_handler();
                    yield return new WaitForSeconds(time_interval);
               }
          }
          /// <summary>
          /// 更新时间信息
          /// </summary>
          /// <param name="seconds"></param>
          public virtual void fn_update_time(int seconds) { }
     }


}