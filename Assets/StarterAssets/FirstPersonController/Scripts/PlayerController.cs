using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fixedYHeight = 1.1f;
    public Transform cameraTransform; // Drag Main Camera here

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Get movement relative to camera direction
        Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;

        Vector3 moveInput = Vector3.zero;
        if (keyboard.wKey.isPressed) moveInput += forward;
        if (keyboard.sKey.isPressed) moveInput -= forward;
        if (keyboard.dKey.isPressed) moveInput += right;
        if (keyboard.aKey.isPressed) moveInput -= right;

        transform.position += moveInput.normalized * moveSpeed * Time.deltaTime;

        // Lock Y position to the floor height
        transform.position = new Vector3(transform.position.x, fixedYHeight, transform.position.z);
    }
}