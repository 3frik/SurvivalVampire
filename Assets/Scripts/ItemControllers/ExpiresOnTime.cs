using UnityEngine;

public class ExpiresOnTime : MonoBehaviour
{
    public float ExpirationTime;
    private float ElapsedTime = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        ElapsedTime+= Time.deltaTime;
        if (ElapsedTime > ExpirationTime)
        {
            Destroy(gameObject);
        }
    }
}
