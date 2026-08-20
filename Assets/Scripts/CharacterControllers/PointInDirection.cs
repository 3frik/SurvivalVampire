using UnityEngine;

public class PointInDirection : MonoBehaviour
{
    public Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate (direction.x - transform.position.x, direction.y - transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
