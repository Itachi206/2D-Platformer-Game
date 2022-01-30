using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button ButtonRestart;
    public Button ButtonQuit;

    private void Awake()
    {
        ButtonRestart.onClick.AddListener(ReloadLevel);
        ButtonQuit.onClick.AddListener(GoToLobby);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void GoToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
