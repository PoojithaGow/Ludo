using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToken3 : MonoBehaviour
{

    public static string blueToken3Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            blueToken3Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Blue House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blueToken3Collider = "none";
    }
}
