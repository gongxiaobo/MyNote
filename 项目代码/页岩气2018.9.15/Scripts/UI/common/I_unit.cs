using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public interface I_unit
     {

         unit_type get_unit_type { get; }

          string  fn_update_unit();

          string fn_update_value(string value);
     } 
}
