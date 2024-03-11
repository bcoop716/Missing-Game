using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private Vector2 defaultSpawnPoint = new Vector2(0f, 0f);
    [SerializeField] private GameObject playerObject;

    private void Start()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            // Load player's position from PlayerPrefs
            float playerX = PlayerPrefs.GetFloat("PlayerX");
            float playerY = PlayerPrefs.GetFloat("PlayerY");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX, playerY);
            
        }
        else
        {
            // If PlayerPrefs values don't exist, set the player's position to the default spawn point
            player.transform.position = defaultSpawnPoint;
        }
    
    }
}



