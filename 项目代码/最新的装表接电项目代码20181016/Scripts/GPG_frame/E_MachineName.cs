using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 机器的名称枚举
     /// </summary>
     public enum E_MachineName
     {
          [EnumLabel("没有赋值")]
          e_null = 0,
          /// <summary>
          /// 机器1
          /// </summary>
          [EnumLabel("机器1")]
          e_machine1 = 1,
          /// <summary>
          /// 机器2 测试用
          /// </summary>
          [EnumLabel("机器2 测试用")]
          e_machineb = 2,
          /// <summary>
          /// 直流屏
          /// </summary>
          [EnumLabel(" 直流屏")]
          e_machine_10 = 10,
          /// <summary>
          /// 高压室
          /// </summary>
          [EnumLabel("高压室")]
          e_machine_11 = 11,
          /// <summary>
          /// 燃机市电控制柜
          /// </summary>
          [EnumLabel("燃机市电控制柜")]
          e_machine_12 = 12,
          /// <summary>
          /// 电控房间
          /// </summary>
          [EnumLabel("电控房间")]
          e_machine_13 = 13,
          /// <summary>
          /// MCC柜
          /// </summary>
          [EnumLabel("MCC柜")]
          e_machine_14 = 14,
          [EnumLabel("1号发电机控制柜")]
          e_machine_15 = 15,
          [EnumLabel("2号发电机控制柜")]
          e_machine_16 = 16,
          [EnumLabel("3号发电机控制柜")]
          e_machine_17 = 17,
          [EnumLabel("4号发电机控制柜")]
          e_machine_18 = 18,
          [EnumLabel("燃气机1")]
          e_machine_19 = 19,
          [EnumLabel("燃气机2")]
          e_machine_20 = 20,
          [EnumLabel("燃气机3")]
          e_machine_21 = 21,
          //
          [EnumLabel("燃料管路组1")]
          e_machine_22 = 22,
          [EnumLabel("高压控制柜1AH1")]
          e_machine_23 = 23,
          [EnumLabel("高压控制柜1AH2")]
          e_machine_24 = 24,
          [EnumLabel("高压控制柜1AH3")]
          e_machine_25 = 25,
          [EnumLabel("高压控制柜1AH5")]
          e_machine_26 = 26,
          [EnumLabel("高压控制柜1AH6")]
          e_machine_27 = 27,
          [EnumLabel("高压控制柜1AH7")]
          e_machine_28 = 28,
          [EnumLabel("高压控制柜1AH9")]
          e_machine_29 = 29,
          [EnumLabel("高压控制柜1AH10")]
          e_machine_30 = 30,
          [EnumLabel("工具箱")]
          e_machine_31 = 31,
          [EnumLabel("联络柜")]
          e_machine_32 = 32,
          [EnumLabel("CDP")]
          e_machine_33 = 33,
          [EnumLabel("VFD 综合控制柜")]
          e_machine_34 = 34,
          [EnumLabel("CDP 屏幕")]
          e_machine_35 = 35,
          [EnumLabel("10KV")]
          e_machine_36 = 36,

          [EnumLabel("VFD 1#变频传动单元")]
          e_machine_37 = 37,
          [EnumLabel("10kv 1#进线柜")]
          e_machine_38 = 38,
          [EnumLabel("35kv")]
          e_machine_39 = 39,
          [EnumLabel("泵UI")]
          e_machine_40= 40,
          [EnumLabel("泵")]
          e_machine_41 = 41,


          [EnumLabel("电表1")]
          e_machine_42 = 42,
          [EnumLabel("电表2")]
          e_machine_43 = 43,
          [EnumLabel("电表3")]
          e_machine_44 = 44,

     }

}