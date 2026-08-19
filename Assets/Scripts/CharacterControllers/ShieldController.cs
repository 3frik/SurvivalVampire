using UnityEngine;

public class ShieldController : MonoBehaviour
{

    public float reloadTime = 4f;
    private float reloadingTime = 0f;
    private bool reloading = false;
    public float MaxHP = 20;
    private float HP;
    public Sprite sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reloading)
        {
            reloadingTime += Time.deltaTime;
            if(reloadingTime > reloadTime)
            {
                reloadingTime = 0f;
                HP = MaxHP;
                reloading = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }

        transform.position = CharacterController.instance.transform.position;
    }

    internal void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            reloading = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
