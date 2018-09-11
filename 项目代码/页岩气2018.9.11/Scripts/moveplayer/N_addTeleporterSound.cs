using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0309/ :为移动手柄加上音效
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class N_addTeleporterSound : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               Object t_teleportSound = null;
               t_teleportSound = Resources.Load
                    ("prefab_teaching/Prefab_sound/SoundPrefab/" + "TeleporterSound");
               if (t_teleportSound != null)
               {
                    GameObject t_TeleporterSound = Instantiate(t_teleportSound as GameObject);
                    if (t_TeleporterSound != null)
                    {
                         t_TeleporterSound.name = "TeleporterSound";
                         t_TeleporterSound.transform.parent = this.gameObject.transform;
                         t_TeleporterSound.transform.localPosition = Vector3.zero;
                         ArcTeleporter_new t_ArcTeleporter = GetComponent<ArcTeleporter_new>();
                         if (t_ArcTeleporter != null)
                         {
                              t_ArcTeleporter.m_teleporterSound =
                                   t_TeleporterSound.GetComponent<AB_Sound>();
                         }

                    }
               }

               t_teleportSound = null;
               Destroy(this);


          }


     }

}