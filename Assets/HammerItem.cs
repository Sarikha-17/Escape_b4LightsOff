using UnityEngine;

public class HammerLogic : MonoBehaviour
{
    public float reach = 3.5f;   // How far you can reach
    public bool hasHammer = false;
    public Camera cam;           // Drag Main Camera here

    void Update()
    {
        // Left click or E to interact
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, reach))
        {
            // Pick up hammer
            if (hit.collider.CompareTag("Hammer"))
            {
                hasHammer = true;
                hit.collider.gameObject.SetActive(false); // Hide the hammer
                Debug.Log("GOT HAMMER");
            }

            // Break mirror
            if (hit.collider.CompareTag("Mirror") && hasHammer)
            {
                hit.collider.gameObject.SetActive(false); // Shatter the mirror
                Debug.Log("MIRROR BROKEN");
            }
        }
    }
}