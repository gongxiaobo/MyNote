using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TcpMsg;
using System.Text;
public class testSplitString : MonoBehaviour {
     I_MsgUpdate mi_update = null;
     I_MsgUpdate mi_send = null;
     AB_tcpMsgPool t_msgPool;
	// Use this for initialization
	void Start () {
          Debug.Log("<color=blue>x</color>");
          //receive
           t_msgPool = new N_tcpMsgPool();
          t_msgPool.fn_setCallBack(debuglog);
          mi_update = t_msgPool as I_MsgUpdate;


          //send
          AB_tcpSendMsg t_send = new N_tcpSendMsg();
          t_send.fn_setOut(fn_send);
          mi_send = t_send as I_MsgUpdate;
          for (int i = 0; i < 10; i++)
          {
               if (i==3||i==7)
               {
                    t_send.fn_Packing(i.ToString() +"sdkjflsdjflasdjflasdkjflaskdjflaksdjflkasjdflakjdsflkajsdflkajsdflkjsdflksdfgsdfg*");
               }
               else
               {
               t_send.fn_Packing(i.ToString() + 
                    "xxasdfasdfasdfasdfasdfadsfasdfasdfadsfasdfadsfs;dlfgjs;lfkgj;alkdfja;ldkfjadfkja;ldskfjalkdfja;lkdfja;lkdsfja;ldksfja;lkdsfj;alsdfjl"
               +"sdfgasldfjlskdjflasdkjflsdjflasdjflasdkjafdasfdgsfdgsdfgsdfgsdfgsdfgsdfgsdfgsdfgsdfgsdfffffffffffffffffffffffffffffffffffffffffffffffffff"
                    +"fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffflaskdjflaksdjfl"
                    +"kasjdflakjdsflkajsdflkajsdflkja;sldkjfa;sldkfja;sldkfja;lsdkfsdflksdfgsdfg*");

               }
          }


          //string t_temp1 = "$|1sdkfhskjd#$|2sdfsdfs#$|3sdfsdfs";
          //string t_temp2 = "fff#$|4sdkfhskjd#$|5sdfsdfs";
          //string t_temp3 = "fff#$|6sdkfhskjd#$|7sdfsdfs";
          //string t_temp4 = "fff#$|8sdkfhskjd#$|9sdfsdfs";
          //string t_temp5 = "fff#$|10sdkfhskjd#$|11sdfsdfs";
          //string t_temp6 = "fff#$|12sdkfhskjd#$|13sdfsdfs";
          //string t_temp7 = "fff#$|14sdkfhskjd#$|15sdfsdfs";
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp1));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp2));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp3));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp4));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp5));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp6));
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp7));

          //string t_temp8 = "fff#$|16sdkfhskjd#$|17sdfsdfs#";
          //t_msgPool.fn_msgInPool(Encoding.UTF8.GetBytes(t_temp8));

        

          //string t_tobyte="sdfa";
          //byte[] t_b1 = Encoding.UTF8.GetBytes(t_tobyte);
          //byte[] t_b2=new byte[t_b1.Length];
          //t_b1.CopyTo(t_b2, 0);
          //t_b1 = null;
          //string t_fromstring = Encoding.UTF8.GetString(t_b2);

          //Debug.Log("<color=blue>blue:</color>" + t_fromstring);
     

          //string t_temp = "fff#$|1sdkfhskjd#$|2sdfsdfs#$|3sdfsdfs";
          //string t_temp = "fffdfs";
          //string[] t_split= t_temp.Split(new char[]{'$'}, StringSplitOptions.RemoveEmptyEntries);
          //for (int i = 0; i < t_split.Length; i++)
          //{
               
              
          //     if (t_split[i] .StartsWith("|")&& t_split[i].EndsWith("#"))
          //     {
                    
          //          Debug.Log("<color=red>all</color>");
          //          Debug.Log("<color=blue>blue:</color>" + t_split[i].Split(new char[]{'|','#'}, StringSplitOptions.RemoveEmptyEntries)[0]);
          //     }
          //     else
          //     {
                    
          //          Debug.Log("<color=red>not all</color>");
          //          Debug.Log("<color=blue>blue:</color>" + t_split[i]);
          //     }
     
          //}

	}
	
	// Update is called once per frame
	void Update () {
          if (mi_send!=null)
          {
               mi_send.fni_updateHandleMsg();
          }
          if (mi_update!=null)
          {
               mi_update.fni_updateHandleMsg();
          }
	}
     protected void debuglog(string _msg)
     {

          Debug.Log("<color=blue></color>" + _msg);
     
     }
     protected void fn_send(byte[] _msgToSend)
     {
          t_msgPool.fn_msgInPool(_msgToSend);
     }
}
