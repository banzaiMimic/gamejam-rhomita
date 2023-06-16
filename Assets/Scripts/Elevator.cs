using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

  private bool goingUp = true;
  private readonly int yMax = 7;
  private readonly int yMin = -4;
  private readonly double moveSpeed = .02;

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
