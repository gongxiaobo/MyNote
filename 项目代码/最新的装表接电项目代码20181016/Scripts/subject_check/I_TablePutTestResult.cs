using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电中，考试模式和故障排除模式下提交测试结果的接口
     /// </summary>
     public interface I_TablePutTestResult
     {
          /// <summary>
          /// 装表接电中，考试模式和故障排除模式下提交测试结果的接口,true为测试通过
          /// </summary>
          /// <returns></returns>
          bool fni_TablePutTestResult();
          /// <summary>
          /// 装表接电中，考试模式和故障排除模式下,获取错误的步骤详情
          /// </summary>
          /// <returns></returns>
          subject_step fni_GetErrorStep();
     }
}
