using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;            // Referência ao jogador
    public Transform cameraTransform;   // Referência à câmera
    public float mouseSensitivity = 3f;
    public float distanceFromPlayer = 5f;
    public float heightOffset = 2f;
    public float horizontalOffset = 0f; // deslocamento lateral da câmera

    public float rotationSmoothTime = 0.1f;

    private float yaw;  // Rotação horizontal
    public float yawOffsetRunning = 0f;
    public float yawOffset = 0f;

    private float pitch; // Rotação vertical
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Lê o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -35f, 60f);

        // Aplica suavização de rotação
        Vector3 targetRotation = new Vector3(pitch, yaw + yawOffset);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetRotation = new Vector3(pitch, yaw + yawOffsetRunning);
        }
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        // Posiciona e rotaciona a câmera
        cameraTransform.eulerAngles = currentRotation;
        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
        Vector3 offset = cameraTransform.right * horizontalOffset;
        cameraTransform.position = player.position + Vector3.up * heightOffset + cameraTransform.rotation * direction + offset;

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // Faz o player olhar para frente baseado na rotação horizontal
            Vector3 desiredForward = Quaternion.Euler(0, yaw, 0) * Vector3.forward;
            Quaternion targetRotation2 = Quaternion.LookRotation(desiredForward);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation2, Time.deltaTime * 10f); // Ajusta a velocidade (10f)

        }

    }
}
