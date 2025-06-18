using UnityEngine;

public class Laatikko : MonoBehaviour
{
     private bool hasScored = false;
     public int laatikonScore = 10; // Muuttuja pistemäärälle

void OnCollisionEnter(Collision collision)
{
    if (!hasScored && collision.gameObject.CompareTag("pistealue"))
    {
        hasScored = true;
        ScoreManager.Instance.AddScore(laatikonScore);
    }
}
}
