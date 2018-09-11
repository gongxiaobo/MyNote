using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{

     /// <summary>
     /// UI初始化类
     /// </summary>
     public class UIInit : MonoBehaviour
     {


          private UI_Manager mUIManager;
          public GameObject cameraEye;
          private void Awake()
          {

               UI_Manager.Instance.InitializeUIs();
               UI_Manager.Instance.ShowUI();
          }





     }

}