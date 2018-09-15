using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class UI_page_chapter : UI_page
     {

          public override void InitItems()
          {

               chapter_count = UI_Manager.Instance.fn_get_chapter_info(UIdata.project.ToString()).Count;
               if (UIdata.project == Project_new.Null || chapter_count == 0) return;
               if (m_ItemsList.Count > 0)
                    m_ItemsList.Clear();
               if (currentproname != UIdata.project.ToString())
               {
                    m_PageIndex = 1;
               }
               currentproname = UIdata.project.ToString();
               List<string> chapter_items = UI_Manager.Instance.fn_get_chapter_info(UIdata.project.ToString());
               for (int i = 1; i <= chapter_count; i++)
               {
                    int temp = i;

                    while (temp > itemcount_per_page)
                    {
                         temp -= itemcount_per_page;
                    }
                    GridItem item = new GridItem(chapter_items[i - 1], currentproname + " " + temp);
                    m_ItemsList.Add(item);
               }
               m_ItemsCount = m_ItemsList.Count;
               m_PageCount = (m_ItemsCount % itemcount_per_page) == 0 ? m_ItemsCount / itemcount_per_page : (m_ItemsCount / itemcount_per_page) + 1;
               BindPage(m_PageIndex);


          }

          protected override void BindGridItem(Transform trans, GridItem gridItem)
          {
               trans.GetComponent<Image>().sprite = Resources.Load<GameObject>(secondLevelPath + UIdata.project.ToString() + "Color").GetComponent<SpriteRenderer>().sprite;
               trans.GetChild(1).GetComponent<Image>().sprite = LoadSprite(gridItem.ItemSprite);
               UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, gridItem.ItemName);
               if (lang != null)
                    trans.GetComponentInChildren<Text>().text = lang.CurrentLan();
          }
     }

}