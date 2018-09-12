using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 为了装表接电的项目选择章节制作
     /// 加入隐藏返回按钮
     /// </summary>
     public class N_AutoSelect : AB_AutoSelect
     {
          protected override void Start()
          {
               base.Start();
               fn_selectChapter();
          }
          /// <summary>
          /// 选择序列
          /// </summary>
          public List<A_TriggerObj> m_SelectList = new List<A_TriggerObj>();
          /// <summary>
          /// 隐藏物体
          /// </summary>
          public List<GameObject> m_hideItem = new List<GameObject>();
          public bool m_isAuto = false;
          public override void fn_selectChapter()
          {
               if (m_isAuto)
               {
                    S_SceneMessage.Instance.m_isTableModel = m_isAuto;
                    StartCoroutine("fnp_select");
               }
               else if (S_SceneMessage.Instance.m_isTableModel)
               {
                    StartCoroutine("fnp_select");
               }
          }
          IEnumerator fnp_select()
          {
               for (int i = 0; i < m_SelectList.Count; i++)
               {
                    yield return new WaitForSeconds(0.1f);
                    m_SelectList[i].fn_trigger(E_buttonIndex.e_padPressUp, null);
               }
               StartCoroutine("fnp_hide");

          }
          IEnumerator fnp_hide()
          {
               for (int i = 0; i < m_hideItem.Count; i++)
               {
                    yield return new WaitForSeconds(0.1f);
                    m_hideItem[i].SetActive(false);
               }


          }
     } 
}
