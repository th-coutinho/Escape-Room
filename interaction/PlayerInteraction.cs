using UnityEngine;

public class PlayerInteraction
{
    Transform playerTransform;
    float maxDistance = 2f;
    RaycastHit hit;

    public PlayerInteraction(GameObject player) {
        this.playerTransform = player.transform;
    }

    public void Interact(GameObject hitObject) {
        hitObject.GetComponent<Renderer>().material.color = new Color(0.5f,1,1);
        
        Debug.DrawRay(playerTransform.position, playerTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        Debug.Log("Did Hit");
    }

    public bool HasHitSomething() {
        return Physics.Raycast(playerTransform.position, playerTransform.TransformDirection(Vector3.forward), out hit, maxDistance, 1);
    }

    public void ListenToInteraction() {
        bool hasPressedActionButton = Input.GetButtonDown("Fire1");

        if (hasPressedActionButton) {
            if (HasHitSomething()) {
                GameObject hitObject = hit.transform.gameObject;
                string hitObjectTag = hitObject.tag;

                if (hitObjectTag == "InteractableObject") {
                    Interact(hitObject);
                }
            }
            else
            {
                Debug.DrawRay(playerTransform.position, playerTransform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        } 
    }  
}