﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEngine : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DialogueListContainer> Scripts = new List<DialogueListContainer>();
    public List<DialogueObject> currentScript;
    public Image CanvasImageLeft;
    public Image CanvasImageRight;
    public Image DialogueBox;
    public Image LeftNameBox;
    public Image NextIndicatorArrow;
    public Text LeftTextBox;
    public Text textBox;
    public bool dialogueTrigger = false;
    public bool dialogueIsActive = false;

    public int currentDialogue = 0;
    private int currentScriptNum = 0;
    public AudioSource voiceAS;

    public bool isEnded = false;
    public TimelineActivatorRevised cutsceneEngine;

    public bool isWaitForDialogue = true;

    void Start()
    {
        NextIndicatorArrow.enabled = false;
        LeftNameBox.enabled = false;
        LeftTextBox.enabled = false;
        currentScript = Scripts[currentScriptNum].Script;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentScriptNum);
        bool dialogueWait;

        if (!isWaitForDialogue)
        {
            dialogueWait = true;
        } else
        {
            dialogueWait = !voiceAS.isPlaying;
        }

        if (dialogueIsActive && !voiceAS.isPlaying)
        {
            NextIndicatorArrow.enabled = true;

        } else
        {
            NextIndicatorArrow.enabled = false;
        }
        if (currentDialogue == 0 && dialogueTrigger && currentDialogue < currentScript.Count && currentScriptNum < Scripts.Count && dialogueWait)
        {
            nextDialogue();
            dialogueIsActive = true;
            dialogueTrigger = false;
            cutsceneEngine.activateNextCutscene();
        } else if (currentDialogue > 0 && Input.GetButtonDown("Fire1") && currentDialogue < currentScript.Count && currentScriptNum < Scripts.Count && dialogueWait)
        {
            nextDialogue();
            cutsceneEngine.activateNextCutscene();
        }

        else if (Input.GetButtonDown("Fire1") && currentDialogue >= currentScript.Count && dialogueWait)
        {
            LeftTextBox.enabled = false;
            LeftNameBox.enabled = false;
            CanvasImageLeft.enabled = false;
            CanvasImageRight.enabled = false;
            DialogueBox.enabled = false;
            textBox.enabled = false;
            currentDialogue = 0;
            currentScriptNum++;
            if (currentScriptNum < Scripts.Count)
            {
                currentScript = Scripts[currentScriptNum].Script;
            }
            dialogueIsActive = false;
            voiceAS.Pause();
            isEnded = true;
            cutsceneEngine.activateNextCutscene();
        }
        
    }

    public void nextDialogue()
    {

        dialogueTrigger = false;
        CanvasImageLeft.enabled = true;
        CanvasImageRight.enabled = true;
        DialogueBox.enabled = true;
        textBox.enabled = true;
        textBox.text = currentScript[currentDialogue].dialogue;
        voiceAS.clip = currentScript[currentDialogue].voiceClip;
        voiceAS.Play();
        LeftTextBox.enabled = true;
        LeftTextBox.text = currentScript[currentDialogue].speakerName;
        LeftNameBox.enabled = true;
        if (currentScript[currentDialogue].positionImage1 == DialogueObject.Position.Left)
        {
            CanvasImageLeft.sprite = currentScript[currentDialogue].image1;
            CanvasImageRight.sprite = currentScript[currentDialogue].image2;
            CanvasImageLeft.preserveAspect = true;
            CanvasImageRight.preserveAspect = true;
            Debug.Log(CanvasImageRight.sprite.name);

        }
        else
        {
            CanvasImageLeft.sprite = currentScript[currentDialogue].image2;
            CanvasImageRight.sprite = currentScript[currentDialogue].image1;
            CanvasImageLeft.preserveAspect = true;
            CanvasImageRight.preserveAspect = true;
        }
        if (currentScript[currentDialogue].speaker == DialogueObject.Position.Left)
        {
            Debug.Log("hit");
            CanvasImageRight.color = new Color32(186, 186, 186, 255);
            CanvasImageLeft.color = Color.white;
        }
        else
        {
            CanvasImageRight.color = Color.white;
            CanvasImageLeft.color = new Color32(186, 186, 186, 255);
        }
        currentDialogue++;
    }
}
