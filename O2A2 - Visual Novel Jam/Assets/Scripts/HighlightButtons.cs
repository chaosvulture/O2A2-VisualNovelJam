using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightButtons : MonoBehaviour
{
    public Button[] buttons;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.isDialogueBeingDisplayed == false)
        {
            foreach (Button b in buttons)
            {
                b.animator.Play("Highlighted");
                Debug.Log("I work :)");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && DialogueManager.isDialogueBeingDisplayed == false)
        {
            foreach (Button b in buttons)
            {
                b.animator.Play("Normal");
                Debug.Log("I WORK!");
            }
        }

    }
}
