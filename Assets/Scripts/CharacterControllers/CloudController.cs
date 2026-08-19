using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float reloadTime = 4f;
    private float reloadingTime = 0f;
    public GameObject Cloud;
    public int cloudPower = 5;
    public float expirationTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reloadingTime += Time.deltaTime;
        if (reloadingTime > reloadTime)
        {
            Debug.Log("Spawning new cloud"); 
            reloadingTime = 0;
            GameObject newCloud = Instantiate (Cloud, CharacterController.instance.transform.position, Quaternion.identity);
            newCloud.GetComponent<DamageEnemies>().damage = cloudPower;
            newCloud.GetComponent<ExpiresOnTime>().ExpirationTime = expirationTime;
        }
    }

    internal void PowerUp()
    {
        cloudPower *= 2;
    }
}
