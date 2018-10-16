using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{
     /// <summary>
     /// 手柄的菜单键按下事件
     /// </summary>
     public class N_event_menuBtnDow
     {
          /// <summary>
          /// 那一只手的菜单键按下
          /// </summary>
          public string m_hand;

          public N_event_menuBtnDow(string _whichHand)
          {
               m_hand = _whichHand;
          }

     } 
}

