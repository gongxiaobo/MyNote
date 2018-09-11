using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{

     public class UILanguageTable
     {

          public readonly string Name;
          /// <summary>
          /// The string chinese.
          /// </summary>
          public readonly string Firstlan;
          /// <summary>
          /// The string english.
          /// </summary>
          public readonly string Secondlan;

          public string CurrentLan()
          {
               // Debug.Log(UIdata.language_type.ToString());
               if (UIdata.language_type == Language.Chinese) return Firstlan;
               else return Secondlan;

          }
     }

}