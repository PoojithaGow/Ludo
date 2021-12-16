using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToken4 : MonoBehaviour
{
    public static string redToken4Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            redToken4Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Red House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        redToken4Collider = "none";
    }
}
