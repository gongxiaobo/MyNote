using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public class N_langupdate : MonoBehaviour, I_language
    {
        private Text text;

        
        protected virtual void Awake() {
            text = GetComponentInChildren<Text>();
        }


       Text I_language.fn_get_item_text()
       {
           return text;
       }

       string I_language.fn_get_language_item()
       {
           return gameObject .name;
       }
    }
}
