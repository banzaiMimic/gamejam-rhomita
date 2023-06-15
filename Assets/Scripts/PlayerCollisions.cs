using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

  void Start() {
    Debug.Log("PlayerCollisions script loaded");
  }

  //void OnCollisionEnter(Collision collision) {

    //string colliderName = collision.collider.name;

    //if (colliderName == "colliderTop") {
      //Debug.Log("top of elevator detected -- blow up player");
    //} else if (colliderName == "colliderBot") {
      //Debug.Log("bottom of elevator detected -- dash player forward...");
    //}

  //}

  private void OnTriggerEnter(Collider other) {
    string colliderName = other.name;

    if (colliderName == "colliderTop") {
      Debug.Log("top of elevator detected -- blow up player");
    } else if (colliderName == "colliderBot") {
      Debug.Log("bottom of elevator detected -- dash player forward...");
    }
  }

}
