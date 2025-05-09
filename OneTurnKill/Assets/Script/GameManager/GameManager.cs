using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public cPlayer playerCom;
    public cPlayerStats playerStats;
    public cPlayerAttack playerAttack;

    cCoinArea coinArea;

    Scene curScene;
    Scene preScene;

    void Awake()
    {
        instance = this;

        playerCom = player.GetComponent<cPlayer>();
        playerStats = player.GetComponent<cPlayerStats>();
        playerAttack = player.GetComponent<cPlayerAttack>();
    }

    void Start()
    {
        if (LevelManager.instance.ReturnCurLevel() == "0CustomLevel")
        {
            CustomData data = CustomDataManager.instance.LoadCustomData();
            if (data != null)
                LevelManager.instance.GoToGamePlay();
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        curScene = scene;

        if (curScene != preScene)
        {
            if (scene.name == "0CustomLevel")
            {
                playerCom.enabled = false;
                playerAttack.enabled = false;
                playerStats.enabled = false;
            }
            else if (scene.name == "1SampleScene")
            {
                playerCom.enabled = true;
                playerAttack.enabled = true;
                playerStats.enabled = true;

                coinArea = GameObject.Find("Coin_PickUp").GetComponent<cCoinArea>();
                if (player != null && coinArea != null)
                    player.GetComponent<cPlayer>().SubscribeCoinDrop(coinArea);

                GameManager.instance.player.transform.position = Vector3.zero;
            }
            else if (scene.name == "2OrcBossLevel")
            {
                player.transform.position = new Vector3(-2f, player.transform.position.y, player.transform.position.z);
            }

            preScene = scene;
        }
    }
}
