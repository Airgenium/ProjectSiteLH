using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int PlayerHealth = 25;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float fireRate = 0.1f;
    private float nextFireTime;
    public bool isAlive = true;

    public void Update()
    {
        if (!isAlive) return;

        if (PlayerHealth <= 0)
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
        PlayerHealth -= damage;
    }

    private void Die()
    {
        Debug.Log("You have died");
        isAlive = false;

        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (movement != null) movement.enabled = false;

    }
}
