using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RightDoor>())
        {
            sceneToLoad = "Floor 1 right";
            enterAllowed = true;
        }
        else if (collision.GetComponent<LeftDoor>())
        {
            sceneToLoad = "Floor1 left";
            enterAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<RightDoor>() || collision.GetComponent<LeftDoor>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", transform.position.y);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
    
