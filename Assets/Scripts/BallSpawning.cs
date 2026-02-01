using UnityEngine;
using System.Collections;
//using Unity.VisualScripting;

public class BallSpawning : MonoBehaviour
{
    public GameObject ball;
    public Transform ballPos;
    public float timeBtwnSpawn;
    private float timeLastSpawn;
    private float faster;

    private GameObject player;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find objects with the 'player' tag
        player = GameObject.FindGameObjectWithTag("Player");
        timeLastSpawn = 1;
        faster = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Time.time - timeLastSpawn >= timeBtwnSpawn)
        {
            spawn();
            timeLastSpawn = Time.time;

            //get faster
            faster = faster + 1;

            if (faster > 5)
            {
                timeBtwnSpawn = timeBtwnSpawn - 0.25f;

                if (timeBtwnSpawn < 1)
                {
                    timeBtwnSpawn = 1;
                }

                //Debug.Log("logged");
                //Debug.Log(timeBtwnSpawn);
                faster = 0;
            }
        }

        //get faster



    }

    void spawn()
    {
        Instantiate(ball, ballPos.position, Quaternion.identity);
    }

}
