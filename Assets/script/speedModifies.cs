using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    [Header("Speed Zone Settings")]
    [SerializeField] private bool isSpeedBoost = true; 
    [SerializeField] private Color zoneColor = Color.green;  

    private float speedModifier;

    private void Start()
    {
        if (isSpeedBoost)
        {
            speedModifier = 2.0f;  
            zoneColor = Color.green;
        }
        else
        {
            speedModifier = 0.5f;  
            zoneColor = Color.red;
        }

        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material.color = new Color(
                zoneColor.r, zoneColor.g, zoneColor.b, 0.3f);  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                float originalSpeed = playerMovement.moveSpeed;

                playerMovement.moveSpeed *= speedModifier;

                MeshRenderer playerRenderer = other.GetComponent<MeshRenderer>();
                if (playerRenderer != null)
                {
                    playerRenderer.material.color = zoneColor;
                }

                other.gameObject.AddComponent<SpeedModifier>().originalSpeed = originalSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                SpeedModifier modifier = other.GetComponent<SpeedModifier>();
                if (modifier != null)
                {
                    playerMovement.moveSpeed = modifier.originalSpeed;

                    Destroy(modifier);
                }

                MeshRenderer playerRenderer = other.GetComponent<MeshRenderer>();
                if (playerRenderer != null)
                {
                    playerRenderer.material.color = Color.black; 
                }
            }
        }
    }
}

public class SpeedModifier : MonoBehaviour
{
    public float originalSpeed;
}