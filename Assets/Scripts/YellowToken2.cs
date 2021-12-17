using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToken2 : MonoBehaviour
{

    public static string yellowToken2Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            yellowToken2Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Yellow_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        yellowToken2Collider = "none";
    }
}
