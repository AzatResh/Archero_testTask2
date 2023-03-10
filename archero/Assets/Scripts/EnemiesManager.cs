using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    public List<Enemy> GetEnemies => enemies;

    private void Start() {
        Enemy.removeEnemyFromList+=RemoveEnemy;
    }

    private void RemoveEnemy(Enemy _enemy){
        enemies.Remove(_enemy);
    }
}
