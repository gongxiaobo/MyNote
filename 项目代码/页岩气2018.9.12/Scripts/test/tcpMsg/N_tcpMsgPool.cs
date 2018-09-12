using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
namespace TcpMsg
{
     /// <summary>
     /// receive data 
     /// exchange data to string(json)
     /// </summary>
     public class N_tcpMsgPool : AB_tcpMsgPool, I_MsgUpdate
     {
          Queue<byte[]> m_pool = new Queue<byte[]>();
          public override void fn_msgInPool(byte[] _msg)
          {
               
               m_pool.Enqueue(_msg);
              
          }
          //拆好的完整消息
          Queue<string> m_outPool = new Queue<string>();
          //set callback func
          public override void fn_setCallBack(System.Action<string> _callback)
          {
               m_callback = _callback;
          }
          Action<string> m_callback = null;
          protected virtual void fnp_out()
          {
               if (m_callback == null)
               {
                    return;
               }
               if (m_outPool.Count > 0)
               {
                    m_callback(m_outPool.Dequeue());
               }
              
          }
          protected virtual void fnp_in()
          {
               if (m_pool.Count>0)
               {
                  fnp_SpliteMsgToString();

               }
          }

          /// <summary>
          ///上次遗留的数据
          /// </summary>
          string m_last = "";
          /// <summary>
          /// 通过拆分字符来找到完整消息
          /// </summary>
          protected virtual void fnp_SpliteMsgToString()
          {
             
               string t_temp =Encoding.UTF8.GetString(m_pool.Dequeue());
               //first split
               string[] t_split = t_temp.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

               for (int i = 0; i < t_split.Length; i++)
               {
                    if (i == 0 && m_last!="")
                    {//add last
                         fnp_findRightMsg(m_last+t_split[i]);
                    }
                    else
                    {
                         fnp_findRightMsg(t_split[i]);
                    }
                    

               }
              
               
          }
          /// <summary>
          /// 递归找到完整消息，然后组装消息
          /// </summary>
          /// <param name="_msgIn">消息</param>
          private void fnp_findRightMsg(string _msgIn)
          {
               
               if (fnp_checkMsg(_msgIn))
               {//full msg

                    string t_wholemsg = _msgIn.Split(new char[] { '|', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    m_outPool.Enqueue(t_wholemsg);
                    m_last = "";
               }
               else
               {//msg not right
                    //add to last
                    m_last += _msgIn;
                    if (fnp_checkMsg(m_last))
                    {//full msg

                         string t_wholemsg = _msgIn.Split(new char[] { '|', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
                         m_outPool.Enqueue(t_wholemsg);
                         m_last = "";
                    }
                   
               }
          }
          /// <summary>
          /// 判断消息的完整性，开始以“|”结束用“#”
          /// </summary>
          /// <param name="_msg"></param>
          /// <returns></returns>
          protected virtual bool fnp_checkMsg(string _msg)
          {
               if (_msg.StartsWith("|") && _msg.EndsWith("#"))
               {//full msg
                    return true;
               }
               return false;
          }


          /// <summary>
          /// 定时更新取值
          /// 
          /// </summary>
          public void fni_updateHandleMsg()
          {
               //需要根据帧来调用
               fnp_in();
               fnp_out();
          }
     }

}