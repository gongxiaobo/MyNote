using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public class Show_bumpparam_light : N_showbumpparam
    {
        private Image light;
        private Sprite on_state;
        private Sprite off_state;
        // Use this for initialization
        protected override void Start()
        {
            base.Start();

            light = transform.GetComponentInChildren<Image>();
            on_state = Resources.Load<SpriteRenderer>(UIdata.ui_sprite_path + "on").sprite;
            off_state = Resources.Load<SpriteRenderer>(UIdata.ui_sprite_path + "off").sprite;
        }
        protected override void fn_show_light(string value)
        {
            if (light == null) print(gameObject.name);
            base.fn_show_light(value);
            print(value);
            if (value == "on")
                light.sprite = on_state;
            else
                light.sprite = off_state;
        }
    }
}
