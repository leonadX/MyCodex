using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character", menuName ="Character")]
public class Character : ScriptableObject
{
    public enum Role
    {
        Hero,
        Villan,
    };

    public new string name;
    public Role role;
    public string[] story;
    public string currentStory;
    public int characterId;
    public int[] numberOfPresses;
    public int lastPressedIndex;
    public int pressCounter;
    public int lastUnlockedStory;
    //public bool IsAllUnlocked;
}
