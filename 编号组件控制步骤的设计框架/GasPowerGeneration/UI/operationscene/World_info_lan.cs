using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GasPowerGeneration
{
     public class World_info_lan : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               Text text = GetComponentInChildren<Text>();
               if (text != null)
               {
                    UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, gameObject.name);

                    if (lang != null)
                    {
                         text.text = lang.CurrentLan();
                    }
               }
          }


     }

}