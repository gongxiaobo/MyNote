using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
namespace TcpMsg
{
     public class N_tcpSendMsg : AB_tcpSendMsg,I_MsgUpdate
     {
          /// <summary>
          /// original messages queue
          /// </summary>
          Queue<byte[]> m_originalMsgs = new Queue<byte[]>();
          public override void fn_Packing(string _originalMsg)
          {
               if (_originalMsg=="")
               {
                    return;
               }
               string t_addonMsg = "$|" + _originalMsg + "#";
               m_originalMsgs.Enqueue(Encoding.UTF8.GetBytes(t_addonMsg));
          }
          Action<byte[]> m_send = null;
          public override void fn_setOut(System.Action<byte[]> _sendMsg)
          {
               m_send = _sendMsg;
          }
          Queue<byte[]> m_Package = new Queue<byte[]>();

         
          protected void fnp_madePackage()
          {
               if (m_originalMsgs.Count==0)
               {
                    return;
               }
               byte[] t_temp = m_originalMsgs.Dequeue();
               if (t_temp.Length<=1024)
               {
                    m_Package.Enqueue(t_temp);
                    
                    //Debug.Log("<color=blue><=1024</color>");
     
               }
               else
               {
                    //Debug.Log("<color=blue>>=1024</color>");
                    int t_group = t_temp.Length / 1024;
                    int t_remainder = t_temp.Length % 1024;
                    t_group += t_remainder > 0 ? 1 : 0;
                   
                    for (int i = 0; i < t_group; i++)
                    {
                         int t_voloum = (i == t_group - 1) ? t_remainder : 1024;
                         byte[] t_subMsg = new byte[t_voloum];
                         Array.Copy(t_temp, i * 1024, t_subMsg, 0, t_voloum);
                         m_Package.Enqueue(t_subMsg);
                        
                    }
               }
              
             
               
          }

          public void fni_updateHandleMsg()
          {
               //make msg to queue
               fnp_madePackage();
               //out msg to send
               if (m_send != null && m_Package.Count>0)
               {
                    m_send(m_Package.Dequeue());
               }
          }
     } 
}
