using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
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
            
            //Load the next scene after small delay to play sound
            Invoke("LoadNextScene", openDoorSound.length); //Adjust delay as needed
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
    
