using UnityEngine;

public class ExpiresOnContact : MonoBehaviour
{
    public GameObject expirer;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(expirer == other.gameObject)
        {
            Destroy(gameObject);
        }
        
    }
}
