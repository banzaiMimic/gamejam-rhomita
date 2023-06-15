using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

  private PlayerCustom playerCustom;

  public void Awake() {
    this.playerCustom = this.GetComponent<PlayerCustom>();
  }

  void Start() {
    Debug.Log("PlayerCollisions script loaded");
  }

  private void OnTriggerEnter(Collider other) {
    string colliderName = other.name;

    if (colliderName == "colliderTop") {
      Debug.Log("top of elevator detected -- blow up player");
      this.playerCustom.deletePlayer();

    } else if (colliderName == "colliderBot") {
      Debug.Log("bottom of elevator detected -- dash player forward...");
    }
  }

}
