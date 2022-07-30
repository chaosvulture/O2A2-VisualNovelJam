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
    public float delay = 2f;
    public static bool isDialogueBeingDisplayed = false;

    private int numberOfTrueBoleans = 0;

    FadeUI _fadeUI;

    int index = 0;

    private Dialogue _dialogue;

    private bool isEndTriggered = false;

    

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
        _buttons.SetActive(false);
        _fadeUI.isFadedOut = true;
        _fadeUI.Fader();
    }

    public void CalculateBools()
    {
        numberOfTrueBoleans++;
        Debug.Log(numberOfTrueBoleans);
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
        isDialogueBeingDisplayed = false;
        _buttons.SetActive(true);
        FindObjectOfType<CinematicBars>().Hide(2);
        
        if (!isEndTriggered)
        {
            FinalDialogue();
        }
        else if (isEndTriggered)
        {
            FindObjectOfType<CinematicBars>().Show(1500, 2);
            _buttons.SetActive(false);
        }

    }

    IEnumerator TriggerEndDialogue()
    {
        FindObjectOfType<CinematicBars>().Show(300, 2);
        yield return new WaitForSeconds(delay);
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    void FinalDialogue()
    {
        if (numberOfTrueBoleans >= 15)
        {
            Debug.Log("Endgame");
            _buttons.SetActive(false);
            StartCoroutine(TriggerEndDialogue());
            isEndTriggered = true;
        }
    }
}
