using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance { get; private set; }
    public float GameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;

    private Player player;
    private Spawner spawner;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
    private void Start()
    {
        player = GetComponent<Player>();
        spawner = GetComponent<Spawner>();
        NewGame();
    }
    private void NewGame()
    {
        GameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }
    private void Update()
    {
        GameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
}
