using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorFloor2 : MonoBehaviour
{
    private bool exitAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorBottomLeft>())
        {
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorTopLeft>())
        {
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorTopRight>())
        {
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorBottomRight>())
        {
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
    }
    private void Update() 
    {
        if (exitAllowed && Input.GetKey(KeyCode.Return))
        {
           //Save the player's position before loading the new scene
            //PlayerPrefs.SetFloat("PlayerX2", transform.position.x);
            //PlayerPrefs.SetFloat("PlayerY2", transform.position.y);
            
            //Load the next scene after small delay to play sound
           SceneManager.LoadScene(sceneToLoad);
        }
    }
}
