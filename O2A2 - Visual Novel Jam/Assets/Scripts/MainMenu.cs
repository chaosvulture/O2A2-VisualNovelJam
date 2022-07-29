using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    FadeUI _fadeUI;
    public GameObject buttons;
    public static bool isMainMenuActive = true;

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
        isMainMenuActive = false;
        Destroy(this, 1.5f);
    }

    public void QuitGame()
    {
        _fadeUI.isFadedOut = true;
        _fadeUI.Fader();
        Application.Quit();
    }
}
