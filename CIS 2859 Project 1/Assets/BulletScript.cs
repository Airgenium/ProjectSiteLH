using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField]
   private float speed = 5.0f;

   [SerializeField]
   private int damage = 1;

   [SerializeField]
   public string targetTag;

    private void Start()
    {
        targetTag = "Enemy";
    }
    // Update is called once per frame
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
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }   
}