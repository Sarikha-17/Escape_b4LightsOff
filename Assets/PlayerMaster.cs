using UnityEngine;

public class PlayerMaster : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraRoot;

    [Header("Interaction")]
    public float interactRange = 15f;
    public bool hasHammer = false;
    public Camera mainCam;

    [Header("Passkey System")]
    public string currentInput = "";
    public string correctPasskey = "1045";

    private float xRotation = 0f;
    private bool isUiMode = false;

    void Start()
    {
        // AUTO-FIND: Ensures the script finds your camera even if not assigned in Inspector
        if (mainCam == null) mainCam = Camera.main;
        if (cameraRoot == null && mainCam != null) cameraRoot = mainCam.transform;

        LockCursor();
    }

    void Update()
    {
        // Toggle Mouse (Press E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            isUiMode = !isUiMode;
            if (isUiMode) UnlockCursor();
            else LockCursor();
        }

        // RESET CODE: Press R to clear your typing
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentInput = "";
            Debug.Log("Code Cleared! Start over with 1-0-4-5");
        }

        if (!isUiMode)
        {
            HandleLook();
            HandleMovement();

            // LEFT CLICK TO INTERACT
            if (Input.GetMouseButtonDown(0))
            {
                PerformInteraction();
            }
        }
    }

    void HandleLook()
    {
        if (cameraRoot == null) return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void PerformInteraction()
    {
        if (mainCam == null) return;
        RaycastHit hit;
        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            Debug.Log("Looking at: " + hit.collider.name + " with Tag: " + hit.collider.tag);

            // --- 1. THE HAMMER LOGIC ---
            if (hit.collider.CompareTag("Hammer"))
            {
                hasHammer = true;
                hit.collider.gameObject.SetActive(false);
                Debug.Log("SUCCESS: Hammer is now in inventory!");
                return;
            }

            // --- 2. THE MIRROR SMASH LOGIC ---
            else if (hit.collider.CompareTag("Mirror"))
            {
                if (hasHammer)
                {
                    hit.collider.gameObject.SetActive(false); // This "breaks" the mirror
                    Debug.Log("SUCCESS: Mirror Smashed!");
                }
                else
                {
                    Debug.Log("HINT: You need a hammer to break this mirror!");
                }
                return;
            }

            // --- 3. THE KEYPAD LOGIC ---
            else if (hit.collider.CompareTag("KeypadButton"))
            {
                currentInput += hit.collider.gameObject.name;
                Debug.Log("Typed: " + hit.collider.gameObject.name + " | Total: " + currentInput);

                if (currentInput.Length >= correctPasskey.Length)
                {
                    if (currentInput == correctPasskey)
                    {
                        GameObject door = GameObject.Find("Door");
                        if (door != null) door.SetActive(false);
                        Debug.Log("ACCESS GRANTED!");
                    }
                    else
                    {
                        Debug.Log("WRONG CODE! Clearing...");
                        currentInput = "";
                    }
                }
            }
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isUiMode = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isUiMode = true;
    }
}