using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    int score = 0;

    [SerializeField]
    TMPro.TMP_Text tMP_Text;

    void Start()
    {
        score = 0;
        tMP_Text.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.gameObject.name);
        Debug.Log("Trigger entered with tag: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("coins"))
        {
            Debug.Log("Coin collected: " + other.gameObject.name); 
            score++;
            tMP_Text.text = "" + score; 
            Destroy(other.gameObject); 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("wall"))
        {
            score--;
            tMP_Text.text = "" + score;
        }
    }


}