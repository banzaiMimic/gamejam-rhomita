using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  static GameController _instance;

  public const float DEFAULT_VELOCITY_Y = 12f;

  public int lives = 3;
  public bool isDashing = false;
  public bool isGrounded = true;
  public float dashSpeed = 70f;
  public float dashTime = 1 / 2;
  public float dashVelocityY = 0f;
  public float healthAmount = 100f;

	private void Awake()
	{
		var gameControllerInstance = FindObjectsOfType<GameController>();
        if (gameControllerInstance.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
	}

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
