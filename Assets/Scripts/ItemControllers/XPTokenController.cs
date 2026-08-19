using UnityEngine;

public class XPTokenController : MonoBehaviour
{
    public int xpAmount = 10;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().TakeXP(xpAmount);
            Destroy(gameObject);
        }
    }
}
