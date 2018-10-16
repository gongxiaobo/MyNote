using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public static class WireColor
     {

          public static E_ropeColor fns_wireColor(string _colorName)
          {
               switch (_colorName)
               {
                  
                    case "blue":
                         return E_ropeColor.e_blue;
                    case "green":
                         return E_ropeColor.e_green;
                    case "red":
                         return E_ropeColor.e_red;
                 
                    case "yellow":
                         return E_ropeColor.e_yellow;
                    case "yellowgreen":
                         return E_ropeColor.e_yellowgreen;
                    default:
                         return E_ropeColor.e_red;
               }
          }
     } 
}
