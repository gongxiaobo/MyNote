using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     public class testCreateSound : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               //S_SoundCreate.Instance.fn_createSoundCom(new string[1]{"bg"});
          }

          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.P))
               {
                    S_SoundComSingle.Instance.fnp_sound("bg");
               }
               if (Input.GetKeyDown(KeyCode.N))
               {
                    SceneManager.LoadScene("createsound1");
               }
               if (Input.GetKeyDown(KeyCode.B))
               {
                    SceneManager.LoadScene("createsound");
               }
          }
     }

}