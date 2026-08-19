using UnityEngine;

public class ShoutController : MonoBehaviour
{
    public float reloadTime = 4f;
    private float reloadingTimer = 0f;
    public GameObject shout;
    public float shoutDamage;
    public float shoutSpeed;
    public float shoutTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Shout controller has been created");
        Debug.Log("ShoutController created by: " + new System.Diagnostics.StackTrace());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reloadingTimer += Time.deltaTime;
        if (reloadingTimer > reloadTime) {
            reloadingTimer = 0f;
            Debug.Log("ScreamAndShout!!!!");
            GameObject shout1 = Instantiate(shout, CharacterController.instance.transform.position, Quaternion.identity);
            GameObject shout2 = Instantiate(shout, CharacterController.instance.transform.position, Quaternion.identity);
            shout1.GetComponent<MoveInDirection>().direction = Vector2.right;
            shout2.GetComponent<MoveInDirection>().direction = Vector2.left;
            shout1.GetComponent<MoveInDirection>().speed = shoutSpeed;
            shout2.GetComponent<MoveInDirection>().speed = shoutSpeed;
            shout1.GetComponent<ExpiresOnTime>().ExpirationTime = shoutTime;
            shout2.GetComponent<ExpiresOnTime>().ExpirationTime = shoutTime;
            shout1.GetComponent<DamageEnemies>().damage = shoutDamage;
            shout2.GetComponent<DamageEnemies>().damage = shoutDamage;
        }

    }
}
