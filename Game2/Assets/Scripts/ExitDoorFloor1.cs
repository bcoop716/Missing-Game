using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoorFloor1 : MonoBehaviour
{
    
    private bool exitAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorLeft>())
        {
            sceneToLoad = "Floor 1";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorRight>())
        {
            sceneToLoad = "Floor 1";
            exitAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorLeft>() || collision.GetComponent<ExitDoorRight>())
        {
            exitAllowed = false;
        }
    }
    private void Update() 
    {
        if (exitAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            //PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            //PlayerPrefs.SetFloat("PlayerY", transform.position.y);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
