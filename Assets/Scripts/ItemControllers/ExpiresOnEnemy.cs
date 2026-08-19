using UnityEngine;

public class ExpiresOnEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Killable>() != null)
        {
            Destroy(gameObject);
        }
    }
}
