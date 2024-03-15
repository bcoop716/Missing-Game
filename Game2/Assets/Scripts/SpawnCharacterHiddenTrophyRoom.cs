using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterHiddenTrophyRoom : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Load player's position from PlayerPrefs if needed
        if (PlayerPrefs.HasKey("PlayerXHidden") && PlayerPrefs.HasKey("PlayerYHidden"))
        {
            // Load player's position from PlayerPrefs
            float playerXHidden = PlayerPrefs.GetFloat("PlayerXHidden");
            float playerYHidden = PlayerPrefs.GetFloat("PlayerYHidden");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerXHidden, playerYHidden);
        }
    }
}
