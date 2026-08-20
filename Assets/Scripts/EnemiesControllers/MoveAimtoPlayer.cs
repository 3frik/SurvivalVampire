using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAimtoPlayer : MonoBehaviour
{
    public enum objectiveType
    {
        Player,
        Cursor
    }
    public objectiveType objective;
    public float moveSpeed = 2f;
    private Vector2 direction = Vector2.zero;


    void Start()
    {
        switch (objective)
        {
            case objectiveType.Player:
                direction = (CharacterController.instance.transform.position - transform.position).normalized;
                break;
            case objectiveType.Cursor:
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Debug.Log("Aiming to cursor");
                direction = (new Vector3(mousePosition.x,mousePosition.y,0) - transform.position).normalized;
                break;
        }
        transform.right = direction;
    }

    void FixedUpdate()
    {

        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;

        /*
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1,1, 1);

        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1,1, 1);
        }
        */

    }
}
