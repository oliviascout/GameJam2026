using UnityEngine;

public class MaskSwitching : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //red
        if (Input.GetKey(KeyCode.Alpha1))
        {
            sr.color = new Color(1f, 0f, 0f, 1f);
            
        }

        //orange
        if (Input.GetKey(KeyCode.Alpha2))
        {
            sr.color = new Color(1f, 0.5f, 0f, 1f);

        }

        //yellow
        if (Input.GetKey(KeyCode.Alpha3))
        {
            sr.color = new Color(1f, 1f, 0f, 1f);

        }

        //green
        if (Input.GetKey(KeyCode.Alpha4))
        {
            sr.color = new Color(0f, 1f, 0f, 1f);

        }

        //blue
        if (Input.GetKey(KeyCode.Alpha5))
        {
            sr.color = new Color(0f, 0f, 1f, 1f);

        }

        //purple
        if (Input.GetKey(KeyCode.Alpha6))
        {
            sr.color = new Color(0.75f, 0f, 1f, 1f);

        }

        //white
        if (Input.GetKey(KeyCode.Alpha7))
        {
            sr.color = new Color(1f, 1f, 1f, 1f);

        }



    }
}
