using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 1f;
    internal Vector3 direction3D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //direction = Vector2.zero;
        direction3D = new Vector3(direction.x, direction.y, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + direction3D * speed * Time.deltaTime;
        if (direction3D.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
