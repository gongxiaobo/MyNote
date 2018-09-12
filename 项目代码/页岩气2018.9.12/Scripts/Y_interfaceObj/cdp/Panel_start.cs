using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GasPowerGeneration;
namespace cdp
{
    public class Panel_start : N_CDPPanel
    {
        public Text line1;
        public Text line2;
        public Text line3;
        public Text line4;

        protected override void Awake()
        {
            base.Awake();
        }
        public override void fn_show_panel()
        {
            base.fn_show_panel();
            StartCoroutine(fn_electric_changestate());
        }

        IEnumerator fn_electric_changestate()
        {
            line1.text = "CDP312 PANEL V5.30";
            line2.text = "";
            line3.text = "";
            line4.text = "........";
            yield return new WaitForSeconds(3f);
            line1.text = "ACS 5000 xxxx";
            line2.text = "<   Device Name   >";
            line4.text = "ID-NUMBER1";
            yield return new WaitForSeconds(3f);
            line1.text = "1-- L->               0             rpm";
            line2.text = "StateINU  DCGnd NOpen";
            line3.text = "MOTOR SP           0          rpm";
            line4.text = "MOTOR SP           0          rpm";
            yield return new WaitForSeconds(3f);
            CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);

        }
    }
}
