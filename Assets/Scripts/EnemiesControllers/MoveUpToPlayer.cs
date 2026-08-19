using UnityEngine;

public class MoveUpToPlayer : MonoBehaviour
{
    private GameObject objective;
    public float moveSpeed = 2f;
    public float stopDistance = 1f;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        if (objective != null && 
            (objective.transform.position - transform.position).magnitude > stopDistance)
        {
            direction = (objective.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, moveSpeed * Time.fixedDeltaTime);
        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1,1, 1);

        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1,1, 1);
        }

    }
}
