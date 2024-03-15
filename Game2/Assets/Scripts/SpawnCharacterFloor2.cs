using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterFloor2 : MonoBehaviour
{

    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Load player's position from PlayerPrefs if needed
        if (PlayerPrefs.HasKey("PlayerX2") && PlayerPrefs.HasKey("PlayerY2"))
        {
            // Load player's position from PlayerPrefs
            float playerX2 = PlayerPrefs.GetFloat("PlayerX2");
            float playerY2 = PlayerPrefs.GetFloat("PlayerY2");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX2, playerY2);
        }
    }
}
