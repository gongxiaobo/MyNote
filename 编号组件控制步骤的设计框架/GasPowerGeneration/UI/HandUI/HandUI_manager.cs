using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class HandUI_manager : GenericSingletonClass<HandUI_manager>
     {

          /// <summary>
          /// 初始界面类型
          /// </summary>
          public e_hand_ui_panel start_panel;
          /// <summary>
          /// 手部菜单各个界面列表
          /// </summary>
          private List<N_handpanel> panels;
          // Use this for initialization
          void Start()
          {
               panels = new List<N_handpanel>(GetComponentsInChildren<N_handpanel>());
               fn_change_panel(start_panel);
          }
          /// <summary>
          /// 切换界面
          /// </summary>
          /// <param name="paneltype"></param>
          public void fn_change_panel(e_hand_ui_panel paneltype)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type == paneltype)
                    {

                         item.fn_show();
                    }
                    else if (item.panel_type != e_hand_ui_panel.top)
                    {
                         item.fn_hide();
                    }


               }
          }
          /// <summary>
          /// 更新训练、考试的时间信息
          /// </summary>
          /// <param name="seconds"></param>
          public void fn_update_time(int seconds)
          {
               foreach (var item in panels)
               {
                    item.fn_update_time(seconds);
               }
          }
          /// <summary>
          /// 考试模式更新操作分数信息
          /// </summary>
          /// <param name="list"></param>
          /// <param name="listitem"></param>
          public void fn_show_score(Dictionary<int, bool> list, Dictionary<int, int> listitem)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type == e_hand_ui_panel.score)
                    {
                         item.GetComponent<Score>().ShowScore(list, listitem);
                    }
               }
          }
     }

}