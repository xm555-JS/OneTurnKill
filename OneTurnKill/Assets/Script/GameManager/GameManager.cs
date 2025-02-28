using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;

    cCoinArea coinArea;

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

                coinArea = GameObject.Find("Coin_PickUp").GetComponent<cCoinArea>();
                if (player != null && coinArea != null)
                    player.GetComponent<cPlayer>().SubscribeCoinDrop(coinArea);
            }

            preScene = scene;
        }
    }
}
