using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Character[] People;
    public Character[] Challenges;
    public Character[] Tools;
    public Button[] ToolsButtons;
    public Button[] PeopleButtons;
    public Button[] ChallengesButtons;
    public GameObject Info;
    public GameObject ToolsMenu;
    public GameObject PeopleMenu;
    public GameObject ChallengesMenu;
    public GameObject MenuButtons;
    public Sprite yellowStar;
    public int menuButtonId;

    public static EventManager Instance { set; get; }
    public static event Action<int> IncreaseStory;
    public static Character currentCharacter;

    private void Awake()
    {
        Instance = this;
    }

    public static void Pressed(int id)
    {
        IncreaseStory?.Invoke(id);
    }

    private void Start()
    {
        for (int i = 0; i < People.Length; i++)
        {
            //People[i].IsAllUnlocked = false;
            People[i].pressCounter = 0;
            People[i].lastPressedIndex = -1;
            People[i].lastUnlockedStory = 0;
            People[i].currentStory = People[i].story[0];
            People[i].characterId = i;
        }

        for (int i = 0; i < Challenges.Length; i++)
        {
            //Challenges[i].IsAllUnlocked = false;
            Challenges[i].pressCounter = 0;
            Challenges[i].lastPressedIndex = -1;
            Challenges[i].lastUnlockedStory = 0;
            Challenges[i].currentStory = Challenges[i].story[0];
            Challenges[i].characterId = i;
        }

        for (int i = 0; i < Tools.Length; i++)
        {
            //Challenges[i].IsAllUnlocked = false;
            Tools[i].pressCounter = 0;
            Tools[i].lastPressedIndex = -1;
            Tools[i].lastUnlockedStory = 0;
            Tools[i].currentStory = Tools[i].story[0];
            Tools[i].characterId = i;
        }
    }

    public void PeopleSelect()
    {
        menuButtonId = 0;
        ToolsMenu.SetActive(false);
        ChallengesMenu.SetActive(false);
        PeopleMenu.SetActive(true);
        for (int i = 0; i < People.Length; i++)
        {
            PeopleButtons[i].gameObject.SetActive(true);
            PeopleButtons[i].GetComponent<ShowCharacter>().character = People[i];
            //Buttons[i].GetComponent<ShowCharacter>().Display();
            PeopleButtons[i].GetComponent<ShowCharacter>().characterStory.text = "";
        }
        for (int i = People.Length; i < PeopleButtons.Length; i++)
           PeopleButtons[i].gameObject.SetActive(false);
    }

    public void ChallengesSelect()
    {
        menuButtonId = 1;
        PeopleMenu.SetActive(false);
        ToolsMenu.SetActive(false);
        ChallengesMenu.SetActive(true);
        for (int i = 0; i < Challenges.Length; i++)
        {
            ChallengesButtons[i].gameObject.SetActive(true);
            ChallengesButtons[i].GetComponent<ShowCharacter>().character = Challenges[i];
            //Buttons[i].GetComponent<ShowCharacter>().Display();
            ChallengesButtons[i].GetComponent<ShowCharacter>().characterStory.text ="";
        }
        for (int i = Challenges.Length; i < ChallengesButtons.Length; i++)
            ChallengesButtons[i].gameObject.SetActive(false);
    }

    public void ToolsSelect()
    {
        menuButtonId = 2;
        PeopleMenu.SetActive(false);
        ChallengesMenu.SetActive(false);
        ToolsMenu.SetActive(true);
        for (int i = 0; i < Tools.Length; i++)
        {
            ToolsButtons[i].gameObject.SetActive(true);
            ToolsButtons[i].GetComponent<ShowCharacter>().character = Tools[i];
            //Buttons[i].GetComponent<ShowCharacter>().Display();
            ToolsButtons[i].GetComponent<ShowCharacter>().characterStory.text = "";
        }
        for (int i = Tools.Length; i < ToolsButtons.Length; i++)
            ToolsButtons[i].gameObject.SetActive(false);

        if (Tools.Length <= 10) ToolsMenu.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
    }
}
