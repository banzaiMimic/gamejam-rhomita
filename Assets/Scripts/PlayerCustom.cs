using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * custom functionality added to player aside from PlayerCollisions
 */
public class PlayerCustom : MonoBehaviour {

  private GameObject playerRef;
  private Vector3 origin;
  private GameObject playerFollowCamera;
  private CinemachineVirtualCamera vCam;
  private HealthManager healthManager;

  public void Awake() {
    this.playerRef = this.gameObject;
    this.origin = this.gameObject.transform.position;
    this.playerFollowCamera = GameObject.Find("PlayerFollowCamera");
    this.vCam = this.playerFollowCamera.GetComponent<CinemachineVirtualCamera>();
    this.healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
  }

  public void deletePlayer() {
    if (GameController.INSTANCE.lives > 0) {
      GameController.INSTANCE.lives--;
      Debug.Log($"respawning player... -- lives remaining: {GameController.INSTANCE.lives}");
      Destroy(this.gameObject);
      this.playerRef = Instantiate(Resources.Load("PlayerArmature", typeof(GameObject))) as GameObject;
      this.vCam.Follow = this.playerRef.transform.Find("PlayerCameraRoot");
      this.vCam.LookAt = this.playerRef.transform;
    } else {
      Debug.Log("no lives remaining -- game over");
      Destroy(this.gameObject);
    }

  }

  public void damagePlayer(float damage) {
    this.healthManager.damagePlayer(damage);
  }

  public void healPlayer(float heal) {
    this.healthManager.healPlayer(heal);
  }

  public void dashPlayer(float velocityY) {
    GameController.INSTANCE.dashVelocityY = velocityY;
    StartCoroutine(Dash());
  }

  IEnumerator Dash() {
    GameController.INSTANCE.isDashing = true;
    yield return new WaitForSeconds(GameController.INSTANCE.dashTime);
    GameController.INSTANCE.isDashing = false;
  }

  public void Update() {
    if (this.transform.position.y < -7) {
      deletePlayer();
    }
  }

}
