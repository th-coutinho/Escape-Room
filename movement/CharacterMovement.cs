using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    CharacterController characterController;
    Transform playerTransform;

    public CharacterMovement(GameObject player, CharacterController characterController) {
        this.characterController = characterController;
        this.playerTransform = player.transform;
    }

    float speed = 1f * Time.deltaTime;

    public void listenToKeyBoardInput() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = playerTransform.right * x + playerTransform.forward * z;
        characterController.Move(move * speed);
    }
}