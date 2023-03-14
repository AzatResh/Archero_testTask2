using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerMovement), (typeof(PlayerShoot)))]
public class Player : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int MaxHealth = 10;
    private int currentHealth;

    private void Start() {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int _damage){
        currentHealth -= _damage;
        CheckDeath();
    }

    public void CheckDeath(){
        if(currentHealth>0) return;

        uiManager.ShowGameOverMenu();
        Destroy(gameObject);
    }
}
