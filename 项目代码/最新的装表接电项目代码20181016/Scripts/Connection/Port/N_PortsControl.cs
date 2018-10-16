using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的控制接口，在接口初始化时，生成对应的电线的操作。
     /// </summary>
     public class N_PortsControl : MonoBehaviour,I_Control
     {


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {//
               if (_controlType== E_ControlType.e_init)
               {//10&20&2&hard&red 的电线信息，生成电线
                    ////在新的连线模式下，已经抛弃这种初始化方式
                    //S_ConnectWire.Instance.fni_InitWire(_txt);

                    if (_txt != "1" && _txt != "")
                    {
                         //在故障模式下的初始化线
                         S_ConnectWire.Instance.fn_initWireNew(_txt); 
                    }


               }
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }
     } 
}
