using UnityEngine;

public class Damaging : MonoBehaviour
{
    public int damage = 0;
    public bool diesOnAttack = true;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ShieldController>() != null)
        {
            other.gameObject.GetComponent<ShieldController>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>().TakeDamage(damage);
            Vector3 rndVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            transform.position = other.transform.position + 6f * rndVector;
        }
    }
}
