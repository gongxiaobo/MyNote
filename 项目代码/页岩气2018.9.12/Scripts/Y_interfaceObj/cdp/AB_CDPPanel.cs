using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GasPowerGeneration;
namespace cdp
{
    public delegate void ChangeHandler(int group_index, int param_index);
    public enum cdp_panel_type { 
        //默认模式
        signal=1,
        
        state=2,

        historyfault=3,

        paramset=4,

        start=5,

        currentfault=6,

        Null=100,



    }
    public abstract class AB_CDPPanel : MonoBehaviour
    {
        

      

        public abstract void fn_show_panel();

        public abstract void fn_hide_panel();



        
    }

    //更新执行委托
    public delegate void UpdateHandler();
    public class S_CDPPanel : AB_CDPPanel,I_Control {
        protected UpdateHandler handler;

        //改变消息委托
        protected ChangeHandler changehandler;
        //界面类型
        public cdp_panel_type panel_type;
        //界面rect
        protected RectTransform rect;
        //高亮提示物体
        protected Transform blink;

        protected N_HandleEvent_init m_handler;

        protected virtual void Awake()
        {
            rect = GetComponent<RectTransform>();
            m_handler = GetComponent<N_HandleEvent_init>();
        }
        protected virtual void Start()
        {
        }
        public override void fn_show_panel()
        {
            rect.localScale = Vector3.one;
            fni_level(1);
        }
        public override void fn_hide_panel()
        {
            rect.localScale = Vector3.zero;
        }

        public virtual void btn_up(bool press) { }
        public virtual void btn_upup(bool press) { }
        public virtual void btn_down(bool press) { }
        public virtual void btn_downdown(bool press) { }
        public virtual void btn_enter(bool press) { }
        public virtual void btn_act(bool press) { }
        public virtual void btn_par(bool press) { }
        public virtual void btn_func(bool press) { }
        public virtual void btn_drive(bool press) { }
        public virtual void btn_loc_rem(bool press) { }
        public virtual void btn_reset(bool press) { }
        public virtual void btn_ref(bool press) { }
        public virtual void btn_start(bool press) { }
        public virtual void btn_forward(bool press) { }
        public virtual void btn_backward(bool press) { }
        public virtual void btn_stop(bool press) { }
        /// <summary>
        /// 开始高亮
        /// </summary>
        public virtual void fn_effect_blink() { }
        /// <summary>
        /// 停止高亮
        /// </summary>
        public virtual void fn_stop_blink() { }

        /// <summary>
        /// 更新执行
        /// </summary>
        /// <param name="time_interval"></param>
        /// <returns></returns>
        protected IEnumerator update_data(float time_interval)
        {
            yield return new WaitForSeconds(0.5f);

            while (handler != null)
            {
                handler();
                yield return new WaitForSeconds(time_interval);
            }

        }
        /// <summary>
        /// 界面间的消息传输方法
        /// </summary>
        /// <param name="changehandler"></param>
        public virtual void fn_changepanelmsg(ChangeHandler changehandler) { }
        /// <summary>
        /// 恢复默认状态
        /// </summary>
        protected virtual void fn_cancelcurrentstate() { }

        protected virtual void fn_blink_mode() {
            if ((int)Time.time % 2 == 0)
            {
                blink.gameObject.SetActive(true);
            }
            else
            {
                blink.gameObject.SetActive(false);
            }
        }

        public virtual void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }

        public virtual void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
        {
        }
    }
    /// <summary>
    /// 添加rpm设置
    /// </summary>
    public class N_CDPPanel : S_CDPPanel
    {

        protected Text rpm_text;

        protected Text local_remote;
        protected override void Awake()
        {
            base.Awake();
            rpm_text = transform.Find("data1/param").GetComponent<Text>();
            local_remote = transform.Find("data1/local_remote").GetComponent<Text>();
        }
        public override void fn_show_panel()
        {
            base.fn_show_panel();
            if(rpm_text!=null)
            rpm_text.text = S_CDPControl.Instance.fn_getMemberValue(1000, 1);
            local_remote.text = S_CDPControl.Instance.fn_getMemberValue(1004, 1);
        }
    }
}