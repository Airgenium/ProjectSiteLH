using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthGain = 2;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            player.PlayerHealth += healthGain;
            Destroy(this.gameObject);
        }
    }
}
