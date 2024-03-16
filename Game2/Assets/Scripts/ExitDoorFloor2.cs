using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorFloor2 : MonoBehaviour
{
    public AudioClip openDoorSound;
    private bool exitAllowed;
    private string sceneToLoad;
    private AudioSource audioSource;
     private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
            PlayerPrefs.SetFloat("PlayerXHidden", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYHidden", transform.position.y);
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorBottomRight>())
        {
            sceneToLoad = "Floor2";
            exitAllowed = true;
        }
        else if (collision.GetComponent<SecretEntranceUnderCarpet>())
        {
            audioSource.PlayOneShot(openDoorSound);
            PlayerPrefs.SetFloat("PlayerXHidden", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYHidden", transform.position.y);
            sceneToLoad = "Floor2 hidden";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorFromHiddenRoom>())
        {
            sceneToLoad = "Floor 2 top right";
            exitAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorBottomLeft>() || collision.GetComponent<ExitDoorTopLeft>() || collision.GetComponent<ExitDoorTopRight>()
        || collision.GetComponent<ExitDoorBottomRight>() || collision.GetComponent<SecretEntranceUnderCarpet>() || collision.GetComponent<ExitDoorFromHiddenRoom>())
        {
            exitAllowed = false;
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
