using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public Transform body; // Drag PlayerCapsule here
    public float speed = 100f;

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.leftArrowKey.isPressed) body.Rotate(Vector3.up * -speed * Time.deltaTime);
        if (kb.rightArrowKey.isPressed) body.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}