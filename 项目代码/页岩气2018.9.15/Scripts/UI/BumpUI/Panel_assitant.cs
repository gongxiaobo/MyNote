using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public class Panel_assitant : N_bumpUI
    {

        private Text equipindex;
        protected override void Start()
        {
            base.Start();
            equipindex = TransformHelper.FindChild(transform, "equipindex").GetComponent<Text>();
            fn_findall_showparam(transform);
        }
        private void fn_findall_showparam(Transform trans)
        {
            //递归查找所有子物体
            I_bumpshowparam param = trans.GetComponent<I_bumpshowparam>();
            if (param != null && !show_params.Contains(param)) show_params.Add(param);
            for (int i = 0; i < trans.childCount; i++)
            {
                param = trans.GetChild(i).GetComponent<I_bumpshowparam>();
                if (param != null && !show_params.Contains(param))
                    show_params.Add(param);
                fn_findall_showparam(trans.GetChild(i));

            }
        }

        public override void fn_show()
        {
            base.fn_show();
            equipindex.text = BumpUI_manager.Instance.current_bump_id.ToString();
            BumpParam_manager.Instance.fn_change_select_bump(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id);
        }
        protected override void fn_btn_press(GameObject go, bool press)
        {
            base.fn_btn_press(go, press);
            if (!press) return;
            AB_showbumpparam param = go.GetComponent<AB_showbumpparam>();
            if (param == null)
                param = go.GetComponentInParent<AB_showbumpparam>();
            int btn_index = 0;
            if (param != null)
                btn_index = param.index;
            switch (go.name) {
                case "exit_btn":
                    fn_hide();
                    break;
                case "on":
                    BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id, btn_index, "on");
                    break;
                case "off":
                    BumpParam_manager.Instance.fn_change_bump_param(fn_updateto_current_bump, BumpUI_manager.Instance.current_bump_id, btn_index, "off");
                    break;
                case "runtime_set":
                case "intermission_set":
                    BumpUI_manager.Instance.fn_show_set_panel(fn_updateto_current_bump, btn_index);
                    break;

                default:
                    break;
                    
            }
        }
  
    }
}
