using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;
    public string playerName;
    public Animator npcFace;
    public Animator playerFace;

    [TextArea(3, 10)]
    public string[] sentences;
}
