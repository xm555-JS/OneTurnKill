using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public GameObject player;

    Scene curScene;
    Scene preScene;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        curScene = scene;

        if (curScene != preScene)
        {
            if (scene.name == "CustomLevel")
            {
                player.GetComponent<cPlayer>().enabled = false;
                player.GetComponent<cPlayerAttack>().enabled = false;
                player.GetComponent<cPlayerStats>().enabled = false;
            }
            if (scene.name == "SampleScene")
            {
                player.GetComponent<cPlayer>().enabled = true;
                player.GetComponent<cPlayerAttack>().enabled = true;
                player.GetComponent<cPlayerStats>().enabled = true;
            }

            preScene = scene;
        }
    }
}
