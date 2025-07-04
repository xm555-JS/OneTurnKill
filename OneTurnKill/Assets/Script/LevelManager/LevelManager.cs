using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GoToCustomLevel()
    {
        PlayerPrefs.SetInt("StoryEnd", 1);
        SceneManager.LoadScene("0CustomLevel");
    }

    public void GoToGamePlay()
    {
        SceneManager.LoadScene("1SampleScene");
    }

    public void GoToOrcBossLevel()
    {
        SceneManager.LoadScene("2OrcBossLevel");
    }

    public string ReturnCurLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        return curScene.name;
    }
}
