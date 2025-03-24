using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int health = 25;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float fireRate = 0.1f;
    private float nextFireTime;
    private bool isAlive = true;

    private void Update()
    {
        if (!isAlive) return;

        if (health <= 0)
        {
            Die();
        }

        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Die()
    {
        Debug.Log("You have died");
        isAlive = false;

        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (movement != null) movement.enabled = false;

        EnemyStats[] enemies = FindObjectsOfType<EnemyStats>();
        foreach (var enemy in enemies)
        {
            enemy.StopChasing();
        }
    }
}
