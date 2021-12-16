using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenToken4 : MonoBehaviour
{
    public static string greenToken4Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            greenToken4Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        greenToken4Collider = "none";
    }
}
