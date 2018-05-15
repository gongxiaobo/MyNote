using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     /// <summary>
     /// 名称及图片元素类
     /// </summary>
     public class GridItem : MonoBehaviour
     {
          /// <summary>
          /// 
          /// </summary>
          /// <param name="name">ui表格中的键名</param>
          /// <param name="UIname">需要绑定sprite的名称</param>
          public GridItem(string name, string UIname)
          {
               ItemSprite = UIname;
               ItemName = name;
               //UILanguageTable uilan=S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, name);
               //if(uilan!=null)
               //    ItemName = uilan.CurrentLan();


          }
          public string ItemSprite { get; set; }
          public string ItemName { get; set; }
     } 
}
