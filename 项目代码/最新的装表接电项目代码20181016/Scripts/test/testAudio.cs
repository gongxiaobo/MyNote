using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class testAudio : MonoBehaviour {
     public AudioMixerGroup m_mixer;
	// Use this for initialization
	void Start () {
          AudioMixer t_audio = Resources.Load<AudioMixer>("testAudio");
         
          if (t_audio!=null)
          {
               foreach (var item in t_audio.FindMatchingGroups("Master"))
               {
                    
                    if (item.name=="Master")
                    {
                         m_mixer = item;
                    }
               }
              
              
          }
          else
          {
               
               Debug.Log("<color=red>red:</color>");
     
          }
		
	}
     float t_volume = 0f;
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.A))
          {
               m_mixer.audioMixer.SetFloat("MasterVolume", t_volume++);
               
               //Debug.Log("<color=blue>blue:</color>");
     
          }
          if (Input.GetKeyDown(KeyCode.S))
          {
               m_mixer.audioMixer.SetFloat("MasterVolume", t_volume--);

               //Debug.Log("<color=blue>blue:</color>");

          }
          
		
	}
}
