using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void GoToGamePlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
