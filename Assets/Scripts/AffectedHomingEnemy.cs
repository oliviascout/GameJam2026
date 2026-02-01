using UnityEngine;

public class AffectedHomingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Rigidbody2D player_rb;
    public float speed;
    private float modifier1;
    private float modifier2 = (float) 1.0;
    private float dragslow;
    private float anglediff;
    private float scaleDrag;
    private float heldSpeed;

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

        // enemy will go away from player if mask 1 is equipped
        MaskSwitching maskdata = player.GetComponent<MaskSwitching>();
        PlayerMovement2 playermove = player.GetComponent<PlayerMovement2>();

        if ( maskdata.mask == 2)
        {
            modifier1 = (float) -1.0;
        } 
        else
        {
            modifier1 = (float)1.0;
        }

        if (maskdata.mask  == 1)
        {
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * Mathf.Max(speed, heldSpeed - (float)0.005);
            heldSpeed = rb.linearVelocity.magnitude;
        }
        else if (maskdata.mask == 2)
        {
            //negated and has 0.5 instead of speed... so it cant go backwards too fast (or it's too strong)
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * (float)-1.0 * Mathf.Max((float)0.5, heldSpeed - (float)0.005);
            heldSpeed = rb.linearVelocity.magnitude;
        }
        else if (maskdata.mask == 3)
        {
            //modifier2 = (float)-1.0;
            Vector3 playerVector = playermove.GetMovementVector();
            Vector2 moveWithPlayerVector = new Vector2(playerVector.x, playerVector.y).normalized; //this component will allow enemies to move kinda along with the player
            // enemy will circle clockwise and slowly move towards the player
            // it will either go the speed setting or perfectly preserve existing momentum if it was higher than speed
            //rb.linearVelocity = new Vector2(-direction.y + modifier2 * direction.x, direction.x + modifier2 * direction.y).normalized * modifier1 * Mathf.Max(speed, heldSpeed) + playerVector2;
            // will move towards player at rate of 1.0, with extra scale value to make it move faster when further. direction.magnitude is about 10 at border
            Vector2 moveTowardsPlayer = new Vector2(direction.x, direction.y).normalized * ((float)1.0 + (direction.magnitude * (float)0.2));
            //clockwise + move towards + move with
            rb.linearVelocity = new Vector2(-direction.y, direction.x).normalized * modifier1 * Mathf.Max(speed, heldSpeed) + moveTowardsPlayer + moveWithPlayerVector;
            //heldSpeed = rb.linearVelocity.magnitude;
        }
        else if (maskdata.mask == 4)
        {
            //the ball accelerates towards the player's position, while maintaining it's own inertia (it will orbit around, but try to accelerate towards the player)
            //the ball has a drag that makes it slow down when going away from the player, but not when going towards, so the ball can go fast without flying too far past
            anglediff = Vector2.Angle(rb.linearVelocity, new Vector2(direction.x, direction.y)); // difference between where ball is going and where ball is pointing
            //scaleDrag = Mathf.Sin(Mathf.Deg2Rad * anglediff * (float)(0.5)); // heading directly towards player is 0, directly away is 1

            // heading directly towards player (0 deg) is 0, perpendicular (90 deg) or away (180 deg) is 1. In between 0-90 is in between 0-1 (sin of angle)
            scaleDrag = Mathf.Sin(Mathf.Deg2Rad * Mathf.Min(anglediff, (float)90.0));
            //print(scaleDrag);

            //distance.magnitude is strength of difference in distance between enemy and player
            dragslow = scaleDrag * direction.magnitude * (float)0.0003; // (usually direction.magnitude is at around 10 at the screen border.
            //print(dragslow);
            rb.linearVelocity = (float)(0.9998 - dragslow) * rb.linearVelocity + new Vector2(direction.x, direction.y).normalized * (float)0.003 * speed;
            heldSpeed = rb.linearVelocity.magnitude;
        }
        //else
        //{
            //modifier2 = (float)1.0;
            //Vector2 desiredDirection = new Vector2(direction.x, direction.y).normalized * modifier1 * speed;
            //print(desiredDirection - rb.linearVelocity);
            //print((desiredDirection - rb.linearVelocity).magnitude);

            //this code will slow down the enemies from the existing velocity into the supposed velocity
            //Vector2 differenceInDesiredSpeed = desiredDirection - rb.linearVelocity;
            //rb.linearVelocity = rb.linearVelocity + differenceInDesiredSpeed * (float)0.01;

            //rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * modifier1 * speed;
            //this code will instantly make the velocity go towards the player if mask 1 (or away if mask 2), and keep the previous inertia and slowly bleed it until it's normal speed
            //rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * modifier1 * Mathf.Max(speed, heldSpeed - (float)0.01);
            //heldSpeed = rb.linearVelocity.magnitude;
        //}
        print(rb.linearVelocity.magnitude);

        //rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * modifier1 * speed;
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