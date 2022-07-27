using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI dialogueText;

    public float typeSpeed;

    public Animator animator;

    private int index; 
    
    private Queue<string> sentences;

    private void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        itemNameText.text = dialogue.itenName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        SoundManager.instance.PlayVoiceOverSound(dialogue.audioClips[index]);
    }

    // figure out how to increase the dialogue index when DisplayNextSentence is called
    // look into unity event system 
    
    public void DisplayNextSentence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentece(sentence));

        SoundManager.instance._voiceOverSource.Stop();

    }

    IEnumerator TypeSentece(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        index = 0;
    }
}
