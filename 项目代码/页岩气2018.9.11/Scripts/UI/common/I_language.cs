using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 语言切换接口
/// </summary>
public interface I_language
{
     /// <summary>
     /// 获取节点下的Text组件
     /// </summary>
     /// <returns></returns>
     Text fn_get_item_text();
     /// <summary>
     /// 获取需要翻译的名称
     /// </summary>
     /// <returns></returns>
     string fn_get_language_item();


}
