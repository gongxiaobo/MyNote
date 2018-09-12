using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public class Show_bumpparam_btn : N_showbumpparam
    {
        //是否为互斥型按钮
        public bool toggle_btn;
        private Image image;
        private List<Trigger_bumpui> toggle_btns;
        // Use this for initialization
        void Start()
        {
            image = GetComponent<Image>();
            //如果是互斥型按钮 先找到子午体重所有的按钮
            if (toggle_btn)
            {
                toggle_btns = new List<Trigger_bumpui>();
                for (int i = 0; i < transform.childCount; i++)
                {
                    toggle_btns.Add(transform.GetChild(i).GetComponent<Trigger_bumpui>());
                }
            }
        }

        protected override void fn_show_button(string value)
        {
            base.fn_show_button(value);
            print("value_change");
           
            if (toggle_btn)
            {
                
                foreach (var item in toggle_btns)
                {
                    Image _iamge=item.GetComponent<Image>();
                    if (item.gameObject.name == value)
                    {
                        _iamge.color = Color.green;
                    }
                    else
                        _iamge.color = Color.white;


                }
                
            }
            else {
                if (value == "on")
                {
                    image.color = Color.green;
                }
                else
                {
                    image.color = Color.white;
                }

            }
            
        }
    }
}
