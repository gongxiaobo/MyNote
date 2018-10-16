using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// UI的静态数据保存
     /// 
     /// </summary>
     public static class UIdata
     {

          public static string ui_table_name = "language";

          public static readonly string ui_sprite_path = "UI/Main/";

          /// <summary>
          /// 训练项目
          /// </summary>
          public static Project current_pro = Project.Null;

          public static Project_new project = Project_new.Null;
          /// <summary>
          /// 当前训练章节名称:例如装表接电名称为:connect
          /// </summary>
          public static string currentChapter;

          /// <summary>
          /// 当前的步骤选择名称，例如装表接电张节下的一个步骤名称为:connect_3
          /// </summary>
          public static string currentStep;
          /// <summary>
          /// 训练模式
          /// </summary>
          public static Select_mode trainMode;
          /// <summary>
          /// 当前语言
          /// </summary>
          public static Language language_type = Language.Chinese;
          /// <summary>
          /// 当前项目有多少训练科目
          /// </summary>
          public static int currentProChapterCount;
          /// <summary>
          /// 公制还是英制
          /// </summary>
          public static unit_system_type unit_type = unit_system_type.mertric;

          public static unit_system_type bumpui_unit_type = unit_system_type.mertric;
          public static Language first_lan;
          public static Language second_lan;

          /// <summary>
          /// //关卡是否为复合关卡
          /// </summary>
          public static bool compound_step;


         /// <summary>
          ///  //复合关卡id列表
         /// </summary>
          public static List<string> compound_steps_id;
     }

}