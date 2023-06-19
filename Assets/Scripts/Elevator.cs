using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

  [SerializeField]
  private bool goingUp = true;

  [SerializeField]
  private int yMax = 7;

  [SerializeField]
  private int yMin = -4;

  [SerializeField]
  private double moveSpeed = .02;

  private void Update() {
    if (goingUp) {
      if (this.transform.position.y < this.yMax) {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float)this.moveSpeed, this.transform.position.z);
      } else {
        goingUp = false;
      }
    } else {
      if (this.transform.position.y > this.yMin) {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (float)this.moveSpeed, this.transform.position.z);
      } else {
        goingUp = true;
      }
    }
  }
}
