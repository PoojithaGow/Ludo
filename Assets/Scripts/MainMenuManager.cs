using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    public static int numberOfPlayers;

    public void TwoPlayers()
    {
        SoundManager.buttonAudioSource.Play();
        numberOfPlayers = 2;
        SceneManager.LoadScene("GamePlay");
    }

    public void FourPlayers()
    {
        SoundManager.buttonAudioSource.Play();
        numberOfPlayers = 4;
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit()
    {
        SoundManager.buttonAudioSource.Play();
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
        }
    }
}
