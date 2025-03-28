using UnityEngine;

public class PlantProjectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    private static int hitCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("Projectile spawned at: " + transform.position);
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir;
        Destroy(gameObject, 3f); // Self-destruct after 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hitCounter++;
            if (hitCounter % 2 == 0)
            {
                HealthSystem.health--;
                Debug.Log("Plant projectile hit! Player health: " + HealthSystem.health);
            }
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Remove if it hits anything else
        }
    }
}
