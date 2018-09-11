using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class UI_page_score : UI_page
     {
          private List<GameObject> m_score_list = new List<GameObject>();
          private N_handpanel hand_panel;

          public override void InitItems()
          {
               m_score_list.Clear();
               hand_panel = GetComponent<N_handpanel>();
               for (int i = 0; i < page_parent.childCount; i++)
               {
                    GameObject temp = page_parent.GetChild(i).gameObject;
                    if (temp != null)
                         m_score_list.Add(temp);

               }
               //计算元素总个数
               m_ItemsCount = m_score_list.Count;
               //计算总页数
               m_PageCount = (m_ItemsCount % itemcount_per_page) == 0 ? m_ItemsCount / itemcount_per_page : (m_ItemsCount / itemcount_per_page) + 1;
               BindPage(m_PageIndex);


          }
          public override void BindPage(int index)
          {
               if (m_score_list == null || m_ItemsCount <= 0)
               {
                    page_parent.gameObject.SetActive(false);
                    return;
               }
               else
               {
                    page_parent.gameObject.SetActive(true);
               }

               for (int i = 0; i < m_score_list.Count; i++)
               {
                    //当btn索引在当前页面的所有按钮索引之间时显示该btn
                    bool show = i >= itemcount_per_page * (index - 1) && i <= itemcount_per_page * index - 1;
                    page_parent.GetChild(i).gameObject.SetActive(show);
               }


          }
     }

}