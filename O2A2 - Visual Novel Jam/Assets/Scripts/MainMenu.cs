using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    FadeUI _fadeUI;
    public GameObject buttons;
    public static bool isMainMenuActive = true;
    public GameObject mainMenuButtons;
    public float delay;
    private DialogueTrigger _dialogueTrigger;

    private void Awake()
    {
        _fadeUI = GetComponent<FadeUI>();
        _dialogueTrigger = GetComponentInChildren<DialogueTrigger>();
    }

    private void Start()
    {
        buttons.SetActive(false);
    }

    public void PlayGame()
    {
        StartCoroutine(SetScene());
    }

    IEnumerator SetScene()
    {
        FindObjectOfType<CinematicBars>().Show(300, delay);
        _fadeUI.isFadedOut = false;
        _fadeUI.Fader();
        mainMenuButtons.GetComponentInChildren<Button>().interactable = false;
        yield return new WaitForSeconds(delay);
        _dialogueTrigger.TriggerDialogue();
        isMainMenuActive = false;
        Destroy(this);
    }

    public void QuitGame()
    {
        _fadeUI.isFadedOut = true;
        _fadeUI.Fader();
        Application.Quit();
    }
}
