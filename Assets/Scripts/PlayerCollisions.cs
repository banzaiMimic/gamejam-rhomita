using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

  private PlayerCustom playerCustom;

  public void Awake() {
    this.playerCustom = this.GetComponent<PlayerCustom>();
  }

  private void OnCollisionEnter(Collision collision) {
    string colName = collision.gameObject.name;
    Debug.Log($"collision detected with {colName}");
  }

  private void OnTriggerEnter(Collider other) {
    string colliderName = other.name;
    string colliderTag = other.tag;

    handleGroundedEnter(colliderTag);

    if (colliderName == "colliderTop") {
      this.playerCustom.deletePlayer();
    } else if (colliderName == "colliderBot") {
      this.playerCustom.dashPlayer();
    }

  }

  private void OnTriggerExit(Collider other) {
    string colliderTag = other.tag;
    handleGroundedExit(colliderTag);
  }


  private void handleGroundedExit(string colliderTag) {
    if (colliderTag == "ground") {
      Debug.Log($"trigger exit detected with {colliderTag}");
      GameController.INSTANCE.isGrounded = false;
    }
  } 

  private void handleGroundedEnter(string colliderTag) {
    if (colliderTag == "ground") {
      Debug.Log($"trigger enter detected with {colliderTag}");
      GameController.INSTANCE.isGrounded = true;
    }
  }

}
