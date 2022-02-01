using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get{ return instance; } }             //
    public string[] Levels;
   // Levels [0] = "Level1";


    private void Awake()
    {
        if(instance == null)
        {   
            instance = this;                                         // setting levelmanager to the current instance
            DontDestroyOnLoad(gameObject);                          //  we dont want to destroy our levelmanager
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        /*Scene scene = SceneManager.GetActiveScene();                                            //getting current scene         
        Instance.SetLevelStatus(scene.name, LevelStatus.Completed);                             //marking current scene as completed

        int nextSceneIndex = scene.buildIndex + 1;                                              //getting next scene by current scene build index
                                
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);                    //getting scene at the index 
        Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);                          //setting next scene as unlocked
        */

        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);                    //playerprefs used for player preferences
        Debug.Log("Setting level : " + level + " status: " + levelStatus);
    }
}