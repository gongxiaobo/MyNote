using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理坏掉的零件拿出来了后提示坏掉的零件，并且不显示装入提示（不能装入）
     /// </summary>
     public class N_ShowConTrigger_01 : N_ShowConTrigger
     {
          protected override void fnp_show()
          {
               AB_ThePart t_thepart = GetComponent<AB_ThePart>();
               if (t_thepart==null)
               {
                    base.fnp_show();
               }
               else
               {
                    if (t_thepart.M_PartUseState== E_PartUseState.e_goodPart)
                    {
                         base.fnp_show();
                    }
                    else
                    {//如果是坏的零件就不能放入到机器里
                         //播放声音告知玩家错误的零件不能放入到机器
                         S_SoundComSingle.Instance.fnp_soundSpecial("tip_badPart 1");

                    }
               }
               
          }
         
     } 
}
