using UnityEngine;

public class CameraMovement
{
    Transform playerTransform, cameraTransform;
    public CameraMovement(GameObject player, GameObject camera) {
        this.playerTransform = player.transform;
        this.cameraTransform = camera.transform;
    }

    float xRotation = 0f;
    public float playerSpeed = 1f;

    float getClampedRotation(float mouseY) {
        xRotation -= mouseY;

        return xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void listenToMouseInput() {
        float sensitivity = 1000f * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; 
        float rotation = getClampedRotation(mouseY);

        this.playerTransform.Rotate(Vector3.up * mouseX);
        this.cameraTransform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
    }

    public void lockCamera() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}