using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToken3 : MonoBehaviour
{
    public static string redToken3Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            redToken3Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Red_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        redToken3Collider = "none";
    }
}
