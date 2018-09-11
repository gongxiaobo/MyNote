using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 电线的参数设置和现实隐藏
     /// </summary>
     public abstract class AB_Wire : MonoBehaviour
     {

          protected virtual void Start() {
               S_AllWire.Instance.fn_putIn(this.gameObject.name, this);
          }
          /// <summary>
          /// 电线连接的参数，参数类型
          /// 10&20&2&hard&red
          /// </summary>
          protected string m_WirePara = "";
          /// <summary>
          /// 初始化,数据如：10-20-2-hard-red
          /// </summary>
          /// <param name="_para"></param>
          public abstract void fn_init(string _para);
          /// <summary>
          /// 当电线拆除时，需要对对应的接口的状态值改变
          /// </summary>
          protected AB_HandleEvent[] m_ports = null;
          /// <summary>
          /// 初始化，需要放入链接接口的管理类
          /// </summary>
          /// <param name="_para"></param>
          /// <param name="_port"></param>
          public abstract void fn_init(string _para,AB_HandleEvent[] _ports);
          /// <summary>
          /// 是否连接显示电线
          /// </summary>
          protected bool m_isConnect = false;
          /// <summary>
          /// 是否连接显示电线
          /// </summary>
          public bool IsConnect
          {
               get { return m_isConnect; }
               //set { m_isConnect = value; }
          }
          /// <summary>
          /// 显示
          /// </summary>
          public abstract void fn_show();
          /// <summary>
          /// 隐藏
          /// </summary>
          public abstract void fn_hide();
          /// <summary>
          /// 清除电线的数据
          /// 一般拆线的时候用
          /// </summary>
          public abstract void fn_clear();


     } 
}
