using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingCooldown = 1f;
    private float shootingTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer > shootingCooldown) 
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            shootingTimer = 0f;
        }
        
    }
}
