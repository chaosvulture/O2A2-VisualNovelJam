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

    private void Awake()
    {
        _fadeUI = GetComponent<FadeUI>();
    }

    private void Start()
    {
        buttons.SetActive(false);
    }

    public void PlayGame()
    {
        _fadeUI.isFadedOut = false;
        _fadeUI.Fader();
        buttons.SetActive(true);
        mainMenuButtons.GetComponentInChildren<Button>().interactable = false;
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
