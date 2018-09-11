using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的表类型的刻度设置，指针指向位置
     /// </summary>
     public class Show_bumpparam_pointer : N_showbumpparam, I_ParaSet 
     {  //指针需要组件：

          public unit_type unittype;
          private Text param, unit, muti_num;
          public int multi_times;
          private N_Pointer pointer;
          //刻度text列表
          private List<Text> signs;


          //public Text[] signs;
          protected override void Start()
          {
               base.Start();
               //等初始化完成后通知这里开始初始化
               GlobalEventSystem<InitFinished>.eventHappened += fn_init;
               //Invoke("fn_init", 4f);
               //指针组件初始化
               pointer = GetComponentInChildren<N_Pointer>();
               param = TransformHelper.FindChild(transform, "param").GetComponent<Text>();
               unit = TransformHelper.FindChild(transform, "unit").GetComponent<Text>();
               muti_num = TransformHelper.FindChild(transform, "muti_num").GetComponent<Text>();
               Transform trans = TransformHelper.FindChild(transform, "sign");
               if (trans != null && trans.childCount > 0)
               {
                    signs = new List<Text>();
                    for (int i = 0; i < trans.childCount; i++)
                    {
                         signs.Add(trans.GetChild(i).GetComponent<Text>());
                    }
               }
          }

          private void fn_init(InitFinished _canStart)
          {
               BumpParam_manager.Instance.fn_get_unit_range(index, fn_set_sign_txt);
          }
          /// <summary>
          /// 设置指针参数，显示信息
          /// </summary>
          /// <param name="value"></param>
          protected override void fn_show_pointer(string value)
          {
               base.fn_show_pointer(value);

              
     
               //指针指向值
               float _level = float.Parse(value);
               pointer.fn_inputValue(_level);
               //数值显示
               if (param != null)
                    param.text = Unit_Tool.fn_get_bumpuiunit_value(unittype, _level.ToString("0.00"));
               //倍速显示
               if (muti_num != null)
                    muti_num.text = "x" + multi_times;
               //单位显示
               if (unit != null)
                    unit.text = Unit_Tool.fn_get_bumpuiunit_type(unittype);

          }
          /// <summary>
          /// 设置刻度显示
          /// 根据刻度范围设置刻度值
          /// </summary>
          /// <param name="range"></param>
          private void fn_set_sign_txt(Vector2 range)
          {
               float temp = (Mathf.Abs(range.x) + Mathf.Abs(range.y)) / (signs.Count - 1);
               int index = 0;
               foreach (var item in signs)
               {
                    // item.text = ((range.x) + index * temp).ToString();
                    string original_value = Unit_Tool.fn_get_bumpuiunit_value(unittype, ((range.x) + index * temp).ToString());
                    float t_sf;

                    if (float.TryParse(original_value, out t_sf))
                    {
                         item.text = (t_sf / multi_times).ToString();
                    }
                    else
                    {
                         item.text = "null";
                    }
                    index++;
               }
          }

          public void fni_newParaSet(float _value)
          {
               //数值显示
               if (param != null)
                    param.text = Unit_Tool.fn_get_bumpuiunit_value(unittype, _value.ToString("0.00"));
          }
     }
}