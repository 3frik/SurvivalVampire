using UnityEngine;

public class CollectHat : MonoBehaviour, ICollectible
{
    public int hatIndex;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hat found Player");
            Collect();
        }
    }

    public void Collect()
    {
        Debug.Log("Hatted UP!");
        HatsController.instance.unblockedHats[hatIndex] = true;
        Destroy(gameObject);
    }
}
