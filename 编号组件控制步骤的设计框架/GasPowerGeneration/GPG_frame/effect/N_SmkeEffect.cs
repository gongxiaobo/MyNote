using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_SmkeEffect : AB_effect
     {
          protected override void Start()
          {
               base.Start();
               m_effectName = E_effectName.e_light;
               if (m_light == null)
               {
                    m_light = GetComponent<ParticleSystem>();
               }
               if (m_light != null)
               {
                    //m_light.playOnAwake = false;
                    var _main = m_light.main;
                    _main.playOnAwake = false;

                    //m_light.main.playOnAwake = false;

               }
          }
          protected ParticleSystem m_light = null;
          public override void fn_effect(E_effectType _type, string _para = "")
          {

               if (_type == E_effectType.e_on)
               {
                    if (m_light != null)
                    {
                         var main = m_light.main;
                         main.simulationSpeed = 1f;
                         //m_light.playbackSpeed = 1f;
                         m_light.Play();
                    }
               }
               else if (_type == E_effectType.e_off)
               {
                    if (m_light != null)
                    {
                         var main = m_light.main;
                         main.simulationSpeed = 6f;
                         //m_light.playbackSpeed = 6f;
                         m_light.Stop(true, ParticleSystemStopBehavior.StopEmitting);

                    }
               }

          }
     }

}