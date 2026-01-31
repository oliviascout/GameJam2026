using UnityEngine;
using System.Collections;
//using Unity.VisualScripting;

public class BallSpawning : MonoBehaviour
{
    public GameObject ball;
    public Transform ballPos;
    public float timeBtwnSpawn;
    private float timeLastSpawn;

    private GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find objects with the 'player' tag
        player = GameObject.FindGameObjectWithTag("Player");
        timeLastSpawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeLastSpawn >= timeBtwnSpawn)
        {
            spawn();
            timeLastSpawn = Time.time;
        }
        
    }

    void spawn()
    {
        Instantiate(ball, ballPos.position, Quaternion.identity);
    }

}
