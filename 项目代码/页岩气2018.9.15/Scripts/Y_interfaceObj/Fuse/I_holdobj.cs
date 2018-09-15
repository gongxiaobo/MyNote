
using UnityEngine;
namespace GasPowerGeneration
{
     public interface I_holdobj
     {
          void StartHold(Transform hand);

          void EndHold();


     }

     public interface I_holdhandfuse : I_holdobj
     {
          void SetState(handfusestate state);
     }

}