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
  private int lives = 3;
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
    if (lives > 0) {
      lives--;
      Debug.Log($"respawning player... -- lives remaining: {lives}");
      //Dispatcher.INSTANCE.spawnPlayer();
      //this.gameObject.transform.position = new Vector3(0,0,0);
      //GameObject.Find("PlayerArmature").transform.position = new Vector3(0,0,0);
      //this.GetComponent<PlayerArmature>().transform.position = new Vector3(0,0,0);
      //this.GetComponent<CharacterController>().transform.position = new Vector3(0,0,0);
      Destroy(this.gameObject);
      this.playerRef = Instantiate(Resources.Load("PlayerArmature", typeof(GameObject))) as GameObject;

      //@TODO PlayerFollowCamera needs to update its reference to 
      // PlayerCameraRoot (PlayerArmature > PlayerCameraRoot)
      // PlayerArmature (PlayerArmature)
      
      this.vCam.Follow = this.playerRef.transform.Find("PlayerCameraRoot");
      this.vCam.LookAt = this.playerRef.transform;
    }
    // having issues calling Destroy(this.gameObject) ...
    // will move player to start and remove a life instead to keep moving forward.
    // Destroy(this.gameObject);
  }

  

}
