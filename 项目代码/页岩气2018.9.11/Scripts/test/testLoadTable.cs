using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testLoadTable : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               S_LoadTable.Instance.fn_loadtable("ui_main", "ui");
          }

          // Update is called once per frame
          void Update()
          {

          }
     } 
}
