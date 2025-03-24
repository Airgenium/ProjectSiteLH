using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float obstacleRange = 2.0f;

    private bool isAlive;

    private void Start()
    {
        isAlive = true;
    }
     public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    void Update()
    {
        if(isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
            float angle = Random.Range(-110, 110);
            transform.Rotate(0, angle, 0);
            }
        }
    }
}