using UnityEngine;

public class DraggedToPlayer : MonoBehaviour
{
    private GameObject objective;
    public float dragForce = 4f;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 distance = objective.transform.position - transform.position;
        float moveSpeed = dragForce - distance.magnitude * 1f;
        if (moveSpeed > 0)
        {
            Vector2 position = (Vector2)transform.position + distance.normalized * moveSpeed * Time.deltaTime;
            transform.position = position;
        }
    }
}
