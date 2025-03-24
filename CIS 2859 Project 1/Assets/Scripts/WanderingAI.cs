using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float obstacleRange = 2.0f;
    private PlayerCharacter playerScript;  
    [SerializeField] private float chaseRange = 10.0f;

    private bool isAlive;
    private bool isChasing;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        if (player != null)
        {
            playerScript = player.GetComponent<PlayerCharacter>();
        }
        
        isAlive = true;
        isChasing = false;
    }

    void Update()
    {
        if (!isAlive) return;

        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) <= chaseRange && playerScript != null && playerScript.isAlive)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    void ChasePlayer()
    {
        if (player == null) return;
        LookAtPlayer();
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime; 
    }

    void Wander()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    void LookAtPlayer()
{
    if (player == null) return;

    // Rotate towards the player smoothly
    Vector3 direction = (player.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
}

    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
        if (!isAlive)
        {
            isChasing = false;
        }
    }
}