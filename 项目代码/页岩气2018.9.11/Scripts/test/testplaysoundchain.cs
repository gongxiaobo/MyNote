using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testplaysoundchain : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               Invoke("fn_play", 18f);
          }
          protected void fn_play()
          {
               S_SoundComSingle.Instance.fn_soundChain(new string[2] { "gas_engine_start", "gas_engine_run" }, "go");
          }
          // Update is called once per frame
          void Update()
          {

          }
     } 
}
