using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public Character character;
    public Text characterName;
    public Text characterStory;
    //public int pressCounter;

    public void ShowStory(int id)
    {
        characterName.text = character.name;
        EventManager.Instance.ToolsMenu.SetActive(false);
        EventManager.Instance.PeopleMenu.SetActive(false);
        EventManager.Instance.ChallengesMenu.SetActive(false);
        EventManager.Instance.MenuButtons.SetActive(false);
        EventManager.Instance.Info.SetActive(true);

        bool yes = (character.lastUnlockedStory + 1 == character.story.Length);
        if (id == character.characterId)
        {
            EventManager.currentCharacter = character;
            characterStory.text = character.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {character.numberOfPresses[character.lastPressedIndex + 1] - character.pressCounter} times</b>" : "");

            ShowStars(EventManager.Instance.menuButtonId, EventManager.Instance.Info.transform.GetChild(4).gameObject,
               EventManager.Instance.Info.transform.GetChild(5).gameObject);
        }
    }

    public void ShowStars(int index, GameObject star2, GameObject star3)
    {
        GameObject stars1, stars2;
        if (index == 0)
        {
            stars1 = EventManager.Instance.PeopleButtons[EventManager.currentCharacter.characterId].transform.GetChild(2).gameObject;
            stars2 = EventManager.Instance.PeopleButtons[EventManager.currentCharacter.characterId].transform.GetChild(3).gameObject;
        }
        else if (index == 1)
        {
            stars1 = EventManager.Instance.ChallengesButtons[EventManager.currentCharacter.characterId].transform.GetChild(2).gameObject;
            stars2 = EventManager.Instance.ChallengesButtons[EventManager.currentCharacter.characterId].transform.GetChild(3).gameObject;
        }
        else
        {
            stars1 = EventManager.Instance.ToolsButtons[EventManager.currentCharacter.characterId].transform.GetChild(2).gameObject;
            stars2 = EventManager.Instance.ToolsButtons[EventManager.currentCharacter.characterId].transform.GetChild(3).gameObject;
        }
        star2.GetComponent<Image>().sprite = stars1.GetComponent<Image>().sprite;
        star3.GetComponent<Image>().sprite = stars2.GetComponent<Image>().sprite;
    }

    public void Close()
    {
        int id = EventManager.Instance.menuButtonId;
        EventManager.Instance.Info.SetActive(false);
        EventManager.Instance.MenuButtons.SetActive(true);
        if (id == 0) EventManager.Instance.PeopleMenu.SetActive(true);
        else if(id == 1) EventManager.Instance.ChallengesMenu.SetActive(true);
        else EventManager.Instance.ToolsMenu.SetActive(true);
    }

    public void Press()
    {
        if (EventManager.currentCharacter.lastPressedIndex + 1 >= EventManager.currentCharacter.numberOfPresses.Length)
            return;

        bool yes = (EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length);
        EventManager.currentCharacter.pressCounter += 1;
        characterStory.text = EventManager.currentCharacter.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {EventManager.currentCharacter.numberOfPresses[EventManager.currentCharacter.lastPressedIndex + 1] - EventManager.currentCharacter.pressCounter} times</b>" : "");

        if (EventManager.currentCharacter.pressCounter == EventManager.currentCharacter.numberOfPresses[EventManager.currentCharacter.lastPressedIndex + 1])
        {
            EventManager.IncreaseStory += AddStory;
            EventManager.currentCharacter.pressCounter = 0;
            EventManager.Pressed(EventManager.currentCharacter.characterId);
            EventManager.IncreaseStory -= AddStory;
            //EventManager.currentCharacter.IsAllUnlocked = EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length - 1;
        }
    }

    public void AddStory(int id)
    {
        //Debug.Log(character.characterId);
        bool yes = (EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length - 1);
        //id = EventManager.currentCharacter.characterId;
        if (EventManager.currentCharacter.lastUnlockedStory + 1 < EventManager.currentCharacter.story.Length)
        {
            EventManager.currentCharacter.currentStory += "\n" + EventManager.currentCharacter.story[EventManager.currentCharacter.lastUnlockedStory+1];
            characterStory.text = EventManager.currentCharacter.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {EventManager.currentCharacter.numberOfPresses[EventManager.currentCharacter.lastPressedIndex + 2] - EventManager.currentCharacter.pressCounter} times</b>" : "");
            EventManager.currentCharacter.lastUnlockedStory += 1;
            EventManager.currentCharacter.lastPressedIndex += 1;

            int index = EventManager.Instance.menuButtonId;
            GameObject star;
            if (index == 0)
               star = EventManager.Instance.PeopleButtons[EventManager.currentCharacter.characterId].transform.GetChild(EventManager.currentCharacter.lastUnlockedStory + 1).gameObject;
            else if (index == 1)
                star = EventManager.Instance.ChallengesButtons[EventManager.currentCharacter.characterId].transform.GetChild(EventManager.currentCharacter.lastUnlockedStory + 1).gameObject;
            else
                star = EventManager.Instance.ToolsButtons[EventManager.currentCharacter.characterId].transform.GetChild(EventManager.currentCharacter.lastUnlockedStory + 1).gameObject;

            star.GetComponent<Image>().sprite = EventManager.Instance.yellowStar;
            ShowStars(EventManager.Instance.menuButtonId, EventManager.Instance.Info.transform.GetChild(4).gameObject,
              EventManager.Instance.Info.transform.GetChild(5).gameObject);
        }
    }
}
