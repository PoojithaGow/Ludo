using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToken2 : MonoBehaviour
{
    public static string redToken2Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            redToken2Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Red_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        redToken2Collider = "none";
    }
}
