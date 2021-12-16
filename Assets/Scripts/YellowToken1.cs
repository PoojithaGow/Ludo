﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToken1 : MonoBehaviour
{
    public static string yellowToken1Collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            yellowToken1Collider = collision.gameObject.name;
            if (collision.gameObject.name.Contains("YellowHouse"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        yellowToken1Collider = "none";
    }
}
