using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

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
          /// 当前训练章节
          /// </summary>
          public static string currentChapter;


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

          public static unit_system_type unit_type = unit_system_type.mertric;

          public static Language first_lan;
          public static Language second_lan;

          //关卡是否为复合关卡
          public static bool compound_step;


          //复合关卡id列表
          public static List<string> compound_steps_id;
     }

}