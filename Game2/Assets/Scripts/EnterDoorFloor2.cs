using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoorFloor2 : MonoBehaviour
{
    public AudioClip openDoorSound;
    private bool enterAllowed;
    private string sceneToLoad;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(openDoorSound != null)
        {
            audioSource.PlayOneShot(openDoorSound);
        }
        if (collision.GetComponent<BottomLeftDoor>())
        {
            sceneToLoad = "Floor2 bottom left Secret";
            enterAllowed = true;
        }
        else if (collision.GetComponent<TopLeftDoor>())
        {
            sceneToLoad = "Floor2 Top left";
            enterAllowed = true;
        }
        else if (collision.GetComponent<TopRightDoor>())
        {
            sceneToLoad = "Floor 2 top right";
            enterAllowed = true;
        }
        else if (collision.GetComponent<SideDoorBottomRight>())
        {
            sceneToLoad = "Floor2 bottom right";
            enterAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorBottomStairs>())
        {
            sceneToLoad = "Floor 1";
            enterAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BottomLeftDoor>() || collision.GetComponent<TopLeftDoor>() || collision.GetComponent<TopRightDoor>()
        || collision.GetComponent<SideDoorBottomRight>() || collision.GetComponent<ExitDoorBottomStairs>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            PlayerPrefs.SetFloat("PlayerX2", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY2", transform.position.y);
            
            //Load the next scene after small delay to play sound
           SceneManager.LoadScene(sceneToLoad);
        }
    }
}
    
    
