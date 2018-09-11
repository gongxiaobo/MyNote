using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_singlebump : N_bumpUI
     {

          private Image last_bump_btn;
          /// <summary>
          /// 泵选择按钮默认背景图片
          /// </summary>
          public Sprite default_sprite;
          protected override void Start()
          {
               base.Start();
               fn_findall_showparam(transform);
               //Invoke("Init", 4f);
               //等初始化完成后通知这里开始初始化
               GlobalEventSystem<InitFinished>.eventHappened += Init;

          }
          /// <summary>
          /// 当前显示的几号泵参数
          /// </summary>
          public int m_bumpIDNow = 1;
          void Init(InitFinished _canStart)
          {
               BumpParam_manager.Instance.fn_change_select_bump(fn_updateto_current_bump, m_bumpIDNow);
               fn_bump_btn_change(m_bumpIDNow);
          }

          void fn_bump_btn_change(int index)
          {
               last_bump_btn = TransformHelper.FindChild(transform, "btn_bump" + index.ToString()).GetComponent<Image>();
               last_bump_btn.sprite = null;
          }
          /// <summary>
          /// 获取到所有参数类型,对应itemid的项
          /// </summary>
          /// <param name="trans"></param>
          private void fn_findall_showparam(Transform trans)
          {
               ////递归查找所有子物体
               //I_bumpshowparam param = trans.GetComponent<I_bumpshowparam>();
               //if (param != null && !show_params.Contains(param)) show_params.Add(param);
               //for (int i = 0; i < trans.childCount; i++)
               //{
               //    param = trans.GetChild(i).GetComponent<I_bumpshowparam>();
               //    if (param != null && !show_params.Contains(param))
               //        show_params.Add(param);
               //    fn_findall_showparam(trans.GetChild(i));

               //}
               show_params = trans.FindInChlid<I_bumpshowparam>();
          }

          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               //若点击按钮为AB_showbumpparam类型，获取AB_showbumpparam的索引
               AB_showbumpparam param = go.GetComponent<AB_showbumpparam>();
               if (param == null)
                    param = go.GetComponentInParent<AB_showbumpparam>();
               int btn_index = 0;
               if (param != null)
                    btn_index = param.index;
               switch (go.name)
               {
                    case "btn_bump1":
                    case "btn_bump2":
                    case "btn_bump3":
                    case "btn_bump4":
                    case "btn_bump5":
                    case "btn_bump6":
                    case "btn_bump7":
                    case "btn_bump8":
                         //泵界面的切换
                         BumpUI_manager.Instance.current_bump_id = int.Parse(go.name.Replace("btn_bump", ""));
                         BumpParam_manager.Instance.fn_change_select_bump(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id);
                         last_bump_btn.sprite = default_sprite;
                         fn_bump_btn_change(BumpUI_manager.Instance.current_bump_id);
                         break;
                    case "on":
                         //打开
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id, btn_index, "on");
                         break;
                    case "off":
                         //关闭
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id, btn_index, "off");
                         break;
                    case "outputset_btn":
                         //设置排量按钮点击 激活input界面
                         BumpUI_manager.Instance.fn_show_set_panel(fn_updateto_current_bump, btn_index);

                         break;
                    case "outputdivide_btn":
                         //排量设置减少
                         int output_index = TransformHelper.FindChild(transform, "outputset_btn").GetComponent<N_showbumpparam>().index;
                         float value = float.Parse(BumpParam_manager.Instance.fn_get_bump_param(BumpUI_manager.Instance.current_bump_id, output_index));
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, output_index, (value - 0.1f).ToString());
                         break;
                    case "outputadd_btn":
                         //排量设置增加
                         int _output_index = TransformHelper.FindChild(transform, "outputset_btn").GetComponent<N_showbumpparam>().index;
                         float _value = float.Parse(BumpParam_manager.Instance.fn_get_bump_param(BumpUI_manager.Instance.current_bump_id, _output_index));
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, _output_index, (_value + 0.1f).ToString());
                         break;
                    case "clear_outputs_btn":
                         //排量归零
                         int alloutput_index = TransformHelper.FindChild(transform, "totaloutput_param").GetComponent<N_showbumpparam>().index;
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, alloutput_index, "0");
                         break;
                    case "clear_runtime_btn":
                         //运行时间归零
                         int _alloutput_index = TransformHelper.FindChild(transform, "run_time_param").GetComponent<N_showbumpparam>().index;
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, _alloutput_index, "0");
                         break;
                    case "estop_btn":
                         //急停
                         bool estop_value = BumpParam_manager.Instance.fn_get_bump_param(BumpUI_manager.Instance.current_bump_id, btn_index) == "on";
                         string estop_str = !estop_value ? "on" : "off";
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, btn_index, estop_str);
                         break;
                    case "supporteuip_btn":
                         //辅助设备界面激活
                         BumpUI_manager.Instance.fn_show_panel(e_bump_ui_panel.support);
                         break;
                    case "PCSP_btn":
                         bool pcsp_value = BumpParam_manager.Instance.fn_get_bump_param(BumpUI_manager.Instance.current_bump_id, btn_index) == "on";
                         string pcsp_str = !pcsp_value ? "on" : "off";
                         BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump,
                             BumpUI_manager.Instance.current_bump_id, btn_index, pcsp_str);
                         break;
                    case "parset_btn":
                         //参数设置界面激活
                         BumpUI_manager.Instance.fn_show_panel(e_bump_ui_panel.bumppara_set);
                         break;
                    default:
                         break;
               }
          }






     }

}
