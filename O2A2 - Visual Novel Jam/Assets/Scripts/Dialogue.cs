using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string itenName;
    public AudioClip[] audioClips;

    [TextArea(3, 10)]
    public string[] sentences;
}
