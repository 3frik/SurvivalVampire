using UnityEngine;

public class MoveOrbiting : MonoBehaviour
{
    private GameObject Centrum;
    public float orbitSpeed = 10f;
    public float orbitRadius = 5f;

    private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            Centrum = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += orbitSpeed * Time.deltaTime;
        Vector3 position = Centrum.transform.position + orbitRadius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        transform.position = position;
    }
}
