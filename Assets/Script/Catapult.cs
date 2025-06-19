using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Catapult : MonoBehaviour
{
    public Transform launchPosition; // Katapultin kärki, josta hahmo lähtee
    public Rigidbody characterRigidbody; // Hahmon Rigidbody
    private Quaternion bunnyStartPointRotation;

    public float launchForce = 15f;  // Voima, jolla hahmo ammutaan
    public Vector3 launchDirection = new Vector3(1, 1, 0); // Lentosuunnan määrittely
    public Animator catapultAnimator;

    public float rotationSpeed = 50f; // Nopeus jolla katapultti pyörii
    public Transform turret; // Tämä on Catapult_Rotator GameObject

    void Start()
    {
        bunnyStartPointRotation = characterRigidbody.transform.rotation;
    }

    void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reset");
            ResetCatapult();
        }

        // UUSI: T-näppäin aloittaa automaattisen laukaisutestin
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(TestMultipleLaunches(3, 3f));
        }
    }

    void Launch()
    {
        characterRigidbody.isKinematic = false;
        characterRigidbody.transform.parent = null;
        catapultAnimator.SetTrigger("Launch");
        launchDirection = turret.forward + Vector3.up * 0.6f;

        characterRigidbody.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
    }

    void ResetCatapult()
    {
        characterRigidbody.isKinematic = true;
        characterRigidbody.transform.position = launchPosition.position;
        characterRigidbody.transform.rotation = bunnyStartPointRotation;
        characterRigidbody.linearVelocity = Vector3.zero;
        characterRigidbody.angularVelocity = Vector3.zero;
        characterRigidbody.transform.parent = launchPosition;
    }

    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);

        if (characterRigidbody.isKinematic)
        {
            characterRigidbody.transform.position = launchPosition.position;
            characterRigidbody.transform.rotation = launchPosition.rotation * Quaternion.Euler(0, 180, 0);
        }
    }

    // ✅ UUSI: Silmukkafunktio, joka laukoo monta kertaa
    IEnumerator TestMultipleLaunches(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log($"Launch {i + 1}");
            Launch();
            yield return new WaitForSeconds(delay);
            ResetCatapult();
            yield return new WaitForSeconds(0.5f); // pieni tauko resetin jälkeen
        }
    }
}
