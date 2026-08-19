using UnityEngine;
using UnityEngine.InputSystem;

public class Throwable : MonoBehaviour
{

    public float speed = 2f;
    internal Vector2 throwDirection;
    public bool isAimable = false;
    public float reloadTime = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isAimable)
        {
            Vector3 direction3D = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            direction3D.z = 0;
            throwDirection = ( direction3D - transform.position ).normalized;
        }

        transform.position += new Vector3(throwDirection.x, throwDirection.y, 0) * 0.3f;

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(throwDirection.x, throwDirection.y, 0) * speed * Time.deltaTime;
    }
}
