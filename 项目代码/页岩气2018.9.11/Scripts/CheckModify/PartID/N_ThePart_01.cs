using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件的信息获取
     /// 零件是否可以配对
     /// 可以用来判断零件的好坏情况
     /// </summary>
     public class N_ThePart_01 : AB_ThePart
     {


          public override bool fn_PairedPart(int _id)
          {
               AB_NameFlag t_flag = GetComponent<AB_NameFlag>();
               if (t_flag!=null)
               {
                    if (t_flag.M_nameID==_id)
                    {
                         return true;
                    }
                    return false;
               }
               else
               {
                    return false;
               }
          }
         
          public bool m_goodbad = true;
          /// <summary>
          /// 零件的好坏情况
          /// </summary>
          public override bool M_GoodOrBad
          {
               get
               {
                   return m_goodbad;
               }
               set
               {
                    if (m_goodbad!=value)
                    {
                         m_goodbad = value; 
                    }
               }
          }
          public E_ThePartState m_partstatenow = E_ThePartState.e_inMachine;
          /// <summary>
          /// 零件的位置状态
          /// </summary>
          public override E_ThePartState M_PartState
          {
               get
               {
                    return m_partstatenow;
               }
               set
               {
                    if (m_partstatenow!=value)
                    {
                         m_partstatenow = value;
                         if (M_PartStateChangeEvent != null)
                         {
                              M_PartStateChangeEvent(m_partstatenow);
                         } 
                    }
               }
          }
          [Tooltip("零件好坏情况")]
          public E_PartUseState m_PartUseState = E_PartUseState.e_goodPart;
          /// <summary>
          /// 零件的好坏状态
          /// </summary>
          public override E_PartUseState M_PartUseState
          {
               get
               {
                    return m_PartUseState;
               }
               set
               {
                    m_PartUseState = value ;
               }
          }
     }

}