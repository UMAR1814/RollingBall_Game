using UnityEngine;

public class Magnetizer : MonoBehaviour
{
    [Header("Magnet Settings")]
    [SerializeField] private float pullStrength = 10f;
    [SerializeField] private float maxPullDistance = 5f;
    [SerializeField] private bool useToggle = true;
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private bool showDebugGizmos = false;

    private bool isActive = true;

    void Start()
    {
        if (useToggle)
        {
            InvokeRepeating("ToggleMagnetism", 3f, 3f);
        }
    }

    void ToggleMagnetism()
    {
        isActive = !isActive;

        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material.color = isActive ? Color.blue : Color.yellow;
        }
    }

    void FixedUpdate()
    {
        if (!isActive)
            return;

        GameObject player = GameObject.FindWithTag(targetTag);
        if (player == null)
            return;

        Rigidbody targetRb = player.GetComponent<Rigidbody>();
        if (targetRb == null)
            return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= maxPullDistance)
        {
            Vector3 direction = (transform.position - player.transform.position).normalized;

            float proximityFactor = 1f - (distance / maxPullDistance);
            float currentPullStrength = pullStrength * proximityFactor * proximityFactor; 

            targetRb.AddForce(direction * currentPullStrength, ForceMode.Acceleration);
        }
    }

    void OnDrawGizmos()
    {
        if (!showDebugGizmos) return;

        Gizmos.color = isActive ? new Color(0, 0, 1, 0.2f) : new Color(0.5f, 0.5f, 0.5f, 0.2f);
        Gizmos.DrawSphere(transform.position, maxPullDistance);
    }
}