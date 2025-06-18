using UnityEngine;

public class Boxes : MonoBehaviour
{
     private bool hasScored = false;
     public int boxScore = 10; // Muuttuja pistemäärälle

void OnCollisionEnter(Collision collision)
{
    if (!hasScored && collision.gameObject.CompareTag("scorezone"))
    {
        hasScored = true;
        ScoreManager.Instance.AddScore(boxScore);
    }
}
}
