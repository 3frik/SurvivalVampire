using System;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelUpController : MonoBehaviour
{
    UIDocument uiDocument;
    internal static LevelUpController instance;
    Button Reward1Button;
    Action Button1Action = null;
    Button Reward2Button;
    Action Button2Action = null;
    Button Reward3Button;
    Action Button3Action = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        uiDocument = GetComponent<UIDocument>();
        uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        Reward1Button = uiDocument.rootVisualElement.Q<Button>("Reward1");
        Reward1Button.clicked += UnPause;
        Reward2Button = uiDocument.rootVisualElement.Q<Button>("Reward2");
        Reward2Button.clicked += UnPause;
        Reward3Button = uiDocument.rootVisualElement.Q<Button>("Reward3");
        Reward3Button.clicked += UnPause;
    }

    // Update is called once per frame
    void UnPause()
    {
        uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1.0f;
    }

    internal void Pause()
    {
        uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0.0f;

        //Chose randomly 3 powers to upgrade
        Debug.Log(CharacterController.instance + " has a " + CharacterController.instance.powers);
        int upgrade1Index = UnityEngine.Random.Range(0, CharacterController.instance.powers.Count - 2);
        int upgrade2Index = UnityEngine.Random.Range(upgrade1Index + 1, CharacterController.instance.powers.Count - 1);
        int upgrade3Index = UnityEngine.Random.Range(upgrade2Index + 1, CharacterController.instance.powers.Count);
        Debug.Log("Paused. Indexed: "+upgrade1Index+" , "+upgrade2Index+" and "+upgrade3Index);

        //Edit the three buttons so they show those powers
        Reward1Button.Q<Label>("Label").text=CharacterController.instance.powers[upgrade1Index].name;
        Reward1Button.Q<Image>("Image").sprite= CharacterController.instance.powers[upgrade1Index].sprite;
        Reward1Button.clicked -= Button1Action;
        Button1Action = CharacterController.instance.powers[upgrade1Index].onLevelUp;
        //The text depends on the power being got for the first time or being upgraded.
        if (CharacterController.instance.powers[upgrade1Index].level > 0)
        {
            Reward1Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade1Index].description;
        }
        else
        {
            Reward1Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade1Index].presentation;
        }
        //Add also functionality
        Reward1Button.clicked += Button1Action;

        //Now button 2
        Reward2Button.Q<Label>("Label").text = CharacterController.instance.powers[upgrade2Index].name;
        Reward2Button.Q<Image>("Image").sprite = CharacterController.instance.powers[upgrade2Index].sprite;
        Reward2Button.clicked -= Button2Action;
        Button2Action = CharacterController.instance.powers[upgrade2Index].onLevelUp;
        if (CharacterController.instance.powers[upgrade2Index].level > 0)
        {
            Reward2Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade2Index].description;
        }
        else
        {
            Reward2Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade2Index].presentation;
        }
        Reward2Button.clicked += Button2Action;
        
        //And now button 3
        Reward3Button.Q<Label>("Label").text = CharacterController.instance.powers[upgrade3Index].name;
        Reward3Button.Q<Image>("Image").sprite = CharacterController.instance.powers[upgrade3Index].sprite;
        Reward3Button.clicked -= Button3Action;
        Button3Action = CharacterController.instance.powers[upgrade3Index].onLevelUp;
        if (CharacterController.instance.powers[upgrade3Index].level > 0)
        {
            Reward3Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade3Index].description;
        }
        else
        {
            Reward3Button.Q<Label>("Description").text = CharacterController.instance.powers[upgrade3Index].presentation;
        }
        Reward3Button.clicked += Button3Action;
        Debug.Log("All buttons ok");
    }
}
