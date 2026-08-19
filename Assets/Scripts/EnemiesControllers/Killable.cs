using UnityEngine;

public class Killable : MonoBehaviour
{
    public float HP;
    public GameObject xpTokenPrefab;
    public int xpAmount = 10;
    public int waveValue = 10;
    public int level = 1;

    internal void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Spawner.instance.GetComponent<Spawner>().EnemyDown(gameObject);
            DropXPToken();
            Destroy(gameObject);
        }
    }

    internal void DropXPToken()
    {
        GameObject xpToken = Instantiate(xpTokenPrefab, transform.position, Quaternion.identity);
        xpToken.GetComponent<XPTokenController>().xpAmount = xpAmount;
    }
}
