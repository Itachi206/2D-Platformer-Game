using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button ButtonPlay;
    public GameObject levelSelector;
    private void Awake()
    {
        ButtonPlay.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelSelector.SetActive(true);
    }
}
