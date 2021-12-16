using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenToken2 : MonoBehaviour
{
    public static string greenToken2Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            greenToken2Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        greenToken2Collider = "none";
    }
}
