﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMain : MonoBehaviour {


    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Main");
    }
}
