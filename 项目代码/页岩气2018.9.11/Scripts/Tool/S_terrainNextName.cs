using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public static class S_terrainNextName
     {

          public static string fns_terrainName(string _nowTerrain, E_DIR _dir)
          {
               string[] t_names = new string[3];
               t_names[0] = _nowTerrain;
               switch (_nowTerrain)
               {
                    case "c_300_0_l":
                         t_names[0] = "l_300_270_r";
                         t_names[1] = "c_300_270_l";
                         t_names[2] = "c_300_270_r";
                         break;
                    case "c_300_90_l":
                         t_names[0] = "l_300_0_r";
                         t_names[1] = "c_300_0_l";
                         t_names[2] = "c_300_0_r";
                         break;
                    case "c_300_180_l":
                         t_names[0] = "l_300_90_r";
                         t_names[1] = "c_300_90_l";
                         t_names[2] = "c_300_90_r";
                         break;
                    case "c_300_270_l":
                         t_names[0] = "l_300_180_r";
                         t_names[1] = "c_300_180_l";
                         t_names[2] = "c_300_180_r";
                         break;
                    case "c_300_0_r":
                         t_names[0] = "l_300_90_r";
                         t_names[1] = "c_300_90_l";
                         t_names[2] = "c_300_90_r";
                         break;
                    case "c_300_90_r":
                         t_names[0] = "l_300_180_r";
                         t_names[1] = "c_300_180_l";
                         t_names[2] = "c_300_180_r";
                         break;
                    case "c_300_180_r":
                         t_names[0] = "l_300_270_r";
                         t_names[1] = "c_300_270_l";
                         t_names[2] = "c_300_270_r";
                         break;
                    case "c_300_270_r":
                         t_names[0] = "l_300_0_r";
                         t_names[1] = "c_300_0_l";
                         t_names[2] = "c_300_0_r";
                         break;
                    case "l_300_0_r":
                         t_names[0] = "l_300_0_r";
                         t_names[1] = "c_300_0_l";
                         t_names[2] = "c_300_0_r";
                         break;
                    case "l_300_90_r":
                         t_names[0] = "l_300_90_r";
                         t_names[1] = "c_300_90_l";
                         t_names[2] = "c_300_90_r";
                         break;
                    case "l_300_180_r":
                         t_names[0] = "l_300_180_r";
                         t_names[1] = "c_300_180_l";
                         t_names[2] = "c_300_180_r";
                         break;
                    case "l_300_270_r":
                         t_names[0] = "l_300_270_r";
                         t_names[1] = "c_300_270_l";
                         t_names[2] = "c_300_270_r";
                         break;
                    case "l_300_0_l":
                         t_names[0] = "l_300_0_l";
                         t_names[1] = "c_300_0_l";
                         t_names[2] = "c_300_0_r";
                         break;
                    case "l_300_90_l":
                         t_names[0] = "l_300_90_l";
                         t_names[1] = "c_300_90_l";
                         t_names[2] = "c_300_90_r";
                         break;
                    case "l_300_180_l":
                         t_names[0] = "l_300_180_l";
                         t_names[1] = "c_300_180_l";
                         t_names[2] = "c_300_180_r";
                         break;
                    case "l_300_270_l":
                         t_names[0] = "l_300_270_l";
                         t_names[1] = "c_300_270_l";
                         t_names[2] = "c_300_270_r";
                         break;




                    default:
                         break;
               }


               switch (_dir)
               {
                    case E_DIR.e_forward:
                         return t_names[0];
                    case E_DIR.e_right:
                         return t_names[2];
                    case E_DIR.e_left:
                         return t_names[1];
                    default:
                         return "";
               }



          }
     }
     public enum E_DIR
     {
          e_forward = 1,
          e_right = 2,
          e_left = 3,
     }

}