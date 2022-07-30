using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;
    public GameObject _buttons;

    FadeUI _fadeUI;

    int index = 0;

    private Dialogue _dialogue;

    private bool isDialogueBeingDisplayed = false;

    private Queue<string> sentences;

    private DialogueVertexAnimator dialogueVertexAnimator;

    private void Awake()
    {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        sentences = new Queue<string>();
        _fadeUI = GetComponent<FadeUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDialogueBeingDisplayed)
        {
            DisplayNextSentence();
        }
    }

    public void GrabDialogue(Dialogue dialogue)
    {
        _dialogue = dialogue;
        _fadeUI.isFadedOut = true;
        _fadeUI.Fader();
    }

    public void StartDialogue()
    {
        itemNameText.text = _dialogue.itenName;
        sentences.Clear();

        isDialogueBeingDisplayed = true;

        foreach (string s in _dialogue.sentences)
        {
            sentences.Enqueue(s);
        }
        
        _buttons.SetActive(false);

        DisplayNextSentence();
    }

    
    public void DisplayNextSentence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

        string singleSentence = sentences.Dequeue();
        //PlayAudio();
        PlayDialogue(singleSentence);
    }

    private void PlayAudio()
    {
        SoundManager.instance._voiceOverSource.Stop();

        if (index > _dialogue.audioClips.Length)
        {
            return;
        }
        else
        {
            SoundManager.instance.PlayVoiceOverSound(_dialogue.audioClips[index]);
            index++;
        }

    }

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }

    void EndDialogue()
    {
        //SoundManager.instance._voiceOverSource.Stop();
        index = 0;
        _fadeUI.isFadedOut = false;
        _fadeUI.Fader();
        _buttons.SetActive(true);
        isDialogueBeingDisplayed = false;
    }
}
