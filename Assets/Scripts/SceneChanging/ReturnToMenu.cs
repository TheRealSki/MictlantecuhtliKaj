﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(0);
        }
    }
    //public void returnToMenuKaj()
    //{
    //    if (Input.GetButtonDown("Submit"))
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}
}
