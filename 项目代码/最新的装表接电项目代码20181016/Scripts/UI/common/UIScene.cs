using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace GasPowerGeneration
{
     /// <summary>
     /// UI的管理父类
     /// </summary>
     public class UIScene : MonoBehaviour
     {

          protected string mUIName = "";
          //最基本的控制UI项 dic<name,UISceneWidget>
          public Dictionary<string, UISceneWidget> mUIWidgets = new Dictionary<string, UISceneWidget>();

          protected virtual void Start()
          {
               this.FindChildWidgets(gameObject.transform);
               UpdateLanguage();

          }

          protected virtual void OnEnable()
          {
               UpdateLanguage();
               if (mUIWidgets != null)
               {
                    fn_forbid_all_btns();
                    Invoke("fn_enable_all_btns", 1f);
               }
          }
          public virtual bool IsVisible()
          {
               return gameObject.activeSelf;
          }
          /// <summary>
          /// 设置这个物体的显示和隐藏
          /// 显示时更新语言
          /// </summary>
          /// <param name="visible"></param>
          public virtual void SetVisible(bool visible)
          {

               gameObject.SetActive(visible);
               if (visible == true)
                    UpdateLanguage();
          }
          /// <summary>
          /// 根据名称获取UI项的控制组件UISceneWidget
          /// </summary>
          /// <param name="name"></param>
          /// <returns></returns>
          public UISceneWidget GetWidget(string name)
          {

               if (mUIWidgets.ContainsKey(name))
                    return mUIWidgets[name];


               Transform t = gameObject.transform.Find(name);
               if (t == null) return null;

               UISceneWidget widget = t.gameObject.GetComponent<UISceneWidget>();
               if (widget != null)
               {
                    mUIWidgets.Add(widget.gameObject.name, widget);
                    return widget;
               }
               else
               {
                    return null;
               }

          }

          /// <summary>
          /// 找到这个节点下的管理子类
          /// </summary>
          /// <param name="t"></param>
          protected void FindChildWidgets(Transform t)
          {
               UISceneWidget widget = t.gameObject.GetComponent<UISceneWidget>();
               if (widget != null)
               {
                    string name = t.gameObject.name;
                    if (!mUIWidgets.ContainsKey(name))
                    {
                         mUIWidgets.Add(name, widget);
                    }
                    else
                    {
                         Debug.LogWarning("Scene[" + this.transform.name + "]UISceneWidget[" + name + "]is exist!");
                    }
               }
               for (int i = 0; i < t.childCount; ++i)
               {
                    Transform child = t.GetChild(i);
                    FindChildWidgets(child);
               }

          }
          //更新语言
          public virtual void UpdateLanguage()
          {

               if (mUIWidgets != null)
               {
                    foreach (var item in mUIWidgets)
                    {
                         Text text = item.Value.GetComponentInChildren<Text>();
                         UILanguageTable lang = 
                              S_LoadTable.Instance.fn_getUILanguage(
                              UIdata.ui_table_name, item.Key);
                         if (text != null && lang != null)
                              text.text = lang.CurrentLan();
                    }
               }
          }
          /// <summary>
          /// 取锟斤拷锟斤拷前锟斤拷锟斤拷锟斤拷锟阶诧拷锟?锟斤拷锟斤拷要锟矫伙拷锟饺达拷锟斤拷确锟较猴拷使锟斤拷
          /// </summary>
          /// <param name="panel"></param>
          protected void CancelCollider(Transform panel)
          {
               UISceneWidget[] widgets = panel.GetComponentsInChildren<UISceneWidget>();
               for (int i = 0; i < widgets.Length; i++)
               {

                    BoxCollider boxTemp = widgets[i].GetComponent<BoxCollider>();
                    if (boxTemp != null)
                         boxTemp.enabled = false;
               }

          }

          public void EnableButton(Button button, bool state)
          {
               if (button == null) return;
               if (state)
               {
                    button.GetComponent<Collider>().enabled = true;
                    button.transform.Find("Lock_Image").gameObject.SetActive(false);
               }
               else
               {
                    button.GetComponent<Collider>().enabled = false;
                    button.transform.Find("Lock_Image").gameObject.SetActive(true);
               }
          }
          protected void ChangePanel(UIName changeToName)
          {

               this.SetVisible(false);
               UI_Manager.Instance.SetVisible(changeToName.ToString(), true);
               //UI_Manager.Instance.GetInStack(this.gameObject.name);
               UI_Manager.Instance.GetInStack((UIName)Enum.Parse(typeof(UIName), this.gameObject.name));
          }

          protected UIName fn_get_uiscene_name()
          {
               UIName this_scene_name = (UIName)Enum.Parse(typeof(UIName), this.gameObject.name);
               return this_scene_name;
          }

          protected void fn_forbid_all_btns()
          {
               foreach (var item in mUIWidgets)
               {
                    if (item.Value.GetComponent<BoxCollider>() != null)
                         item.Value.GetComponent<BoxCollider>().enabled = false;
               }
          }
          protected void fn_enable_all_btns()
          {
               foreach (var item in mUIWidgets)
               {
                    if (item.Value.GetComponent<BoxCollider>() != null)
                         item.Value.GetComponent<BoxCollider>().enabled = true;
               }
          }
          /// <summary>
          /// 训练，考试，模式的多语言显示
          /// </summary>
          /// <param name="_obj"></param>
          protected virtual void fnp_changeLanguage(GameObject _obj)
          {
               if (_obj == null)
               {
                    return;
               }
               Text t_txt = _obj.GetComponentInChildren<Text>();
               UILanguageTable t_tableinfo =
                    S_LoadTable.Instance.fn_getUILanguage("language_English", _obj.name);
               if (t_txt == null || t_tableinfo == null)
               {
                    return;
               }
               t_txt.text =
                    UIdata.language_type == Language.Chinese ? t_tableinfo.Firstlan : t_tableinfo.Secondlan;
               

          }
     }


}