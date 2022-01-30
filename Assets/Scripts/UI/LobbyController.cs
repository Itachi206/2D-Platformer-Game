using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button ButtonPlay;
    public Button ButtonQuit;
    private void Awake()
    {
        ButtonPlay.onClick.AddListener(PlayGame);
        ButtonQuit.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
