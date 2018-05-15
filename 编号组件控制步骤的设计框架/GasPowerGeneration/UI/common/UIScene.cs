using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace GasPowerGeneration
{
     /// <summary>
     /// UI������
     /// </summary>
     public class UIScene : MonoBehaviour
     {

          protected string mUIName = "";

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
          /// ����ui����
          /// </summary>
          /// <param name="visible"></param>
          public virtual void SetVisible(bool visible)
          {

               gameObject.SetActive(visible);
               if (visible == true)
                    UpdateLanguage();
          }
          /// <summary>
          /// ��ȡ����µ�ĳ��UIԪ��
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
               }

               return t.gameObject.GetComponent<UISceneWidget>();
          }

          /// <summary>
          /// ���������������е�uiԪ�ز���ӵ��ֵ���?
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
          //��������ѡ��
          public virtual void UpdateLanguage()
          {

               if (mUIWidgets != null)
               {
                    foreach (var item in mUIWidgets)
                    {
                         Text text = item.Value.GetComponentInChildren<Text>();
                         UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, item.Key);
                         if (text != null && lang != null)
                              text.text = lang.CurrentLan();
                    }
               }
          }
          /// <summary>
          /// ȡ����ǰ�������ײ��?����Ҫ�û��ȴ���ȷ�Ϻ�ʹ��
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
     }


}