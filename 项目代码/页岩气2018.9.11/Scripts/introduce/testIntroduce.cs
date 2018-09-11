using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class testIntroduce : MonoBehaviour
     {
          public I_introduceVoice mi_voice;
          public I_introduceDetail mi_detail;
          // Use this for initialization
          void Start()
          {
               mi_voice = GetComponent<I_introduceVoice>();
               mi_detail = GetComponent<I_introduceDetail>();
          }

          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.F))
               {
                    mi_voice.fni_introduceTrigger();
               }
               if (Input.GetKeyDown(KeyCode.G))
               {
                    mi_detail.fni_showTrigger();
               }

          }
     } 
}
