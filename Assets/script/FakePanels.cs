using UnityEngine;
using System.Collections;

public class FakePanels : MonoBehaviour
{
    [SerializeField] private float deactivationDelay = 5f;     // Time before the plank disappears
    [SerializeField] private float reactivationDelay = 2f;     // Time before the plank reappears
    [SerializeField] private Transform playerResetPoint;       // Optional: Reset location if player falls

    private bool playerOnPlank = false;
    private bool isDeactivating = false;
    private MeshRenderer meshRenderer;
    private Collider plankCollider;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        plankCollider = GetComponent<Collider>();

        if (meshRenderer == null)
            Debug.LogError("MeshRenderer not found on " + gameObject.name);

        if (plankCollider == null)
            Debug.LogError("Collider not found on " + gameObject.name);

        if (plankCollider.isTrigger)
            Debug.LogWarning("Plank collider should NOT be a trigger when using collision methods.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDeactivating)
        {
            Debug.Log("Player stepped on plank.");
            playerOnPlank = true;
            StartCoroutine(DeactivatePlank(collision.gameObject));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player left plank.");
            playerOnPlank = false;
        }
    }

    private IEnumerator DeactivatePlank(GameObject player)
    {
        isDeactivating = true;

        yield return new WaitForSeconds(deactivationDelay);

        meshRenderer.enabled = false;
        plankCollider.enabled = false;

        Debug.Log("Plank deactivated");

        yield return new WaitForSeconds(reactivationDelay);

        meshRenderer.enabled = true;
        plankCollider.enabled = true;

        Debug.Log("Plank reactivated");

        isDeactivating = false;

        if (playerOnPlank)
        {
            StartCoroutine(DeactivatePlank(player));
        }

        if (player.transform.position.y < -10f && playerResetPoint != null)
        {
            Debug.Log("Player fell. Resetting position.");
            player.transform.position = playerResetPoint.position;
        }
    }
}
