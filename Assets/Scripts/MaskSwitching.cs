using UnityEngine;

public class MaskSwitching : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    public int mask = 7; //should probably have function to set mask, enums/properties for each mask, so it isn't coincidental. and also make private + getter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if input = key

        //red
        if (Input.GetKey(KeyCode.Alpha1))
        {
            sr.color = new Color(1f, 0f, 0f, 1f);
            mask = 1;
        }

        //orange
        if (Input.GetKey(KeyCode.Alpha2))
        {
            sr.color = new Color(1f, 0.5f, 0f, 1f);
            mask = 2;
        }

        //yellow
        if (Input.GetKey(KeyCode.Alpha3))
        {
            sr.color = new Color(1f, 1f, 0f, 1f);
            mask = 3;
        }

        //green
        if (Input.GetKey(KeyCode.Alpha4))
        {
            sr.color = new Color(0f, 1f, 0f, 1f);
            mask = 4;
        }

        //blue
        if (Input.GetKey(KeyCode.Alpha5))
        {
            sr.color = new Color(0f, 0f, 1f, 1f);
            //mask = 5;
        }

        //purple
        if (Input.GetKey(KeyCode.Alpha6))
        {
            sr.color = new Color(0.75f, 0f, 1f, 1f);
            //mask = 6;
        }

        //white
        if (Input.GetKey(KeyCode.Alpha7))
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
            //mask = 7;
        }



    }
}
