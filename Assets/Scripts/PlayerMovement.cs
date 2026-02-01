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
        //text box adjustments
        hpText.text = "Health: " + maxHealth;
        hsText.text = "High-Score: " + score;

        //movement
        //this stops the ball getting shoved around by the projectiles
        rb.linearVelocity = new Vector2(0,0);

        //inputs
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

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
}
