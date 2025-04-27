using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float XValue = 1.0f;

    [SerializeField]
    float ZValue = 1.0f;

    [SerializeField]
    public float moveSpeed = 10.0f;

    void Start()
    {
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(XValue * horizontalInput, 0, ZValue * verticalInput) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
