using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenToken1 : MonoBehaviour
{

    public static string greenToken1Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            greenToken1Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("Safe_Green_House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        greenToken1Collider = "none";
    }
}
