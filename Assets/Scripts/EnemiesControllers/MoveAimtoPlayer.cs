using UnityEngine;

public class MoveAimtoPlayer : MonoBehaviour
{
    private GameObject objective;
    public float moveSpeed = 2f;
    private Vector2 direction = Vector2.zero;


    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player");
        direction = (objective.transform.position - transform.position).normalized;
        //transform.rotation  = Quaternion.LookRotation(direction, Vector3.up); //TO DO: FIX AIMING ROTATION
    }

    void FixedUpdate()
    {

            transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;


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
