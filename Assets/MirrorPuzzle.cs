using UnityEngine;
using TMPro;

public class MirrorPuzzle : MonoBehaviour
{
    // ADD THIS LINE BELOW:
    public string correctAnswer = "YOUR_PASSWORD_HERE";

    public void CheckAnswer(string input)
    {
        Debug.Log("Player typed: " + input);

        // Now 'correctAnswer' exists, so the line below will work!
        if (input.ToUpper() == correctAnswer.ToUpper())
        {
            Debug.Log("RIGHT ANSWER!");

            FloorProgression doorScript = FindObjectOfType<FloorProgression>();

            if (doorScript != null)
            {
                doorScript.UnlockTheExit();
            }
            else
            {
                Debug.LogError("Could not find FloorProgression script!");
            }
        }
    }
}