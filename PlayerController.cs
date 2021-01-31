using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public CharacterController characterController;
    CharacterMovement characterMovementController;
    CameraMovement cameraMovementController;    

    
    void Start() {
        cameraMovementController = new CameraMovement(player, camera);
        characterMovementController = new CharacterMovement(player, characterController);
        
        cameraMovementController.lockCamera();   
    }

    void Update() {
        cameraMovementController.listenToMouseInput();
        characterMovementController.listenToKeyBoardInput();
    }
}