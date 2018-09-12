using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{

     public class UI_page : MonoBehaviour
     {

          /// <summary>
          /// 当前页面索引
          /// </summary>
          public int m_PageIndex = 1;
          /// <summary>
          /// 总页数
          /// </summary>
          protected int m_PageCount = 0;
          /// <summary>
          /// 元素总个数
          /// </summary>
          protected int m_ItemsCount = 0;
          /// <summary>
          /// 元素列表
          /// </summary>
          protected List<GridItem> m_ItemsList = new List<GridItem>();

          // List<T> GetResult<T>() where T : ItemInterface;
          /// <summary>
          /// 上一页
          /// </summary>
          protected Button m_BtnPrevious;
          /// <summary>
          /// 下一页
          /// </summary>
          protected Button m_BtnNext;
          ///// <summary>
          ///// 显示当前页数的标签
          ///// </summary>
          //private Text m_PanelText;
          /// <summary>
          /// 动态加载路径
          /// </summary>
          protected string secondLevelPath = "UI/Main/";
          /// <summary>
          /// 当前模式的关卡数量
          /// </summary>
          public int chapter_count;
          //默认每页元素数
          public int itemcount_per_page = 9;

          protected Transform page_parent;


          protected int index = 0;

          protected string currentproname;
          protected virtual void OnEnable()
          {
               page_parent = TransformHelper.FindChild(transform, "SubValue");
               m_BtnPrevious = TransformHelper.FindChild(transform, "Button_Up").GetComponent<Button>();
               m_BtnNext = TransformHelper.FindChild(transform, "Button_Down").GetComponent<Button>();

               InitItems();


          }
          protected virtual void Start()
          {
               //if (gameObject.name == "Name_Panel") m_ItemsList = new List<Page_item_name>();
               //InitItems();
          }

          /// <summary>
          /// 初始化元素
          /// </summary>
          public virtual void InitItems()
          {
               chapter_count = UIdata.currentProChapterCount;
               if (UIdata.current_pro == Project.Null || chapter_count == 0) return;
               if (m_ItemsList.Count > 0)
                    m_ItemsList.Clear();
               if (currentproname != UIdata.current_pro.ToString())
               {
                    m_PageIndex = 1;
               }
               currentproname = UIdata.current_pro.ToString();


               for (int i = 1; i <= chapter_count; i++)
               {
                    int temp = i;

                    while (temp > itemcount_per_page)
                    {
                         temp -= itemcount_per_page;
                    }


                    GridItem item = new GridItem(currentproname + i, currentproname + temp);
                    m_ItemsList.Add(item);
               }
               //计算元素总个数
               m_ItemsCount = m_ItemsList.Count;
               //计算总页数
               m_PageCount = (m_ItemsCount % itemcount_per_page) == 0 ? m_ItemsCount / itemcount_per_page : (m_ItemsCount / itemcount_per_page) + 1;
               BindPage(m_PageIndex);

               //更新界面页数
               //m_PanelText.text = string.Format("{0}/{1}", m_PageIndex.ToString(), m_PageCount.ToString());


          }


          /// <summary>
          /// 下一页
          /// </summary>
          public virtual void Next()
          {
               if (m_PageCount <= 0)
                    return;
               //最后一页禁止向后翻页
               if (m_PageIndex >= m_PageCount)
                    return;
               m_PageIndex += 1;
               if (m_PageIndex >= m_PageCount)
                    m_PageIndex = m_PageCount;
               BindPage(m_PageIndex);
               //更新界面页数
               //m_PanelText.text = string.Format("{0}/{1}", m_PageIndex.ToString(), m_PageCount.ToString());

               //if (m_PageIndex == m_PageCount)
               //{
               //    m_BtnNext.gameObject.SetActive(false);
               //    m_BtnPrevious.gameObject.SetActive(true);

               //}
               //else
               //{
               //    m_BtnNext.gameObject.SetActive(true);
               //    m_BtnPrevious.gameObject.SetActive(true);
               //}
          }
          /// <summary>
          /// 上一页
          /// </summary>
          public virtual void Previous()
          {
               if (m_PageCount <= 0)
                    return;
               //第一页时禁止向前翻页
               if (m_PageIndex <= 1)
                    return;
               m_PageIndex -= 1;
               if (m_PageIndex < 1)
                    m_PageIndex = 1;
               BindPage(m_PageIndex);
               //更新界面页数
               //m_PanelText.text = string.Format("{0}/{1}", m_PageIndex.ToString(), m_PageCount.ToString());
               //if (m_PageIndex == 1)
               //{
               //    m_BtnPrevious.gameObject.SetActive(false);
               //    m_BtnNext.gameObject.SetActive(true);
               //}
               //else
               //{
               //    m_BtnPrevious.gameObject.SetActive(true);
               //    m_BtnNext.gameObject.SetActive(true);
               //}
          }
          /// <summary>
          /// 绑定指定索引处的页面元素
          /// </summary>
          /// <param name="index">页面索引</param>
          public virtual void BindPage(int index)
          {

               //列表处理
               if (m_ItemsList == null || m_ItemsCount <= 0)
               {
                    page_parent.gameObject.SetActive(false);
                    return;
               }
               else
               {
                    page_parent.gameObject.SetActive(true);
               }

               //索引处理
               if (index < 0 || index > m_ItemsCount)
                    return;
               //按照元素个数可以分为1页和1页以上两种情况
               if (m_PageCount == 1)
               {

                    int canDisplay = 0;
                    for (int i = itemcount_per_page; i > 0; i--)
                    {
                         if (canDisplay < m_ItemsList.Count)
                         {

                              BindGridItem(page_parent.GetChild(canDisplay), m_ItemsList[itemcount_per_page - i]);
                              page_parent.GetChild(canDisplay).gameObject.SetActive(true);
                         }
                         else
                         {
                              //对超过canDispaly的物体实施隐藏
                              page_parent.GetChild(canDisplay).gameObject.SetActive(false);
                         }
                         canDisplay += 1;
                    }
                    m_BtnPrevious.gameObject.SetActive(false);
                    m_BtnNext.gameObject.SetActive(false);
               }
               else if (m_PageCount > 1)
               {

                    //1页以上需要特别处理的是最后1页
                    //和1页时的情况类似判断最后一页剩下的元素数目
                    //第1页时剩下的为9所以不用处理
                    if (index == m_PageCount)
                    {
                         int canDisplay = 0;
                         for (int i = itemcount_per_page; i > 0; i--)
                         {
                              //最后一页剩下的元素数目为 m_ItemsCount - 9 * (index-1)
                              if (canDisplay < m_ItemsCount - itemcount_per_page * (index - 1))
                              {
                                   BindGridItem(page_parent.GetChild(canDisplay), m_ItemsList[itemcount_per_page * index - i]);
                                   page_parent.GetChild(canDisplay).gameObject.SetActive(true);
                              }
                              else
                              {
                                   //对超过canDispaly的物体实施隐藏
                                   page_parent.GetChild(canDisplay).gameObject.SetActive(false);
                              }
                              canDisplay += 1;
                         }
                         m_BtnPrevious.gameObject.SetActive(true);
                         m_BtnNext.gameObject.SetActive(false);
                    }

                    else
                    {
                         for (int i = itemcount_per_page; i > 0; i--)
                         {
                              BindGridItem(page_parent.GetChild(itemcount_per_page - i), m_ItemsList[itemcount_per_page * index - i]);
                              page_parent.GetChild(itemcount_per_page - i).gameObject.SetActive(true);
                         }
                         m_BtnNext.gameObject.SetActive(true);
                         if (index != 1)
                              m_BtnPrevious.gameObject.SetActive(true);
                         else
                              m_BtnPrevious.gameObject.SetActive(false);

                    }
               }
          }

          /// <summary>
          /// 加载一个Sprite
          /// </summary>
          /// <param name="assetName">资源名称</param>
          protected Sprite LoadSprite(string assetName)
          {
               //Texture texture = (Texture)Resources.Load(secondLevelPath + assetName);
               //Sprite sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
               Sprite sprite = Resources.Load<GameObject>(secondLevelPath + assetName).GetComponent<SpriteRenderer>().sprite;
               return sprite;
          }
          /// <summary>
          /// 将一个GridItem实例绑定到指定的Transform上
          /// </summary>
          /// <param name="trans"></param>
          /// <param name="gridItem"></param>
          protected virtual void BindGridItem(Transform trans, GridItem gridItem)
          {
               trans.GetComponent<Image>().sprite = Resources.Load<GameObject>(secondLevelPath + UIdata.current_pro.ToString() + "Color").GetComponent<SpriteRenderer>().sprite;
               trans.GetChild(1).GetComponent<Image>().sprite = LoadSprite(gridItem.ItemSprite);
               trans.GetComponentInChildren<Text>().text = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, gridItem.ItemName).CurrentLan();

          }
     }

}