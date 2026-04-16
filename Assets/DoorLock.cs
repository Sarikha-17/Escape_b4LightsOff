using UnityEngine;
using TMPro;

public class DoorManager : MonoBehaviour
{
    public string secretKey = "1045"; // Change this to whatever you want
    public GameObject theDoor; // Drag your door here
    public GameObject theUI;   // Drag your Canvas here

    public void ValidatePassword(string input)
    {
        if (input == secretKey)
        {
            theDoor.SetActive(false); // Door vanishes
            theUI.SetActive(false);   // UI vanishes
            Debug.Log("Password Correct!");
        }
    }
}