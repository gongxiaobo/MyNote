using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using UnityEngine.UI;
using DG.Tweening;
using GasPowerGeneration;
namespace cdp
{
  

    public class CDPctrl_manager : GenericSingletonClass<CDPctrl_manager>
    {
        bool init;

        public cdp_panel_type start_panel;
        private Panel_CDPParam panel_param;
        public bool param_lock ;

        public bool exist_falut;

        public Vector2 fault_group_range = new Vector2(1001, 1002);
        public Dictionary<int, int> item_groups = new Dictionary<int, int>();
        public Dictionary<int, string> last_fault_group = new Dictionary<int, string>();
        public Dictionary<int, string> current_fault_group = new Dictionary<int, string>();
        private Show_cdpscreen cdpscreen_show;
        // Use this for initialization
        void Awake() {

            panel_param = TransformHelper.FindChild(transform, "Panel_param").GetComponent<Panel_CDPParam>();
            cdpscreen_show = GetComponent<Show_cdpscreen>();
        }
        void Start() {
            Init();
            fn_changepanel(start_panel);
            transform.DOScale(0, 0);
        }
        //void Start()
        //{
        //    Init();
        //}
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (init == false)
            {
                item_groups = S_CDPControl.Instance.fnp_getNumDate();
                if (item_groups.Count == 0)
                {
                    print("获取参数数量字典为空");
                }
                fn_faultitem_find();
                init = true;
            }
            panel_param.fn_change_panel(cdp_panel_type.start);
        }
        /// <summary>
        /// 将item中的事故信息添加到事故字典中
        /// </summary>
        private void fn_faultitem_find(){
            //
            foreach (var item in item_groups)
            {
                //当前故障
                if (item.Key == fault_group_range.x)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        current_fault_group.Add(i + 1, S_CDPControl.Instance.fn_getMemberName((int)fault_group_range.x,i+1));
                    }
                }
                //历史故障
                if (item.Key == fault_group_range.y)
                {

                    for (int i = 0; i < item.Value; i++)
                    {
                        last_fault_group.Add(i + 1, new CDPrandomtime().getrandomtime);
                    }
                }
            }
        
        }

              


        /// <summary>
        /// 切换界面方法
        /// </summary>
        /// <param name="paneltype"></param>
        public void fn_changepanel(cdp_panel_type paneltype) {
            panel_param.fn_change_panel(paneltype);
        }
        /// <summary>
        /// 接收按钮面板传送来的消息
        /// </summary>
        /// <param name="go"></param>
        /// <param name="press"></param>
        public void fn_getbtnmsg(GameObject go,bool press)
        {
            if(panel_param!=null)
            panel_param.fn_btn_click(go, press);
      
        }

        public int fn_getmaxgroup_count() {
            return item_groups.Keys.Count;
        }
        public int fn_getmaxparam_count(int group_index) {
            return item_groups[group_index];
        }
        int index = 0;


        public void fn_panel_sendmsg(ChangeHandler changehandle,cdp_panel_type panel) {
            panel_param.fn_changepanelmsg(changehandle,panel);
        }
        /// <summary>
        /// 发送条件链消息
        /// </summary>
        /// <param name="name"></param>
        public void fn_send_result(string name) {
            cdpscreen_show.fnp_Result(name);
        }
       
    }
}