using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToken2 : MonoBehaviour
{
    public static string blueToken2Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            blueToken2Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Blue_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blueToken2Collider = "none";
    }
}
