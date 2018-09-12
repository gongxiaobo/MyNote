using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     //using GCode;
     ///<summary>
     ///@ version 1.0 /2017.0309/ :找到控制移动的接口
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class S_getArcTeleporter : GenericSingletonClass<S_getArcTeleporter>
     {

          private I_useTelePorter mi_useTelePorter;
          public I_useTelePorter Mi_useTelePorter
          {
               set
               {
                    if (mi_useTelePorter == null)
                    {
                         if (value != null && (value is I_useTelePorter))
                         {
                              mi_useTelePorter = (I_useTelePorter)value;
                         }
                    }
               }
               get { return mi_useTelePorter; }
          }
     }

}