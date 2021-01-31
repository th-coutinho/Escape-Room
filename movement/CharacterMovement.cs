using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    CharacterController characterController;
    Transform playerTransform;
    float playerSpeed;
    float defaultPlayerSpeed = 4f;

    public CharacterMovement(GameObject player, CharacterController characterController, float speed) {
        this.characterController = characterController;
        this.playerTransform = player.transform;
        this.playerSpeed = speed > 0 ? speed : defaultPlayerSpeed;
    }

    public void ListenToKeyBoardInput() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = playerTransform.right * x + playerTransform.forward * z;
        characterController.Move(move * this.playerSpeed * Time.deltaTime);
    }
}