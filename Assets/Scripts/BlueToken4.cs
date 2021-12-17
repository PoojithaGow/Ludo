using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToken4 : MonoBehaviour
{

    public static string blueToken4Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            blueToken4Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Blue_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blueToken4Collider = "none";
    }
}
