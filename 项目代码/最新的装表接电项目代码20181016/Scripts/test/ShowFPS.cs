using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour {

    public float f_UpdateInterval = 0.5F;

    private float f_LastInterval;

    private int i_Frames = 0;

    private float f_Fps;

    void Start() 
    {
         Application.targetFrameRate = 90;

        f_LastInterval = Time.realtimeSinceStartup;

        i_Frames = 0;
    }

    void OnGUI() 
    {
         GUI.color = Color.red;
        GUI.Label(new Rect(0, 100, 200, 200), "FPS:" + f_Fps.ToString("f2"));
    }
    private float m_checkTime = 1f;
    void Update() 
    {
         i_Frames++;

        //Debug.Log("<color=blue>blue:</color>" + (Time.realtimeSinceStartup - f_LastInterval).ToString());
     
        //if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval) 
        //{
        //     f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);

        //    i_Frames = 0;

        // f_LastInterval = Time.realtimeSinceStartup;
        //}

         f_LastInterval += Time.deltaTime;
         if (f_LastInterval>=m_checkTime)
         {
              f_Fps = i_Frames / f_LastInterval;
              i_Frames = 0;
              f_LastInterval = 0f;
         }

        
    }

    //void LateUpdate()
    //{

    //     f_Fps = 1f / ((Time.realtimeSinceStartup - f_LastInterval));
    //}

}
