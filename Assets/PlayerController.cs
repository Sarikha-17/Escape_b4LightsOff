using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLookup : MonoBehaviour
{
    public float lookSpeed = 100f;
    public Transform playerBody; // Drag PlayerCapsule here
    private float xRotation = 0f;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Look Up/Down
        if (keyboard.upArrowKey.isPressed) xRotation -= lookSpeed * Time.deltaTime;
        if (keyboard.downArrowKey.isPressed) xRotation += lookSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate Body Left/Right
        if (keyboard.leftArrowKey.isPressed)
            playerBody.Rotate(Vector3.up * -lookSpeed * Time.deltaTime);
        if (keyboard.rightArrowKey.isPressed)
            playerBody.Rotate(Vector3.up * lookSpeed * Time.deltaTime);
    }
}