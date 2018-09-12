using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 时间转换
/// </summary>
public static class s_secondToH  {
     /// <summary>
     /// 把时间秒转换成时分秒
     /// </summary>
     /// <param name="_inputS"></param>
     /// <param name="_hour"></param>
     /// <param name="_minute"></param>
     /// <param name="_second"></param>
     public static void fns_SecondToSMH(float _inputS, out float _hour, out float _minute, out float _second)
     {
          //hour
          float t_h = Mathf.Floor(_inputS / 3600f);
          float t_m = 0f;
          float t_s = 0f;
          float t_ms=(_inputS - t_h * 3600f) ;
          if (t_ms==0f)
          {
               t_m = 0f;
               t_s = 0f;
          }
          else
          {
                t_m = Mathf.Floor(t_ms / 60f);
                t_s = t_ms - t_m * 60f;
          }
          
          _hour = t_h;
          _minute = t_m;
          _second = t_s;
     }
     /// <summary>
     /// 把秒转换成输出格式时分秒
     /// </summary>
     /// <param name="_inputs"></param>
     /// <param name="_h"></param>
     /// <param name="_m"></param>
     /// <param name="_s"></param>
     public static void fns_HMStoString(float _inputs, out string _h, out string _m, out string _s)
     {
          float t_h,t_m,t_s;
          fns_SecondToSMH(_inputs, out t_h, out t_m, out t_s);
         
          _h = fnp_format(t_h);
          _m = fnp_format(t_m);
          _s = fnp_format(t_s);

     }

     private static string fnp_format(float t_h)
     {
          string t_out;
          if (t_h < 10f)
          {
               t_out = "0" + t_h.ToString();
          }
          else
          {
               t_out = t_h.ToString();
          }
          return t_out;
     }
}
