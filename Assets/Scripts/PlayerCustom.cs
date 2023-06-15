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

  public void Awake() {
    this.playerRef = this.gameObject;
    this.origin = this.gameObject.transform.position;
    this.playerFollowCamera = GameObject.Find("PlayerFollowCamera");
    this.vCam = this.playerFollowCamera.GetComponent<CinemachineVirtualCamera>();
  }

  public void deletePlayer() {
    Debug.Log("deletePlayer called");
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

  public void dashPlayer() {
    Debug.Log("trying dash...");
    StartCoroutine(Dash());
  }

  IEnumerator Dash() {
    GameController.INSTANCE.isDashing = true;
    yield return new WaitForSeconds(GameController.INSTANCE.dashTime);
    Debug.Log("stopping dash.");
    GameController.INSTANCE.isDashing = false;
  }

  public void Update() {
    if (this.transform.position.y < -7) {
      deletePlayer();
    }
  }

}
