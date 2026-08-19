using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollectiblesUIController : MonoBehaviour
{
    private Button ReturnButton;
    private Button Hat0Button;
    private Button Hat1Button;
    private Button Hat2Button;
    private Button Hat3Button;
    private Button Hat4Button;
    private Button Hat5Button;

    private Color BgColor = new Color32(42, 11, 113, 255);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        ReturnButton = root.Q<Button>("ReturnButton");
        Hat0Button = root.Q<Button>("hat0Button");
        Hat1Button = root.Q<Button>("hat1Button");
        Hat2Button = root.Q<Button>("hat2Button");
        Hat3Button = root.Q<Button>("hat3Button");
        Hat4Button = root.Q<Button>("hat4Button");
        Hat5Button = root.Q<Button>("hat5Button");

        ReturnButton.RegisterCallback<ClickEvent>(Return);
        Hat0Button.RegisterCallback<ClickEvent>(PutHat0);
        Hat1Button.RegisterCallback<ClickEvent>(PutHat1);
        Hat2Button.RegisterCallback<ClickEvent>(PutHat2);
        Hat3Button.RegisterCallback<ClickEvent>(PutHat3);
        Hat4Button.RegisterCallback<ClickEvent>(PutHat4);
        Hat5Button.RegisterCallback<ClickEvent>(PutHat5);

        UpdateStyles();
    }

    public void Return(ClickEvent clickEvent)
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PutHat0(ClickEvent clickEvent)
    {
        if (HatsController.instance.hatIndex != 0 && HatsController.instance.unblockedHats[0])
        {
            HatsController.instance.hatIndex = 0;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }
    public void PutHat1(ClickEvent clickevent)
    {
        if (HatsController.instance.hatIndex != 1 && HatsController.instance.unblockedHats[1])
        {
            HatsController.instance.hatIndex = 1;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }
    public void PutHat2(ClickEvent clickEvent)
    {
        if (HatsController.instance.hatIndex != 2 && HatsController.instance.unblockedHats[2])
        {
            HatsController.instance.hatIndex = 2;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }
    public void PutHat3(ClickEvent clickEvent)
    {
        if (HatsController.instance.hatIndex != 3 && HatsController.instance.unblockedHats[3])
        {
            HatsController.instance.hatIndex = 3;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }
    public void PutHat4(ClickEvent clickEvent)
    {
        if (HatsController.instance.hatIndex != 4 && HatsController.instance.unblockedHats[4])
        {
            HatsController.instance.hatIndex = 4;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }
    public void PutHat5(ClickEvent clickEvent)
    {
        if (HatsController.instance.hatIndex != 5 && HatsController.instance.unblockedHats[5])
        {
            HatsController.instance.hatIndex = 5;
        }
        else
        {
            HatsController.instance.hatIndex = -1;
        }
        UpdateStyles();
    }

    void UpdateStyles()
    {
        Hat0Button.style.backgroundColor = BgColor;
        Hat1Button.style.backgroundColor = BgColor;
        Hat2Button.style.backgroundColor = BgColor;
        Hat3Button.style.backgroundColor = BgColor;
        Hat4Button.style.backgroundColor = BgColor;
        Hat5Button.style.backgroundColor = BgColor;
        Hat0Button.style.unityBackgroundImageTintColor = Color.black;
        Hat1Button.style.unityBackgroundImageTintColor = Color.black;
        Hat2Button.style.unityBackgroundImageTintColor = Color.black;
        Hat3Button.style.unityBackgroundImageTintColor = Color.black;
        Hat4Button.style.unityBackgroundImageTintColor = Color.black;
        Hat5Button.style.unityBackgroundImageTintColor = Color.black;

        if (HatsController.instance.unblockedHats[0])
        {
            Hat0Button.style.unityBackgroundImageTintColor = Color.white;
        }
        if (HatsController.instance.unblockedHats[1])
        {
            Hat1Button.style.unityBackgroundImageTintColor = Color.white;
        }
        if (HatsController.instance.unblockedHats[2])
        {
            Hat2Button.style.unityBackgroundImageTintColor = Color.white;
        }
        if (HatsController.instance.unblockedHats[3])
        {
            Hat3Button.style.unityBackgroundImageTintColor = Color.white;
        }
        if (HatsController.instance.unblockedHats[4])
        {
            Hat4Button.style.unityBackgroundImageTintColor = Color.white;
        }
        if (HatsController.instance.unblockedHats[5])
        {
            Hat5Button.style.unityBackgroundImageTintColor = Color.white;
        }

        switch (HatsController.instance.hatIndex)
        {
            case 0:
                Hat0Button.style.backgroundColor = Color.blue;
                break;
            case 1:
                Hat1Button.style.backgroundColor = Color.blue;
                break;
            case 2:
                Hat2Button.style.backgroundColor = Color.blue;
                break;
            case 3:
                Hat3Button.style.backgroundColor = Color.blue;
                break;
            case 4:
                Hat4Button.style.backgroundColor = Color.blue;
                break;
            case 5:
                Hat5Button.style.backgroundColor = Color.blue;
                break;
        }
    }
}
