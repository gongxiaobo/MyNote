using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// panel节点下的总体管理类
     /// 初始化交互触发器
     /// 初始化语言
     /// 初始化单位
     /// </summary>
     public class N_bumpUI : AB_bumpUI, I_hideBoxCollider
     {
          protected List<I_bumpshowparam> show_params = new List<I_bumpshowparam>();

          public e_bump_ui_panel panel_type;

          protected virtual void Awake()
          {
               rect = GetComponent<RectTransform>();
          }

          protected virtual void Start()
          {
               //找到这个节点下的交互触发器
               fn_get_triggers(transform);
               //找到这个节点下的语言切换接口
               fn_find_all_lang_text(transform);
               //找到这个节点下的单位切换接口
               fn_find_all_unit_text(transform);

               foreach (var item in triggers)
               {//为每个交互触发器添加触发委托事件
                    item.onPress += fn_btn_press;
               }
               //语言更新
               fn_updatelan();
               fnp_findUIBoxCollider();
          }


          #region 找到触发器，单位，语言
          /// <summary>
          /// 找到panel下所有A_trigger （按钮或交互物体）
          /// </summary>
          /// <param name="trans"></param>
          protected override void fn_get_triggers(Transform trans)
          {
               ////递归查找所有子物体
               //Trigger_bumpui trg = trans.GetComponent<Trigger_bumpui>();
               //if (trg != null && !triggers.Contains(trg)) triggers.Add(trg);
               //for (int i = 0; i < trans.childCount; i++)
               //{
               //    trg = trans.GetChild(i).GetComponent<Trigger_bumpui>();
               //    if (trg != null && !triggers.Contains(trg))
               //        triggers.Add(trg);
               //    fn_get_triggers(trans.GetChild(i));

               //}
               triggers = trans.FindInChlid<Trigger_bumpui>();



          }
          protected override void fn_find_all_lang_text(Transform trans)
          {
               ////递归查找所有子物体
               //I_language lang = trans.GetComponent<I_language>();
               //if (lang != null && !langs.Contains(lang)) langs.Add(lang);
               //for (int i = 0; i < trans.childCount; i++)
               //{
               //    lang = trans.GetChild(i).GetComponent<I_language>();
               //    if (lang != null && !langs.Contains(lang))
               //        langs.Add(lang);
               //    fn_find_all_lang_text(trans.GetChild(i));

               //}
               langs = trans.FindInChlid<I_language>();
          }
          protected override void fn_find_all_unit_text(Transform trans)
          {
               ////递归查找所有子物体
               //I_unit unit = trans.GetComponent<I_unit>();
               //if (unit != null && !units.Contains(unit)) units.Add(unit);
               //for (int i = 0; i < trans.childCount; i++)
               //{
               //    unit = trans.GetChild(i).GetComponent<I_unit>();
               //    if (unit != null && !units.Contains(unit))
               //        units.Add(unit);
               //    fn_find_all_unit_text(trans.GetChild(i));

               //}
               units = trans.FindInChlid<I_unit>();
          }
          #endregion
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
          public override void fn_updatelan()
          {
               foreach (var item in langs)
               {
                    Text text = item.fn_get_item_text();
                    if (text != null)
                    {
                         //根据名称找到表中的语言项
                         UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(
                              UIdata.ui_table_name, item.fn_get_language_item());

                         if (lang != null)
                         {//获取当前语言,这是根据泵的界面来切换语言
                              string t_lg = BumpUI_manager.Instance.m_bumpLanguage == "ch" ? 
                                   lang.Firstlan : lang.Secondlan;
                              text.text = t_lg;
                              //text.text = lang.CurrentLan();

                         }
                    }

               }
          }


          public override void fn_show()
          {
               rect.localScale = Vector3.one;
               fn_updatelan();
          }
          public override void fn_hide()
          {
               rect.localScale = Vector3.zero;
          }
          /// <summary>
          /// 更新执行,间隔一段时间
          /// </summary>
          /// <param name="time_interval"></param>
          /// <returns></returns>
          protected IEnumerator update_data(float time_interval)
          {

               while (fn_update_handler != null)
               {
                    fn_update_handler();
                    yield return new WaitForSeconds(time_interval);
               }
          }
          /// <summary>
          /// 更新时间信息
          /// </summary>
          /// <param name="seconds"></param>
          public virtual void fn_update_time(int seconds) { }


          /// <summary>
          /// 更新显示参数，根据item id 来更新表盘现在的显示值
          /// </summary>
          /// <param name="item_id"></param>
          /// <param name="value"></param>
          protected virtual void fn_updateto_current_bump(int item_id, string value)
          {
               foreach (var item in show_params)
               {
                    if (item.param_index == int.Parse(item_id.ToString().Substring(2, 2)))
                    {
                         item.fn_set_value(value);
                    }
               }
          }
          /// <summary>
          /// 所有的boxcollider
          /// </summary>
          List<BoxCollider> m_boxColliders = new List<BoxCollider>();
          protected virtual void fnp_findUIBoxCollider()
          {
               m_boxColliders = transform.FindInChlid<BoxCollider>();
          }

          public void fni_hideBoxeCollider(bool _bl)
          {
               foreach (BoxCollider box in m_boxColliders)
               {
                    box.enabled = _bl;
               }
          }
     }
}