using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的实际参数
     /// </summary>
     public class BumpParam_manager : GenericSingletonClass<BumpParam_manager>
     {

         //设备编号表格中泵UI id的第一位
          string start_num_of_bump_param = "3";
          Action<int, string> _call;
          Action<Vector2> _unitrangecall;
          List<AB_bumpparam> l_params = new List<AB_bumpparam>();
          Dictionary<string, AB_bumpparam> m_bengPara = new Dictionary<string, AB_bumpparam>();

          //默认显示泵的id
          int defalutbumpid = 1;
          private void Awake()
          {
               fn_find_all_params(transform);
               fnp_findBengPara();
               
               //Debug.Log("<color=blue>泵的参数个数=</color>"+m_bengPara.Count);
     
          }
          private void fnp_findBengPara()
          {
               AB_bumpparam[] t_para = transform.FindInChlidArray<AB_bumpparam>();
               for (int i = 0; i < t_para.Length; i++)
               {
                    string t_name = t_para[i].gameObject.name;
                    if (!m_bengPara.ContainsKey(t_name))
                    {
                         m_bengPara.Add(t_name, t_para[i]);
                    }
                    else
                    {
                         Debug.Log("<color=red>有重复的泵参数item!!!</color>");
                    }
               }
          }
          private void fn_find_all_params(Transform trans)
          {
               //递归查找所有子物体
               //AB_bumpparam param = trans.GetComponent<AB_bumpparam>();
               //if (param != null && !l_params.Contains(param)) l_params.Add(param);
               //for (int i = 0; i < trans.childCount; i++)
               //{
               //     param = trans.GetChild(i).GetComponent<AB_bumpparam>();
               //     if (param != null && !l_params.Contains(param))
               //          l_params.Add(param);
               //     fn_find_all_params(trans.GetChild(i));

               //}
               l_params=transform.FindInChlid<AB_bumpparam>();

               Debug.Log("<color=blue>l_params:</color>" + l_params.Count);
     
          }
          /// <summary>
          /// 切换当前显示的泵信息
          /// </summary>
          /// <param name="call"></param>
          /// <param name="bumpid"></param>

          public void fn_change_select_bump(Action<int, string> call, int bumpid)
          {
               _call = call;
               foreach (var item in l_params)
               {
                    item.fn_update_param(call, bumpid);
               }
          }
          /// <summary>
          /// 获取参数的数值范围
          /// </summary>
          /// <param name="param_index"></param>
          /// <param name="_unitrange"></param>
          /// <returns></returns>
          public Vector2 fn_get_unit_range(int param_index, Action<Vector2> _unitrange = null)
          {
               int t_bumpIdNow = BumpUI_manager.Instance.current_bump_id;
               _unitrangecall = _unitrange;
               Vector2 range = new Vector2(0, 0);
               foreach (var item in l_params)
               {
                    //找到物体id后两位与UI id相同的物体
                    //if (item.param_id.ToString().Substring(2, 2) == param_index.ToString("00"))
                    //     range = item.fn_get_unit_range(_unitrange);
                    if (item.param_id.ToString().Substring(1, 3) == (t_bumpIdNow.ToString() + param_index.ToString("00")))
                         range = item.fn_get_unit_range(_unitrange);
                    //if (_unitrange!=null)
                    //{
                    //     _unitrange(range);
                    //}
                    
               }
               return range;
          }
          /// <summary>
          /// 更新单泵控制的页面信息
          /// </summary>
          public void fn_update_bump_page()
          {
               foreach (var item in l_params)
               {
                    if (_call != null && _unitrangecall != null)
                    {
                         item.fn_update_param(_call, defalutbumpid);
                         item.fn_get_unit_range(_unitrangecall);
                    }
               }
          }
          /// <summary>
          /// 修改泵参数
          /// </summary>
          /// <param name="set_call">回调函数</param>
          /// <param name="bumpid"></param>
          /// <param name="item_id"></param>
          /// <param name="value">设置的值</param>
          public void fn_change_bump_param(Action<int, string> set_call, int bumpid, int item_id, string value)
          {

               float param;
               bool float_value = float.TryParse(value, out param);
               string ui_id = bumpid.ToString() + item_id.ToString("00");
               //判断是数值类型还是bool类型
               if (float_value)
               {

                    foreach (var item in l_params)
                    {

                         string param_id = item.param_id.ToString().Substring(1, 3);
                         if (ui_id == param_id)
                         {
                              item.fn_set_param(set_call, bumpid, param);
                         }
                    }
               }
               else
               {
                    bool temp = value == "on";
                    foreach (var item in l_params)
                    {
                         string param_id = item.param_id.ToString().Substring(1, 3);
                         if (ui_id == param_id)
                         {
                              item.fn_set_param(set_call, bumpid, temp);
                         }
                    }
               }
          }
         /// <summary>
         /// 获取参数信息
         /// </summary>
         /// <param name="bumpid"></param>
         /// <param name="param_index"></param>
         /// <returns></returns>
          public string fn_get_bump_param(int bumpid, int param_index)
          {
               foreach (var item in l_params)
               {
                   //获取参数的id全称
                    string temp = start_num_of_bump_param + bumpid.ToString() + param_index.ToString("00");
                    if (temp == item.param_id.ToString())
                    {
                         return item.fn_get_param_value();
                    }
               }
               return "";
          }
          /// <summary>
          /// 给参数设置系数值
          /// </summary>
          /// <param name="coefficient_value">设定系数值</param>
          /// <param name="bumpid">所属泵的id</param>
          /// <param name="item_id">修改元素itemid的最后两位</param>
          /// <param name="call">回调委托</param>
          public void fn_set_param_coefficient(float coefficient_value, int bumpid, int item_id, Action<int, string, string> call)
          {
               string ui_id = bumpid.ToString() + item_id.ToString("00");
               foreach (var item in l_params)
               {

                    string param_id = item.param_id.ToString().Substring(1, 3);
                    if (ui_id == param_id)
                    {
                         item.coefficient = coefficient_value;
                         item.fni_level(item.original_value);
                         call(item_id, item.fn_get_param_value(), coefficient_value.ToString());
                    }
               }
          }

          /// <summary>
          /// 给参数设置偏移值
          /// </summary>
          /// <param name="offset_value">设定偏移值</param>
          /// <param name="bumpid">所属泵的id</param>
          /// <param name="item_id">修改元素itemid的最后两位</param>
          /// <param name="call">回调委托</param>
          public void fn_set_param_offset(float offset_value, int bumpid, int item_id, Action<int, string, string> call)
          {
               string ui_id = bumpid.ToString() + item_id.ToString("00");
               foreach (var item in l_params)
               {

                    string param_id = item.param_id.ToString().Substring(1, 3);
                    if (ui_id == param_id)
                    {

                         item.offset = offset_value;
                         item.fni_level(item.original_value);
                         call(item_id, item.fn_get_param_value(), offset_value.ToString());
                    }
               }
          }
     }
}
