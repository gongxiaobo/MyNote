using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
    public enum showbump_param_type { 
        light=1,
        pointer=2,
        button=3,
        number=4,

    }
    public class N_showbumpparam : AB_showbumpparam
    {

        protected Vector2 param_range;
        public showbump_param_type bump_param_type;

        protected virtual void Start() {

        } 

        public override void fn_set_value(string value)
        {
            base.fn_set_value(value);
            switch (bump_param_type)
            { 
                case showbump_param_type.button:
                    fn_show_button(value);
                    break;
                case showbump_param_type.light:
                    fn_show_light(value);
                    break;
                case showbump_param_type.number:
                    fn_show_number(value);
                    break;
                case showbump_param_type.pointer:
                    fn_show_pointer(value);
                    break;
            }
        }

        protected virtual void fn_show_light(string value) { 

        }

        protected virtual void fn_show_pointer(string value)
        {
           
        }

        protected virtual void fn_show_button(string value)
        { 
        
        }

        protected virtual void fn_show_number(string value)
        { 
        
        }

        private void fn_set_param_range(Vector2 range) {
            param_range.x = range.x;
            param_range.y = range.y;
        }

    }
}
