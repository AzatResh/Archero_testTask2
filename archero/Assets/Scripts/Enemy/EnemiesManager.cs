using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<Enemy> enemies;
    public List<Enemy> GetEnemies => enemies;

    private void Start() {
        Enemy.removeEnemyFromList+=RemoveEnemy;
        foreach(Enemy enemy in enemies){
            EnemyShoot shoot;
            if(enemy.TryGetComponent<EnemyShoot>(out shoot)){
                shoot.SetPlayer(player.transform);
            }
            EnemyMovement agent;
            if(enemy.TryGetComponent<EnemyMovement>(out agent)){
                agent.SetTarget(player.transform);
            }
        }
    }

    private void RemoveEnemy(Enemy _enemy){
        enemies.Remove(_enemy);
    }
}
