using Unity.VisualScripting;
using UnityEngine;

public class MoveHat : MonoBehaviour
{
    private Vector3 correction = new Vector3(0f, 0.47f, 0f);
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    void Start()
    {
        switch (HatsController.instance.hatIndex)
        {
            case -1:
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
                break;
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite0;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite4;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CharacterController.instance.transform.position + correction;
    }
}
