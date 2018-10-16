using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public class Show_bumpparam_param : N_showbumpparam
    {
        public unit_type unittype;
        private Text param;
        private Text unit;
        // Use this for initialization
        void Start()
        {
            Transform para_tran=transform.Find("param");
            if (para_tran != null)
                param = para_tran.GetComponent<Text>();
            Transform unit_tran = transform.Find("unit");
            if (unit_tran != null)
                unit = unit_tran.GetComponent<Text>();
        }

        protected override void fn_show_number(string value)
        {
            base.fn_show_number(value);
            float _level ;
            if (float.TryParse(value,out _level)==false)
            {
                 Debug.Log("<color=red>float.TryParse false </color>" + value+"--"+this.gameObject.name);
            }
            if(param!=null)
                param.text = Unit_Tool.fn_get_bumpuiunit_value(unittype, _level.ToString("0.00"));
            if(unit!=null)
                unit.text = Unit_Tool.fn_get_bumpuiunit_type(unittype);
        }
        
    }
}