
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;
    public bool iwasActivated = false;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    public void TriggerDialogue()
    {
        dialogueManager.GrabDialogue(dialogue);
        dialogueManager.StartDialogue();
        if (iwasActivated == false)
        {
            iwasActivated = true;
        }

    }



}
