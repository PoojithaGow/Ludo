using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenToken3 : MonoBehaviour
{
    public static string greenToken3Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            greenToken3Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        greenToken3Collider = "none";
    }
}
