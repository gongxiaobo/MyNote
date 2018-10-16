using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 返回到选择场景
     /// </summary>
     public interface I_backToSelect
     {
          /// <summary>
          /// 从训练场景返回到选择场景
          /// </summary>
          void fni_TrainBackSelect();
          /// <summary>
          /// 从考试场景返回到选择场景
          /// </summary>
          void fni_TestBackSelect();
          /// <summary>
          /// 停止考试，提交考卷
          /// </summary>
          void fni_StopTest();

     } 
}
