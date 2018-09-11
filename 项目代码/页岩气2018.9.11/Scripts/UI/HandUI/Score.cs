using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     /// <summary>
     /// 考试的内容显示
     /// </summary>
     public class Score : N_handpanel
     {
          public Text score_txt;

          public GameObject score_item;
          private List<GameObject> score_list = new List<GameObject>();
          private int index = 1;
          UI_page page;
          // Use this for initialization
          protected override void Awake()
          {
               base.Awake();

               //score_txt = transform.Find("score").GetComponent<Text>();
               page = GetComponent<UI_page>();
          }
          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               if (go.name == "Button_Up")
               {
                    fn_page_up();
               }
               else if (go.name == "Button_Down")
               {
                    fn_page_down();
               }
          }
          private void fn_page_up()
          {
               page.Previous();
          }

          private void fn_page_down()
          {
               page.Next();
          }
          /// <summary>
          /// 
          /// </summary>
          /// <param name="list">id和对错</param>
          /// <param name="listitem">步骤数和item序号</param>
          public void ShowScore(Dictionary<int, bool> list, Dictionary<int, int> listitem)
          {

               transform.GetChild(0).gameObject.SetActive(true);
               string temp;
               Dictionary<int, bool> new_list = new Dictionary<int, bool>();
               Dictionary<int, int> new_listitem = new Dictionary<int, int>();
               int m_index = 0;
               foreach (var item in list.Keys)
               {
                    new_list.Add(m_index, list[item]);
                    new_listitem.Add(m_index, listitem[item]);
                    m_index++;
               }
               score_list.Add(score_item);//分数列表第一项

               for (int i = 1; i < new_list.Count; i++)
               {
                    if (new_listitem.ContainsKey(i))
                         score_list.Add(GameObject.Instantiate(score_item, transform.GetChild(0)));
               }
               for (int i = 0; i < new_list.Count; i++)
               {
                    if (!new_listitem.ContainsKey(i) || !new_list.ContainsKey(i))
                         continue;
                    temp = new_list[i] ? "√" : "×";
                    score_list[i].transform.GetChild(1).GetComponent<Text>().text = index.ToString();
                    //score_list[i].transform.GetChild(2).GetComponent<Text>().text = new_listitem[i].ToString();
                    score_list[i].transform.GetChild(2).GetComponent<Text>().text =fnp_getItemNames(new_listitem[i]);
                    score_list[i].transform.GetChild(3).GetComponent<Text>().text = temp;
                    index++;
               }
               score_txt.text = fn_count_score(new_list);
               


               //for (int i = 1; i < list.Count; i++)
               //{
               //    if (listitem.ContainsKey(i))
               //        score_list.Add(GameObject.Instantiate(score_item, transform.GetChild(0)));
               //}
               //for (int i = 0; i < list.Count; i++)
               //{
               //    if (!listitem.ContainsKey(i) || !list.ContainsKey(i))
               //        continue;
               //    temp = list[i] ? "√" : "×";
               //    score_list[i].transform.GetChild(0).GetComponent<Text>().text = index.ToString();
               //    score_list[i].transform.GetChild(1).GetComponent<Text>().text = listitem[i].ToString();
               //    score_list[i].transform.GetChild(2).GetComponent<Text>().text = temp;
               //    index++;
               //}
               //score_txt.text = "0";// fn_count_score(list);



          }
          /// <summary>
          /// 根据itemID获取item的汉语名称或者其他语言名称
          /// </summary>
          /// <param name="_itemID"></param>
          /// <returns></returns>
          private  string fnp_getItemNames(int _itemID)
          {
               item_name t_item = 
                    S_LoadTable.Instance.fn_getItemName("item_names_ce", _itemID);
               if (t_item!=null)
               {
                    return S_SceneMessage.Instance.fn_getLanguage() == "Chinese" ?
                         t_item.m_ch_name:t_item.m_en_name;
               }
               return _itemID.ToString();
          }

          /// <summary>
          /// 计算分数
          /// </summary>
          /// <param name="list"></param>
          /// <returns></returns>
          private string fn_count_score(Dictionary<int, bool> list)
          {

               int right_count = 0;
               foreach (var item in list)
               {
                    if (item.Value)
                         right_count++;
               }
               print(right_count + "__" + list.Count + "__");
               float socre = (right_count * 100 / list.Count);

               return socre.ToString("00");
          }

          public override void fn_show()
          {
               base.fn_show();
               page.InitItems();
          }

     }

}