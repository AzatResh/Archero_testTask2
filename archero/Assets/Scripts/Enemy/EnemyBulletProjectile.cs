using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2;
    [SerializeField] private int damage = 2;
    [SerializeField] private ParticleSystem particle;
    
    private Rigidbody rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = (transform.forward*bulletSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        Player _player;
        if(other.TryGetComponent<Player>(out _player)){
            _player.TakeDamage(damage);
            ObstacleTrigger();
        }

        if(other.tag == "Wall"){
            ObstacleTrigger();
        }
    }

    private void ObstacleTrigger(){
        ParticleSystem new_particle = Instantiate(particle, transform.position, Quaternion.identity);
        new_particle.Play();
        Destroy(gameObject);
    }
}
