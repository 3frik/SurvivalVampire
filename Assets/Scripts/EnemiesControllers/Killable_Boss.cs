using UnityEngine;

public class Killable_Boss : MonoBehaviour
{
    public float HP;
    public GameObject xpTokenPrefab;

    internal void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Instantiate(xpTokenPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
