using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cdp;
namespace GasPowerGeneration
{
     public abstract class AB_handpanel : MonoBehaviour
     {

          protected List<Trigger_handui> triggers = new List<Trigger_handui>();

          protected RectTransform rect;

          protected abstract void fn_get_triggers(Transform trans);

          public abstract void fn_show();

          public abstract void fn_hide();

          public abstract void fn_update_lan();





     }

}