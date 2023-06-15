using System;
using UnityEngine;

public sealed class Dispatcher {

  private static readonly Dispatcher instance = new Dispatcher();
  public event Action SpawnPlayerAction;

  static Dispatcher() { }
  private Dispatcher() { }

  public static Dispatcher INSTANCE {
    get {
      return instance;
    }
  }

  public void spawnPlayer() {
    Debug.Log("[Dispatcher] spawnPlayer...");
    SpawnPlayerAction?.Invoke();
  }
}