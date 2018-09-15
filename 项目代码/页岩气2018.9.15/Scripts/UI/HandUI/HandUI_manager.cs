using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理手柄上的菜单
     /// </summary>
     public class HandUI_manager : GenericSingletonClass<HandUI_manager>
     {

          /// <summary>
          /// 初始界面类型
          /// </summary>
          private e_hand_ui_panel start_panel = e_hand_ui_panel.transport;
          /// <summary>
          /// 手部菜单各个界面列表
          /// </summary>
          private List<N_handpanel> panels;
          // Use this for initialization
          void Start()
          {
               panels = new List<N_handpanel>(GetComponentsInChildren<N_handpanel>());
               print(UIdata.currentChapter);
               if (UIdata.currentChapter == "beng_check" ||
                    UIdata.currentChapter == "beng_setup" ||
                    UIdata.currentChapter == "connect")
               {//connect,在检泵场景和装表接电场景，隐藏传输界面

                    if (S_SceneMessage.Instance.fn_getMode() == "train")
                    {//训练模式下
                         fn_change_panel(e_hand_ui_panel.training);
                         TransformHelper.FindChild(transform, "btn_exam").gameObject.SetActive(false);
                    }
                    else if (S_SceneMessage.Instance.fn_getMode() == "test")
                    {//考试模式下
                         fn_change_panel(e_hand_ui_panel.exam);
                         TransformHelper.FindChild(transform, "btn_train").gameObject.SetActive(false);
                    }
                    else
                    {
                         fn_change_panel(e_hand_ui_panel.training);
                         TransformHelper.FindChild(transform, "btn_exam").gameObject.SetActive(false);
                    }
                    
                    TransformHelper.FindChild(transform, "btn_transport").gameObject.SetActive(false);

               }
               else
               {
                    fn_change_panel(start_panel);
               }
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