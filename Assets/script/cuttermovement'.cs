using UnityEngine;

public class cutterRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;

    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(Time.deltaTime * rotationSpeed, 0, 0);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 5), transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 4), transform.position.z);



    }
}