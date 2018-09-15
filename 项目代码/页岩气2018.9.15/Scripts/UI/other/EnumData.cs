
using System;
namespace GasPowerGeneration
{

     public enum Language
     {

          Chinese = 1,
          English = 2,
          Russian = 3,

          Null = 100,
     }

     public enum Project
     {
          Debug = 1,
          Move = 2,
          Maintain = 3,
          Fault = 4,
          Null = 5,
     }
     public enum Select_mode
     {
          train,
          test,
          free,
     }
     public enum unit_system_type
     {
          mertric,
          british,
     }

     public enum unit_type
     {
          [EnumLabel("温度")]
          temperature = 1,
          [EnumLabel("湿度")]
          humid = 2,
          [EnumLabel("安")]
          current = 3,
          [EnumLabel("伏特")]
          voltage = 4,
          [EnumLabel("转速")]
          rpm = 5,
          [EnumLabel("小时")]
          hour = 6,
          [EnumLabel("赫兹")]
          rate = 7,
          [EnumLabel("千瓦")]
          kw = 8,
          [EnumLabel("千瓦时")]
          kWh = 9,
          [EnumLabel("千帕")]
          kpa = 10,
          [EnumLabel("每分钟冲数")]
          spm = 11,
          [EnumLabel("兆帕")]
          MPa = 12,
          [EnumLabel("立方米每分钟")]
          m3min = 13,
          [EnumLabel("立方米")]
          m3 = 14,
          [EnumLabel("毫米")]
          mm = 15,
          [EnumLabel("牛米")]
          Nm = 16,
          [EnumLabel("秒")]
          second = 17,
          [EnumLabel("冲")]
          strokes = 18,
          Null = 100,
     }


     public enum Project_new
     {
          guide_mode = 1,
          operation_mode = 2,
          debug_mode = 3,
          safetyedu_mode = 4,
          maintain_mode = 5,
          transport_mode = 6,
          fault_mode = 7,
          Null = 8,
     }

     public enum e_hand_ui_panel
     {
          top = 1,
          transport = 2,
          training = 3,
          exam = 4,
          setting = 5,
          score = 6,
          Null = 99,

     }
     /// <summary>
     /// 泵的操作界面的名称枚举
     /// </summary>
     public enum e_bump_ui_panel
     {
          Null = 0,
          /// <summary>
          /// 操作界面
          /// </summary>
          operation = 1,
          /// <summary>
          /// 菜单界面
          /// </summary>
          menu = 2,
          /// <summary>
          /// 参数设置界面
          /// </summary>
          bumppara_set = 3,
          /// <summary>
          /// 警告提示界面
          /// </summary>
          alarm = 4,
          /// <summary>
          /// 单泵界面
          /// </summary>
          sigle_bump = 8,
          /// <summary>
          /// 泵组界面
          /// </summary>
          bumps = 16,
          /// <summary>
          /// 铺助设备界面
          /// </summary>
          support = 32,
          /// <summary>
          /// 参数输入界面
          /// </summary>
          param_input = 64,
          /// <summary>
          /// 开始界面
          /// </summary>
          start = 128,

     }
}