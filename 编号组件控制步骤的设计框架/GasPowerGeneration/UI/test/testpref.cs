using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testpref : MonoBehaviour
     {

          public bool test;
          public Select_mode mode;

          public Project projecttype;
          public int chapterindex;
          // Use this for initialization
          void Start()
          {
               if (test)
                    PlayerPrefs.SetInt("test", 1);
               else
                    PlayerPrefs.SetInt("test", 0);
               PlayerPrefs.SetInt("index", chapterindex);
               PlayerPrefs.SetString("project", projecttype.ToString().ToLower());
               PlayerPrefs.SetString("mode", mode.ToString());
          }

     }

}