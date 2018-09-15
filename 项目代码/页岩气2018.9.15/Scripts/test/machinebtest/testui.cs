using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Mode { 
    train,
    exam,
    free,
}
public class testui : MonoBehaviour {

    public void train() {
        testdata.mode = Mode.train;
        SceneManager.LoadScene("main");
    }

    public void exam()
    {

        testdata.mode = Mode.exam;
        SceneManager.LoadScene("main");
    }

    public void free()
    {
        testdata.mode = Mode.free;
        SceneManager.LoadScene("main");
    }
}
