using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{

     public class FlyMode : MonoBehaviour
     {
          private SteamVR_TrackedObject trackObj;
          private SteamVR_TrackedController control;
          private SteamVR_Controller.Device device;
          public float moveSpeed;
          public GameObject fly_machine;
          //private Rigidbody rig;
          // Use this for initialization
          void Start()
          {
               trackObj = GetComponent<SteamVR_TrackedObject>();
               control = GetComponent<SteamVR_TrackedController>();
               //fly_machine.SetActive(false);
               //device = SteamVR_Controller.Input((int)trackObj.index);
          }

          // Update is called once per frame
          void Update()
          {
               if (device == null)
                    device = SteamVR_Controller.Input((int)trackObj.index);
               if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
               { //按下扳机键时触发

                    transform.GetComponent<BoxCollider>().enabled = true;
                    transform.parent.transform.position += (transform.forward * moveSpeed * Time.deltaTime);
                    //fly_machine.SetActive(true);
                    if (transform.parent.position.y < 0)
                    {
                         var z = transform.parent.position;
                         z.y = 0;
                         transform.parent.position = z;
                    }
                    //rig.WakeUp ();
               }
               else
               {
                    transform.GetComponent<BoxCollider>().enabled = false;
                    //fly_machine.SetActive(false);
               }

          }
          void OnTriggerStay(Collider other)
          {
               //print(other.name);
               if (other.gameObject.layer == 12)
                    transform.parent.transform.position -= (transform.forward * moveSpeed * Time.deltaTime);

          }
          void OnTrggerEnter(Collider other)
          {
               // print(other.name);
               if (other.gameObject.layer == 12)
                    transform.parent.transform.position -= (transform.forward * moveSpeed * Time.deltaTime);
          }
     }

}