using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CollectRock : MonoBehaviour, ICollectible
{
    /*
    public GameObject throwable;
    private CharacterController Vampire;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rock collected!");
        Vampire = other.GetComponent<CharacterController>();
        if (Vampire.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
    */
    public void Collect()
    {
        /*
        Vampire.throwPreFab = throwable;
        Vampire.throwCooldown = throwable.GetComponent<Throwable>().reloadTime;
        Destroy(gameObject);
        */
    }
    
}
