using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField]
   private float speed = 5.0f;

   [SerializeField]
   private int damage = 1;

   [SerializeField]
   public string targetTag;

    private void Start()
    {
        targetTag = "Player";
    }
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits the target
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Get the object that was hit
            if(collision.gameObject.tag == "Player")
            {
            collision.gameObject.GetComponent<PlayerCharacter>().TakeDamage(damage);
            }       
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
