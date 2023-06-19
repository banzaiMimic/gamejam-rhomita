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
    [SerializeField]
    private Transform origin;
    private GameObject playerFollowCamera;
    private CinemachineVirtualCamera vCam;
    private HealthManager healthManager;

    public bool deathPlayer = false;
    public bool teleportPlayer = false;
  [SerializeField]
  public Transform devSpawn;


	public void Awake() {
    this.playerRef = this.gameObject;
    print("Posicion inicial: " + origin.position);
    this.playerFollowCamera = GameObject.Find("PlayerFollowCamera");
    this.vCam = this.playerFollowCamera.GetComponent<CinemachineVirtualCamera>();
    this.healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();

    if (this.devSpawn != null) {
      this.playerRef.transform.position = this.devSpawn.position;
    }
    }

  /*public void deletePlayer() {
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

  }*/

    public void updateOrigin(Transform checkpoint) {
      this.origin = checkpoint;  
    }

    public void RespawnPlayer()
    {
		if (GameController.INSTANCE.lives > 0)
		{
			GameController.INSTANCE.lives--;
			Debug.Log($"respawning player... -- lives remaining: {GameController.INSTANCE.lives}");
            playerRef.transform.position = origin.position;
			StartCoroutine(DeathCoroutine());
		}
		else
		{
			Debug.Log("no lives remaining -- game over");
			Destroy(this.gameObject);
		}
    }

    private IEnumerator DeathCoroutine()
    {
		deathPlayer = false;
		yield return new WaitForSeconds(1);
    }

    public void RespawnPlayerTeleport()
    {
		playerRef.transform.position = origin.position;
		StartCoroutine(TeleportCoroutine());
	}

	private IEnumerator TeleportCoroutine()
    {
        teleportPlayer = false;
		yield return new WaitForSeconds(1);
	}

	public void damagePlayer(float damage) {
    this.healthManager.damagePlayer(damage);
    SFXManager.INSTANCE.playClip("coinWrong");
  }

    public void healPlayer(float heal) {
    this.healthManager.healPlayer(heal);
    SFXManager.INSTANCE.playClip("coin");
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

    public void FixedUpdate() {       
	    if (deathPlayer == true)
	    {
		    RespawnPlayer();
	    }
        if (teleportPlayer == true)
        {
            RespawnPlayerTeleport();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ZonaMuerte"))
        {
		    deathPlayer = true;
		    print("entre zona de muerte");
	    }
        if(other.CompareTag("Teleport"))
        {
            teleportPlayer = true;
        }
        
    }

}
