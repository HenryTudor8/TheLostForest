using UnityEngine;

public class BeeCharger : MonoBehaviour
{
    public float chaseSpeed = 6f;
    public float chaseRange = 5f;
    private Transform player;
    private Rigidbody2D rb;
    private bool isCharging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            isCharging = true;
        }

        if (isCharging)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * chaseSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            Vector2 contactDirection = playerRb.linearVelocity;

            if (contactDirection.y < -0.1f) // Player is moving downward
            {
                Debug.Log("Player stomped the bee!");
                Destroy(gameObject); // Kill the bee
            }
            else
            {
                Debug.Log("Bee hit the player from the side.");
                HealthSystem.health--;
            }
        }
    }

}
