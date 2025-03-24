using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public GameObject bulletPrefab;
    public GameObject enemyBulletSpawn;
    WaveManager waveManager;
    public GameObject blueSpherePrefab;
    public float fireRate = 1f;

    private float nextFireTime;
    private bool isAlive = true;

    void Start()
    {    
        waveManager = GameObject.Find("wavespawnManager").GetComponent<WaveManager>();
        StartCoroutine(FireBulletCoroutine());
    }

    void Update()
    {
        if (isAlive)
        {
            GetComponent<WanderingAI>();
        }
    }

    IEnumerator FireBulletCoroutine()
    {
        while (health > 0)
        {
            if (Time.time > nextFireTime)
            {
                Instantiate(bulletPrefab, enemyBulletSpawn.transform.position, transform.rotation);
                nextFireTime = Time.time + fireRate;
            }
            yield return null;
        }
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        waveManager.enemyCount--;
        this.transform.Rotate(-90, 0, 0);
        yield return new WaitForSeconds(1f);
        Instantiate(blueSpherePrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
