using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_soundOnOff : AB_effect
     {

          public List<string> soundname;
          public string chain_name;

          bool on = false;
          protected override void Start()
          {
               base.Start();
               m_effectName = E_effectName.e_sound;
          }
          public override void fn_effect(E_effectType _type, string _para = "")
          {
               if (soundname == null)
               {
                    return;
               }
               if (_type == E_effectType.e_on && on == false)
               {
                    //S_SoundComSingle.Instance.fnp_sound(soundname[0]);
                    S_SoundComSingle.Instance.fn_soundChain(soundname.ToArray(), chain_name);
                    on = true;
               }
               else if (_type == E_effectType.e_off && on == true)
               {
                    S_SoundComSingle.Instance.fn_endSoundChain(chain_name);
                    for (int i = 0; i < soundname.Count; i++)
                    {
                         S_SoundComSingle.Instance.fnp_sound(soundname[i], false);
                    }
                    on = false;
               }

          }
     }

}