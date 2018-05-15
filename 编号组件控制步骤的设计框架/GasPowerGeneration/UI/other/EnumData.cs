
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
}