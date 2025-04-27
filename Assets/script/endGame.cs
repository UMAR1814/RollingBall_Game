using UnityEngine;

public class DestroyPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("End"))
        {
            Destroy(gameObject); 
        }
    }
}
