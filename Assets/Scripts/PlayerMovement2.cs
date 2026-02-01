using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 deltaV;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaV = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            deltaV += Vector3.up * speed * Time.deltaTime;
            //transform.position += Vector3.up * speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {
            deltaV += Vector3.right * -speed * Time.deltaTime;
            //transform.position += Vector3.right * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
            deltaV += Vector3.up * -speed * Time.deltaTime;
            //transform.position += Vector3.up * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D))
        {
            deltaV += Vector3.right * speed * Time.deltaTime;
            //transform.position += Vector3.right * speed * Time.deltaTime;

        }

        transform.position += deltaV;
        //print(deltaV);


        /*
         if (Input.GetKey(KeyCode.A)) rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W)) rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(Vector3.down);
         
         */

        //print(rb.linearVelocity);

    }


    void Movement()
    {

    }

    public Vector3 GetMovementVector()
    {
        return deltaV;
    }
}
