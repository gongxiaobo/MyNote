using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public delegate void UpdateBumpParam();
     /// <summary>
     /// 一个UI面板的管理类
     /// </summary>
     public abstract class AB_bumpUI : MonoBehaviour
     {
          protected List<I_unit> units = new List<I_unit>();
          protected List<I_language> langs = new List<I_language>();
          /// <summary>
          /// 这个面板下所有的按钮与手柄的触发器
          /// </summary>
          protected List<Trigger_bumpui> triggers = new List<Trigger_bumpui>();
          /// <summary>
          /// 更新语言
          /// </summary>
          public abstract void fn_updatelan();
          //参数更新
          protected UpdateBumpParam fn_update_handler;
          //触发界面时执行
          public abstract void fn_show();
          //隐藏界面时执行
          public abstract void fn_hide();
          //查找所有需要语言切换的text
          protected abstract void fn_find_all_lang_text(Transform trans);
          //查找所有需要公英制切换的text
          protected abstract void fn_find_all_unit_text(Transform trans);
          /// <summary>
          /// 获取面板的触发器
          /// </summary>
          /// <param name="trans"></param>
          protected abstract void fn_get_triggers(Transform trans);

          protected RectTransform rect;
     }
}
