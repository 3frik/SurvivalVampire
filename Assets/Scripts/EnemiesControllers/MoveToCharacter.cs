using UnityEngine;

public class MoveToCharacter : MonoBehaviour
{

    private GameObject objective;
    public float moveSpeed = 2f;
    private Sprite[] sprites;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites/Enemies/Enemy1");
        objective = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        if (objective != null)
        {
            direction = (objective.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, moveSpeed * Time.fixedDeltaTime);
        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
