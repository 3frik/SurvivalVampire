using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 100f;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
