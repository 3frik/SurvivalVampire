using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollectiblesController : MonoBehaviour
{
    private GameObject[] hatButtons = new GameObject[6];
    public int hatIndex = -1;

    private void Start()
    {
        for (int i = 0; i < hatButtons.Length; i++)
        {
            hatButtons[i] = GameObject.Find("Hat"+ (i+1) +"Button");
            Debug.Log(hatButtons[i]);
            if (HatsController.instance.unblockedHats[i])
            {
                hatButtons[i].GetComponent<Image>().tintColor = Color.white;
            }
            else
            {
                hatButtons[i].GetComponent<Image>().tintColor = Color.black;
            }

        }
    }

    public void Return()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SelectHat(int index)
    {
        if (HatsController.instance.unblockedHats[index] && index != HatsController.instance.hatIndex)
        {
            HatsController.instance.hatIndex = index;
        }
        else if(index == HatsController.instance.hatIndex)
        {
            HatsController.instance.hatIndex = -1;
        }
    }
}
