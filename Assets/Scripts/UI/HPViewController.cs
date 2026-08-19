using UnityEngine;
using UnityEngine.UIElements;

public class HPViewController : MonoBehaviour
{
    //Itself (1/2)
    public static HPViewController instance { get; private set; }

    public float currentHealth = 1f;
    VisualElement hpBar;

    //Itself (2/2)
    void Awake()
    {
        instance = this;
        UIDocument uiDocument = GetComponent<UIDocument>();
        hpBar = uiDocument.rootVisualElement.Q<VisualElement>("HPLeft");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("There is a HPLeft, isnt it? " + hpBar);
    }

    // Update is called once per frame
    public void SetHealth(float proportion)
    {
        hpBar.style.width = Length.Percent(100*proportion);
    }
}
