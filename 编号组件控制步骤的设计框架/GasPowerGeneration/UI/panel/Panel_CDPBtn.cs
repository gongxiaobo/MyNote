using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GasPowerGeneration;
namespace cdp
{
    public class Panel_CDPBtn : MonoBehaviour
    {

        private Trigger_cdpbtn[] trigger_btns;


        // Use this for initialization
        void Start()
        {
            trigger_btns = GetComponentsInChildren<Trigger_cdpbtn>();
            foreach (var item in trigger_btns)
            {
                item.onClick += PadInteract;
            }
        }
        ///// <summary>
        ///// 触控板交互
        ///// </summary>
        ///// <param name="go"></param>
        ///// <param name="press"></param>
        //private void PadInteract(GameObject go, bool press)
        //{
        //    if (press)
        //    {
        //        btn_pressed = true;
        //        StartCoroutine(Padpress(go));
        //    }
        //    else
        //    {
        //        StopCoroutine(Padpress(go));
        //        PadClick(go);
        //        btn_pressed = false;

        //    }
        //}


        //IEnumerator Padpress(GameObject go)
        //{


        //    yield return new WaitForSeconds(0.5f);
        //    while (btn_pressed)
        //    {
        //        CDPctrl_manager.Instance.fn_getbtnmsg(go);
        //    }
        //    yield return new WaitForSeconds(0.1f);

        //}


        //private void PadClick(GameObject go)
        //{
        //    CDPctrl_manager.Instance.fn_getbtnmsg(go);
        //}


        private void PadInteract(GameObject go, bool press)
        {
            CDPctrl_manager.Instance.fn_getbtnmsg(go,press);
            
        }

    }
}
