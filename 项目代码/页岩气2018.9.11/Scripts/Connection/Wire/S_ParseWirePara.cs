using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 对于线的参数的解析
/// </summary>
public static class S_ParseWirePara  {
     /// <summary>
     /// 获取电线参数的有效序列
     /// </summary>
     /// <param name="_para">10&20&2&hard&red</param>
     /// <returns></returns>
     public static string[] fn_getPara(string _para){
          if (_para=="")
          {
               return null;
          }
          string[] t_paras = _para.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
          return t_paras;
     }
     /// <summary>
     /// 查看接口的参数是否是一个链接了一根线的状态值
     /// </summary>
     /// <param name="_para"></param>
     /// <returns></returns>
     public static bool fn_IsConnectState(string _para)
     {
          if (_para == "")
          {
               return false;
          }
          string[] t_paras = _para.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
          return (t_paras.Length == 5) ? true : false;
     }
     /// <summary>
     /// 查看接口的参数是否是一个链接了两根线的状态值
     /// </summary>
     /// <param name="_para"></param>
     /// <returns></returns>
     public static bool fn_IsConnectTwoState(string _para)
     {
          if (_para == "")
          {
               return false;
          }
          string[] t_paras = _para.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
          return (t_paras.Length == 10) ? true : false;
     }
     public static bool fn_IsConnectThreeState(string _para)
     {
          if (_para == "")
          {
               return false;
          }
          string[] t_paras = _para.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
          return (t_paras.Length == 15) ? true : false;
     }
     public static bool fn_IsConnectHaveState(string _para)
     {
          if (_para == "")
          {
               return false;
          }
          string[] t_paras = _para.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
          return (t_paras.Length == 5 || t_paras.Length == 10 || t_paras.Length == 15) ? true : false;
     }
     /// <summary>
     /// 从数据中提取单独一项的数据
     /// </summary>
     /// <param name="_para"></param>
     /// <param name="_index">0为接口1，1为接口2，2为尺寸，3为软硬，4为颜色</param>
     /// <returns></returns>
     public static string fn_getParaOne(string _para, int _index)
     {
          string[] t_parse = fn_getPara(_para);
          if (t_parse!=null)
          {
               int t_index = _index;
               if (t_index<=0)
               {
                    t_index = 0;
               }
               if (t_index>=(t_parse.Length-1))
               {
                    t_index = (t_parse.Length - 1);
               }
               return t_parse[t_index];
          }
          return "";
     }
     /// <summary>
     /// 这是在一个接口连接两根线的情况，把一个接口的数据拆分成两个单独的数据块
     /// </summary>
     /// <param name="_para"></param>
     /// <returns>string[2]</returns>
     public static string[] fn_getParaTwo(string _para)
     {
          string[] t_return = new string[2];
          string[] t_p = fn_getPara(_para);
          if (t_p.Length==10)
          {
               t_return[0] = t_p[0] + "&" + t_p[1] + "&" + t_p[2] + "&" + t_p[3] + "&" + t_p[4];
               t_return[1] = t_p[5] + "&" + t_p[6] + "&" + t_p[7] + "&" + t_p[8] + "&" + t_p[9];
               return t_return;
          }
          return null;

     }
     /// <summary>
     /// 把参数拆分成链接线信息
     /// </summary>
     /// <param name="_para"></param>
     /// <returns></returns>
     public static string[] fn_SplitToTwo(string _para)
     {
          string[] t_return = new string[2];
          string[] t_p = fn_getPara(_para);
          if (t_p.Length == 10)
          {
               t_return[0] = t_p[0] + "&" + t_p[1] + "&" + t_p[2] + "&" + t_p[3] + "&" + t_p[4];
               t_return[1] = t_p[5] + "&" + t_p[6] + "&" + t_p[7] + "&" + t_p[8] + "&" + t_p[9];
              
          }
          else if (t_p.Length==5)
          {
               t_return[0] = _para;
               t_return[1] = "";

          }
          else
          {
               t_return[0] = "";
               t_return[1] = "";
          }
          return t_return;

     }
     public static string[] fn_SplitToThree(string _para)
     {
          string[] t_return = new string[3];
          string[] t_p = fn_getPara(_para);
          if (t_p.Length == 15)
          {
               t_return[0] = t_p[0] + "&" + t_p[1] + "&" + t_p[2] + "&" + t_p[3] + "&" + t_p[4];
               t_return[1] = t_p[5] + "&" + t_p[6] + "&" + t_p[7] + "&" + t_p[8] + "&" + t_p[9];
               t_return[2] = t_p[10] + "&" + t_p[11] + "&" + t_p[12] + "&" + t_p[13] + "&" + t_p[14];
          }
          else if (t_p.Length == 10)
          {
               t_return[0] = t_p[0] + "&" + t_p[1] + "&" + t_p[2] + "&" + t_p[3] + "&" + t_p[4];
               t_return[1] = t_p[5] + "&" + t_p[6] + "&" + t_p[7] + "&" + t_p[8] + "&" + t_p[9];
               t_return[2] = "";
          }
          else if (t_p.Length == 5)
          {
               t_return[0] = _para;
               t_return[1] = "";
               t_return[2] = "";

          }
          else
          {
               t_return[0] = "";
               t_return[1] = "";
               t_return[2] = "";
          }
          return t_return;

     }
     /// <summary>
     /// 比较一个接口有两根线连接的情况
     /// 如果相同，返回 _para1
     /// </summary>
     /// <param name="_para1">配置步骤表原始数据</param>
     /// <param name="_para2">将要赋值的数据</param>
     /// <returns>如果相同，返回 _para1 ,不同返回空值</returns>
     public static string fn_CheckTwoValueSame(string _para1, string _para2)
     {

          string[] t1 = fn_SplitToTwo(_para1);
          bool[] contain=new bool[2]{false,false};
          string[] t2 = fn_SplitToTwo(_para2);
          //如果这两个值相同，那么返回_para1
          for (int i = 0; i < t1.Length; i++)
          {
               if (t1[i] == t2[0] || t1[i] == t2[1])
               {
                    contain[i] = true;
                    continue;
               }
          }
          if (contain[0]==true && contain[1]==true)
          {//两值一样，有可能是顺序交换
               return _para1;
          }
          return _para2;
     }
     /// <summary>
     /// 比较一个接口有三根线连接的情况
     /// 如果相同，返回 _para1
     /// </summary>
     /// <param name="_para1">配置步骤表原始数据</param>
     /// <param name="_para2">将要赋值的数据</param>
     /// <returns>如果相同，返回 _para1 ,不同返回空值</returns>
     public static string fn_CheckThreeValueSame(string _para1, string _para2)
     {

          string[] t1 = fn_SplitToThree(_para1);
          bool[] contain = new bool[3] { false, false,false };
          string[] t2 = fn_SplitToThree(_para2);
          //如果这两个值相同，那么返回_para1
          for (int i = 0; i < t1.Length; i++)
          {
               if (t1[i] == t2[0] || t1[i] == t2[1] || t1[i] == t2[2])
               {
                    contain[i] = true;
                    continue;
               }
             
          }
          if (contain[0] == true && contain[1] == true && contain[2] == true)
          {//两值一样，有可能是顺序交换
               return _para1;
          }
          return _para2;
     }

}
