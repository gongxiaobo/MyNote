using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Show_param : AB_Param
     {
          [EnumLabel("单位类型")]
          public unit_type unittype;
          [Tooltip("显示参数text")]
          private Text param_text;
          [Tooltip("显示单位text")]
          private Text unit_text;

          internal int int_value;
          internal float float_value;
          protected override void Start()
          {
               base.Start();
          }
          protected override void OnEnable()
          {
               base.OnEnable();
               param_text = TransformHelper.FindChild(transform, "param").GetComponent<Text>();
               unit_text = TransformHelper.FindChild(transform, "unit").GetComponent<Text>();
          }

          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    // GetComponentInChildren<N_Pointer>().fn_inputValue(_level);
               }
               else
               {

               }
          }

          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    // GetComponentInChildren<N_Pointer>().fn_inputValue(_level);
               }
               else
               {

               }
          }
          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_param(int value)
          {
               int_value = value;
               if (param_text != null && unittype != null)
                    param_text.text = Unit_Tool.fn_get_unit_value(unittype, value.ToString());
          }
          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_param(float value)
          {
               float_value = value;
               if (param_text != null && unittype != null)
                    param_text.text = Unit_Tool.fn_get_unit_value(unittype, value.ToString("0.00"));
          }
          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_unit()
          {
               if (param_text != null && unittype != null)
                    unit_text.text = Unit_Tool.fn_get_unit_type(unittype);
          }


          public override RectTransform fn_getrect()
          {
               RectTransform rect = GetComponent<RectTransform>();
               if (rect != null)
                    return rect;
               else return null;

          }
     } 
}