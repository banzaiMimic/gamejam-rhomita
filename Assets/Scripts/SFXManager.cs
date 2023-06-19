using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXManager : MonoBehaviour {

  static SFXManager _instance;

  private AudioSource musicPlayer;
  private AudioSource sfxPlayer;
  private AudioClip jump;
  private AudioClip coin;
  private AudioClip coinWrong;
  private AudioClip elevatorBottom;

  public static SFXManager INSTANCE {
    get {
      if (_instance == null) {
        GameObject go = new GameObject("SFXManager");
        _instance = go.AddComponent<SFXManager>();
      }
      return _instance;
    }
  }

  public void Awake() {
    Debug.Log("call once awake...");
    this.musicPlayer = this.AddComponent<AudioSource>();
    this.sfxPlayer = this.AddComponent<AudioSource>();
    this.sfxPlayer.volume = 0.3f;

    AudioClip clip1 = (AudioClip)Resources.Load("audio/core-loop-v2");
    jump = (AudioClip)Resources.Load("audio/Jump3");
    coin = (AudioClip)Resources.Load("audio/Pickup_Coin");
    coinWrong = (AudioClip)Resources.Load("audio/Pickup_CoinWrong");
    elevatorBottom = (AudioClip)Resources.Load("audio/Elevator");

    this.musicPlayer.clip = clip1;
    this.musicPlayer.volume = 0.3f;
    this.musicPlayer.Play();

    DontDestroyOnLoad(this);
	}

  public void init() {
    Debug.Log("SFXManager init");
  }

  public void playClip(string clipName) {
    switch (clipName) {
      case "jump":
        this.sfxPlayer.PlayOneShot(jump);
        break;
      case "coin":
        this.sfxPlayer.PlayOneShot(coin);
        break;
      case "coinWrong":
        this.sfxPlayer.PlayOneShot(coinWrong);
        break;
      case "elevatorBottom":
        this.sfxPlayer.PlayOneShot(elevatorBottom);
        break;
      default:
        Debug.Log("no clip found");
        break;
    }
  } 

}
