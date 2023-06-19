using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    if (colliderTag == Tags.ground.ToString()) {
      GameController.INSTANCE.isGrounded = true;
    } else if (colliderTag == Tags.trampolene.ToString()) {
      this.playerCustom.dashPlayer(GameController.DEFAULT_VELOCITY_Y);
    } else if (colliderTag == Tags.moneda.ToString()) {
      this.playerCustom.damagePlayer(10f);
      Destroy(other.gameObject);
    } else if (colliderTag == Tags.checkpoint.ToString()) {
      this.playerCustom.updateOrigin(other.transform);
    } else if (colliderTag == Tags.exit.ToString()) {
      SceneManager.LoadScene(0);
    }

    if (colliderName == "colliderTop") {
            this.playerCustom.deathPlayer = true;
    } else if (colliderName == "colliderBot") {
      this.playerCustom.dashPlayer(0f);
    }

  }

  private void OnTriggerExit(Collider other) {
    string colliderTag = other.tag;
    if (colliderTag == "ground") {
      GameController.INSTANCE.isGrounded = false;
    }
  }

}
