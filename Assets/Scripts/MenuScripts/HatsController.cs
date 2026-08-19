using UnityEngine;

public class HatsController : MonoBehaviour
{
    internal int hatIndex = -1;
    internal bool[] unblockedHats = new bool[6];

    public static HatsController instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
