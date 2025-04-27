using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public Vector3 rotationAxis = new Vector3(0, 1, 0); 
    public float rotationSpeed = 100f; 

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
