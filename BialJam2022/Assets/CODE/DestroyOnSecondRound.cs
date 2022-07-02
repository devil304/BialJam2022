using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnSecondRound : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += sceneChanged;
    }

    private void sceneChanged(Scene curr, Scene next)
    {
        if(next.buildIndex>1)
            Destroy(gameObject);
    }
}
