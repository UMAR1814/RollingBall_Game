using UnityEngine;

public class WallColorChangeOnCollision : MonoBehaviour
{
    private Renderer wallRenderer;

    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wallRenderer.material.color = Color.red;
        }
    }
}
