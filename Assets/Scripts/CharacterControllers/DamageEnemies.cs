using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public float damage;
    public float reloadTime = 0.5f;
    private float reloadingTime = 0f;
    private bool damaging = true;

    void FixedUpdate()
    {
        if (!damaging)
        {
            reloadingTime += Time.deltaTime;
            if (reloadingTime > reloadTime) 
            {
                reloadingTime = 0f;
                damaging = true;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Killable>() != null) 
        { 
            collision.gameObject.GetComponent<Killable>().TakeDamage(damage);
            damaging = false;
        }
        if (collision.gameObject.GetComponent<Killable_Boss>()!=null)
        {
            collision.gameObject.GetComponent<Killable_Boss>().TakeDamage(damage);
        }
    }
}
