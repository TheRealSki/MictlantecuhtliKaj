﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueObject : MonoBehaviour
{
    [TextArea]
    public string dialogue;
    public Position speaker;
    public string speakerName;

    public Sprite image1;
    public Position positionImage1;

    public Sprite image2;
    public Position positionImage2;

    public AudioClip voiceClip;

    private void Start()
    {
        if (positionImage1 == positionImage2)
        {
            positionImage1 = Position.Left;
            positionImage2 = Position.Right;
            Debug.Log("Positions should not be equal to each other");
        }
        if (speakerName == null)
        {
            speakerName = "NULL";
        }
    }
    public enum Position
    {
        Left = 0,
        Right = 1
    }
}
