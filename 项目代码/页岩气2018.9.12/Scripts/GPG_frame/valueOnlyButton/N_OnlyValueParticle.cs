using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 发电机烟雾粒子的播放
     /// </summary>
     public class N_OnlyValueParticle : N_OnlyValueLogic
     {
          protected override void Start()
          {

               base.Start();
          }
          public ParticleSystem t_ps;
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               fnp_playParticle();
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               fnp_playParticle(false);
          }

          private void fnp_playParticle(bool _isplay = true)
          {
               if (t_ps != null)
               {
                    if (_isplay == false)
                    {
                         t_ps.Stop();
                    }
                    else if (_isplay)
                    {
                         t_ps.Play();
                    }
               }
          }
          private void test()
          {
               fnp_playParticle(false);
          }
          protected virtual void fnp_getParticl()
          {
          }

     }

}