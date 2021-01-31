using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public CharacterController characterController;

    public float mouseSpeed;
    public float playerSpeed;

    CharacterMovement characterMovementController;
    CameraMovement cameraMovementController;    
    PlayerInteraction playerInteractionController;    
    
    void BindControllers() {
        cameraMovementController = new CameraMovement(player, camera, mouseSpeed);
        characterMovementController = new CharacterMovement(player, characterController, playerSpeed);
        playerInteractionController = new PlayerInteraction(player);
    }
    
    void Start() {
        BindControllers();
        
        cameraMovementController.LockCamera();   
    }

    void Update() {
        cameraMovementController.ListenToMouseInput();
        characterMovementController.ListenToKeyBoardInput();
        playerInteractionController.ListenToInteraction();
    }
}