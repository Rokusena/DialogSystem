using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog Line", menuName = "Dialog Line")]
public class DialogLine : ScriptableObject
{
    public Emotion emotion;
    public string text;
}
