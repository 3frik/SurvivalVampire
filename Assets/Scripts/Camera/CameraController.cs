using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject CenterOfFocus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(CenterOfFocus.transform.position.x, CenterOfFocus.transform.position.y, this.transform.position.z);
        
    }

}
