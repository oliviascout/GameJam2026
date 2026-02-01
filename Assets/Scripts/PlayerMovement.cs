using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int maxHealth;
    [SerializeField] private Rigidbody2D rb;

    private Vector3 deltaV;
    private int angleCount; // divisor of the total angle
    private int totalAngle; // all angles totalled
    private int antiFlip;

    public float scoreTimer;

    private float timer;

    private float score = 0;

    public TMP_Text hpText;
    public TMP_Text hsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //hpText = GetComponent<hpText>();
    }

    // Update is called once per frame
    void Update()
    {
        //this vector will be the total of all the 4 movements combined
        deltaV = new Vector3(0, 0, 0);
        angleCount = 0;
        totalAngle = 0;
        antiFlip = 0;

        //text box adjustments
        hpText.text = "Health: " + maxHealth;
        hsText.text = "High-Score: " + score;

        //movement
        //this stops the ball getting shoved around by the projectiles
        rb.linearVelocity = new Vector2(0,0);

        //inputs
        if (Input.GetKey(KeyCode.W))
        {
            deltaV += Vector3.up * speed * Time.deltaTime;
            //transform.position += Vector3.up * speed * Time.deltaTime;
            angleCount++;
            totalAngle += 0;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            deltaV += Vector3.right * -speed * Time.deltaTime;
            //transform.position += Vector3.right * -speed * Time.deltaTime;
            angleCount++;
            totalAngle += 90;
            //transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.S))
        {
            deltaV += Vector3.up * -speed * Time.deltaTime;
            //transform.position += Vector3.up * -speed * Time.deltaTime;
            angleCount++;
            totalAngle += 180;
            antiFlip += 1;
            //transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.D))
        {
            deltaV += Vector3.right * speed * Time.deltaTime;
            //transform.position += Vector3.right * speed * Time.deltaTime;
            angleCount++;
            totalAngle += -90;
            antiFlip += 1;
            //transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        transform.position += deltaV; //now we're setting velocity once at the end
        if (antiFlip == 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, (270+180) / 2);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, totalAngle / angleCount);
        }

        /*
         if (Input.GetKey(KeyCode.A)) rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W)) rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(Vector3.down);
         
         */

        if (Time.time - scoreTimer >= 1)
        {
            score = score + 1;
            scoreTimer = Time.time;
        }





    }


    void Movement()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //player damage
        if (other.gameObject.CompareTag("Enemy"))
        {
            maxHealth = maxHealth - 1;

            if (maxHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    //this getter allows mask 3 to function (lets small enemies move in sync with player so it's more like they're actually circling around you)
    public Vector3 GetMovementVector()
    {
        return deltaV;
    }
}
