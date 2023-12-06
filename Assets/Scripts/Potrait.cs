using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotion 
{ 
        Happy,
        Sad,
        Angry,
        Neutral
}

[System.Serializable] //visible in inspector
public class Potrait
{
    public Sprite sprite;
    public Emotion emotion;
}
