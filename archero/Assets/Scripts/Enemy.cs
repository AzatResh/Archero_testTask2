using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static Action<Enemy> removeEnemyFromList;
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
        
        removeEnemyFromList?.Invoke(this);
        Destroy(gameObject);
    }
}
