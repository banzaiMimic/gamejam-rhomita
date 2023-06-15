using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
  
  public void Awake() {
    Debug.Log("GameController awake.");
    //Dispatcher.INSTANCE.SpawnPlayerAction += spawnPlayer;
    DontDestroyOnLoad(this.gameObject);
  }

  /*
  private void spawnPlayer() {
    Debug.Log("[GameController] spawnPlayer called...");
    StartCoroutine(SpawnPlayer());
  }
  
  IEnumerator SpawnPlayer() {
    Debug.Log("Started Coroutine at timestamp : " + Time.time);
    yield return new WaitForSeconds(2);
    Debug.Log("SpawnPlayer ready after 2 seconds -- : " + Time.time);

    //this.playerRef = Instantiate(Resources.Load("PlayerArmature", typeof(GameObject))) as GameObject;
    this.playerRef.transform.position = this.playerOrigin;
  }
  */

}
