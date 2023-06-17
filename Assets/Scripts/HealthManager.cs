using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

  public Image healthBar;

  public void damagePlayer(float damage) {
    GameController.INSTANCE.healthAmount -= damage;
    this.healthBar.fillAmount = GameController.INSTANCE.healthAmount / 100f;
  }

  public void healPlayer(float heal) {
    GameController.INSTANCE.healthAmount += heal;
    GameController.INSTANCE.healthAmount = Mathf.Clamp(GameController.INSTANCE.healthAmount, 0, 100);
    this.healthBar.fillAmount = GameController.INSTANCE.healthAmount / 100f;
  }

}
