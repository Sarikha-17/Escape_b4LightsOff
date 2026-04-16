using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorProgression : MonoBehaviour
{
    private bool isUnlocked = false;

    // This is the function the Mirror calls when the answer is right
    public void UnlockTheExit()
    {
        isUnlocked = true;
        Debug.Log("Door Guard: The exit is now unlocked!");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Does the object walking into the door have the 'Player' tag?
        if (other.CompareTag("Player"))
        {
            if (isUnlocked)
            {
                // Make sure "Floor2" is the exact name of your next scene
                SceneManager.LoadScene("Floor2");
            }
            else
            {
                Debug.Log("Door Guard: You haven't solved the mirror puzzle yet.");
            }
        }
    }
}