using UnityEngine;

public class SlowHomingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        //transform.position += direction * speed * Time.deltaTime;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
