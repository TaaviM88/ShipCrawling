﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
