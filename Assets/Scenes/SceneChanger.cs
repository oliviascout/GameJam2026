using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {


    }
    
    public void LoadGame()
    {
        //change number to scene you want

        //title screen is scene 0.
        //sample scene (our final scene maybe?) is scene 1.
        //scenes must be added manually to teh scene list via build profiles
        SceneManager.LoadScene(1);

    }
}
