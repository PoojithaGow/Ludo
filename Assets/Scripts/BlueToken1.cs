using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToken1 : MonoBehaviour
{
    public static string blueToken1Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            blueToken1Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Blue_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blueToken1Collider = "none";
    }
}
