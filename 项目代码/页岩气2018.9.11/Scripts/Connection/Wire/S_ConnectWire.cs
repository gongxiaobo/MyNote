using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 线的链接，包括设置节点的状态值
     /// </summary>
     public class S_ConnectWire : GenericSingletonClass<S_ConnectWire>, I_ConnectWireInit
     {
          protected AB_Name m_select1;
          protected AB_Name m_select2;
          /// <summary>
          /// 接线的准备，手柄先选择一个接口，再选择另外一个接口，连线
          /// </summary>
          /// <param name="_select">当前选择的接口</param>
          public void fn_select(AB_Name _select)
          {
               if (m_select1==null)
               {
                    m_select1 = _select;
                    fnp_hightlightSelect(m_select1.gameObject, E_lightObjColor.e_red);
               }
               else
               {
                    if (m_select1 == _select)
                    {//两次选择同一个物体时
                         fnp_hightlightSelect(
                              m_select1.gameObject, E_lightObjColor.e_green,false);
                         fnp_setTriggerState(m_select1.gameObject, false);
                         m_select1 = null;
                         return;
                    }
                    m_select2 = _select;
                    fnp_readyConnect();
               }
          }
          /// <summary>
          /// 开始接线操作
          /// </summary>
          protected void fnp_readyConnect()
          {
               fnp_connect(m_select1.gameObject.name,
                    m_select2.gameObject.name);

               fnp_hightlightSelect(
                    m_select1.gameObject, E_lightObjColor.e_green, false);
               fnp_hightlightSelect(
                    m_select2.gameObject, E_lightObjColor.e_green, false);
               fnp_setTriggerState(m_select1.gameObject, false);
               fnp_setTriggerState(m_select2.gameObject, false);
               m_select1 = null;
               m_select2 = null;
          }
          /// <summary>
          /// 正常的操作链接两个接口之间的电线
          /// </summary>
          /// <param name="_name1">连接口1的名称</param>
          /// <param name="_name2">连接口2的名称</param>
          protected void fnp_connect(string _name1, string _name2)
          {
               string t_para="";
               string t_interfaceName = _name1 + "_" + _name2;
               AB_Wire t_wire = S_AllWire.Instance.fn_getWire(t_interfaceName);
               if (t_wire!=null)
               {
                    if (t_wire.IsConnect)
                    {
                         return;
                    }
                    AB_HandleEvent[] t_handevent = new AB_HandleEvent[2];
                    t_handevent[0] = m_select1.gameObject.GetComponent<AB_HandleEvent>();
                    t_handevent[1] = m_select2.gameObject.GetComponent<AB_HandleEvent>();
                    t_para = _name1 + "&" + _name2 + S_selectUI.Instance.fn_getWirePara();
                    t_wire.fn_init(t_para, t_handevent);
                    t_wire.fn_show();
               }
               else
               {
                    t_interfaceName = _name2 + "_" + _name1;
                    t_wire = S_AllWire.Instance.fn_getWire(t_interfaceName);
                    if (t_wire!=null)
                    {
                         if (t_wire.IsConnect)
                         {
                              return;
                         }
                         AB_HandleEvent[] t_handevent = new AB_HandleEvent[2];
                         t_handevent[0] = m_select1.gameObject.GetComponent<AB_HandleEvent>();
                         t_handevent[1] = m_select2.gameObject.GetComponent<AB_HandleEvent>();
                         t_para = _name2 + "&" + _name1 + S_selectUI.Instance.fn_getWirePara();
                         t_wire.fn_init(t_para, t_handevent);
                         t_wire.fn_show();
                    }
                    else
                    {

                         Debug.Log("<color=red>not find </color>" + _name1 + "_" + _name2);
                         Debug.Log("<color=red>or not find </color>" + _name2 + "_" + _name1);
     
                    }
               }
              
               fnp_setItemState(t_para);
               
          }
          /// <summary>
          /// 电线的初始化，在场景初始化时使用
          /// </summary>
          /// <param name="_name1">接口1</param>
          /// <param name="_name2">接口2</param>
          /// <param name="_para">初始化完整数据</param>
          /// <param name="_port1">接口1物体</param>
          /// <param name="_port2">接口2物体</param>
          protected void fnp_connect(string _name1, string _name2,string _para,
               GameObject _port1,GameObject _port2)
          {
               if (_name1==""||_name2==""||_para==""||_port1==null||_port2==null)
               {
                    Debug.Log("<color=red>electric wire initial failure!</color>" + _name1);
                    return;
               }
               string t_interfaceName = _name1 + "_" + _name2;
               AB_Wire t_wire = S_AllWire.Instance.fn_getWire(t_interfaceName);
               if (t_wire != null)
               {
                    if (t_wire.IsConnect)
                    {
                         return;
                    }
                    AB_HandleEvent[] t_handevent = new AB_HandleEvent[2];
                    t_handevent[0] = _port1.GetComponent<AB_HandleEvent>();
                    t_handevent[1] = _port2.GetComponent<AB_HandleEvent>();
                    t_wire.fn_init(_para, t_handevent);
                    t_wire.fn_show();
               }
               else
               {
                    t_interfaceName = _name2 + "_" + _name1;
                    t_wire = S_AllWire.Instance.fn_getWire(t_interfaceName);
                    if (t_wire != null)
                    {
                         if (t_wire.IsConnect)
                         {
                              return;
                         }
                         AB_HandleEvent[] t_handevent = new AB_HandleEvent[2];
                         t_handevent[0] = _port1.GetComponent<AB_HandleEvent>();
                         t_handevent[1] = _port2.GetComponent<AB_HandleEvent>();
                         t_wire.fn_init(_para, t_handevent);
                         t_wire.fn_show();
                    }
                    else
                    {
                         Debug.Log("<color=red>not find </color>" + _name1 + "_" + _name2);
                         Debug.Log("<color=red>or not find </color>" + _name2 + "_" + _name1);
                    }
               }
          }
          /// <summary>
          /// 链接两个接口后，改变接口的状态值
          /// </summary>
          /// <param name="t_para"></param>
          private void fnp_setItemState(string t_para)
          {
               if (t_para != "")
               {//有效的参数链接，设置两个连接节点的参数值,需要判断一个接口连接两根线的情况
                    fnp_SetSelectPort(t_para,m_select1.gameObject);
                    fnp_SetSelectPort(t_para, m_select2.gameObject);
               }
          }

          private void fnp_SetSelectPort(string t_para,GameObject _port)
          {
               //判断接口是否已经链接有电线
               AB_SetState t_set = new N_SetState();
               AB_HandleEvent t_handleEvent1 = _port.GetComponent<AB_HandleEvent>();
               string t_state1 = t_handleEvent1.fn_getMainValue();
               if (S_ParseWirePara.fn_IsConnectHaveState(t_state1))
               {//已经有一根链接线的情况
                    //这里需要和步骤表对比，如果和步骤表的链接状态一直，调整接口顺序和步骤表一致
                    AB_Name t_portname = _port.GetComponent<AB_Name>();
                    int t_id = t_portname.m_ID;

                    t_set.fn_setState("string", 
                         fnp_CheckTableValue(t_id, t_state1 + "&" + t_para), t_handleEvent1);
               }
               else
               {//无连接线
                    t_set.fn_setState("string", t_para, t_handleEvent1);
               }
              
          }
          /// <summary>
          /// 高亮或者关闭射线选中的端口，表示正要链接线的端口
          /// </summary>
          /// <param name="_port"></param>
          /// <param name="_color"></param>
          /// <param name="_light"></param>
          protected void fnp_hightlightSelect(
               GameObject _port,E_lightObjColor _color,bool _light=true)
          {
               if (_port==null)
               {
                    return;
               }
               I_lightChangeMat t_lightChange =
                        _port.GetComponent<I_lightChangeMat>();
               if (t_lightChange != null)
               {
                    t_lightChange.fni_changeColor(_color);
               }
               AB_LightOneObj t_lightOneObj =
                    _port.GetComponent<AB_LightOneObj>();
               if (t_lightOneObj != null)
               {
                    if (_light)
                    {
                         t_lightOneObj.fn_light();
                    }
                    else
                    {
                         t_lightOneObj.fn_endLigth();
                    }
               }
              
          }
          protected void fnp_setTriggerState(GameObject _target, bool _bl)
          {
               if (_target!=null)
               {
                    I_SetWireBool ti_wirebool = _target.GetComponent<I_SetWireBool>();
                    if (ti_wirebool!=null)
                    {
                         ti_wirebool.fni_setWireBool(_bl);
                    }
               }
          }

          #region interface
          /// <summary>
          /// 初始化电线,通过读表的初始化使用
          /// </summary>
          /// <param name="_initString"></param>
          public void fni_InitWire(string _initString)
          {
               if (_initString == "")
               {
                    return;
               }
               string[] t_paras = S_ParseWirePara.fn_getPara(_initString);
              
               if (t_paras.Length==5)
               {//接口只链接一根线的情况
                    fnp_connect(t_paras[0], t_paras[1], _initString,
                              S_Ports.Instance.fn_getPort(t_paras[0]),
                              S_Ports.Instance.fn_getPort(t_paras[1]));
               }
               else if (t_paras.Length == 10)
               {//接口连接两根线的情况
                    string[] t_init = S_ParseWirePara.fn_getParaTwo(_initString);
                    if (t_init!=null)
                    {
                         fni_InitWire(t_init[0]);
                         fni_InitWire(t_init[1]);
                    }
               }
               else if (t_paras.Length == 15)
               {//接口连接两根线的情况
                    string[] t_init = S_ParseWirePara.fn_getParaTwo(_initString);
                    if (t_init != null)
                    {
                         fni_InitWire(t_init[0]);
                         fni_InitWire(t_init[1]);
                         fni_InitWire(t_init[2]);
                    }
               }

          } 
          #endregion
          /// <summary>
          /// 根据步骤比较一个接口连接两根电线时，降值和步骤配置表一致
          /// </summary>
          /// <param name="_itemID">接口ID</param>
          /// <param name="_twoValue">将要更新的两根电线链接状态的值</param>
          /// <returns></returns>
          protected string fnp_CheckTableValue(int _itemID, string _twoValue)
          {
               if (S_TableStepInfo.Instance.M_tableDate == null)
               {
                    return _twoValue;
               }
               //更加现在的参数值来判断是两根线或者是三根线的链接
               string t_ParaNum = "";
               if (S_ParseWirePara.fn_IsConnectTwoState(_twoValue))
               {
                    t_ParaNum = "two";
               }
               else if (S_ParseWirePara.fn_IsConnectThreeState(_twoValue))
               {
                    t_ParaNum = "three";
               }
               else if (S_ParseWirePara.fn_IsConnectState(_twoValue))
               {
                    t_ParaNum = "one";
               }
               
               //
               //找到表中的对应长度的字段
               string t_stepItemValue = "";
               foreach (var itemValue in S_TableStepInfo.Instance.M_tableDate.Values)
               {

                    if (itemValue.m_id==_itemID)
                    {
                         string[] t_paras = S_ParseWirePara.fn_getPara(itemValue.m_state);
                         if (t_ParaNum=="two")
                         {
                              if (t_paras.Length == 10)
                              {//判断状态值长度是否为10
                                   t_stepItemValue = itemValue.m_state;
                                   break;
                              }
                         }
                         else if (t_ParaNum == "three")
                         {
                              if (t_paras.Length == 15)
                              {//判断状态值长度是否为10
                                   t_stepItemValue = itemValue.m_state;
                                   break;
                              }
                         }
                         
                    }
               }
               //对比两字段是否一样，只是顺序不一样。
               if (t_stepItemValue!="")
               {
                    if (t_ParaNum == "two")
                    {
                         return S_ParseWirePara.fn_CheckTwoValueSame(t_stepItemValue, _twoValue);
                    }
                    else if (t_ParaNum == "three")
                    {
                         return S_ParseWirePara.fn_CheckThreeValueSame(t_stepItemValue, _twoValue);
                    }
               }
               return _twoValue;
          }
     } 
}
