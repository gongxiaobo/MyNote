using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{

     ///<summary>
     ///@ version 1.0 /2017.0216/ :读表接口
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public interface I_CSVFactory
     {

          void fni_LoadTable(string _name);
          T fni_ReadTable<T>(string _name, string _index);
     }

}