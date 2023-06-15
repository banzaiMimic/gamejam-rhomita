using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  static GameController _instance;

  public int lives = 3;

  public static GameController INSTANCE {
    get {
      if (_instance == null) {
        GameObject go = new GameObject("GameController");
        _instance = go.AddComponent<GameController>();
      }
      return _instance;
    }
  }
}
