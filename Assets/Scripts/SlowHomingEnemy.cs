using UnityEngine;

public class SlowHomingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    public float health;
    [SerializeField] private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = 10;
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        //transform.position += direction * speed * Time.deltaTime;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        //health colour
        sr.color = new Color(1f, health / (float)10.0, health / (float)10.0, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<AffectedHomingEnemy>() != null)
            {
                //remove health and die if we lose health
                print(other.gameObject.GetComponent<AffectedHomingEnemy>().GetHeldSpeed());
                health = health - other.gameObject.GetComponent<AffectedHomingEnemy>().GetHeldSpeed();
                if (health < 0) {
                    Destroy(gameObject);
                }
            }

        }

        //Destroy(gameObject);
    }
}
