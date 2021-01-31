using UnityEngine;

public class CameraMovement
{
    Transform playerTransform, cameraTransform;
    float cameraSpeed;
    float defaultCameraSpeed = 500f;

    public CameraMovement(GameObject player, GameObject camera, float speed) {
        this.playerTransform = player.transform;
        this.cameraTransform = camera.transform;
        this.cameraSpeed = speed > 0 ? speed : defaultCameraSpeed;
    }

    float xRotation = 0f;

    float GetClampedRotation(float mouseY) {
        xRotation -= mouseY;

        return xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void ListenToMouseInput() {
        float sensitivity = cameraSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; 
        float rotation = GetClampedRotation(mouseY);

        this.playerTransform.Rotate(Vector3.up * mouseX);
        this.cameraTransform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
    }

    public void LockCamera() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}