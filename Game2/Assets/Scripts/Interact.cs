using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Define the key to interact

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Clue"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}


