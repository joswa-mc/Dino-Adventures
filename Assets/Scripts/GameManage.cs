using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance { get; private set; }
    public float GameSpeed { get; private set; }
    public float initialGameSpeed = 1f;
    public float gameSpeedIncrease = 0.05f;

    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI hiScoretxt;
    float hiscore;

    private Player player;
    private Spawner spawner;

    private int sceneLoaded = 0;

    private float score;
    
    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
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
        UpdateHiScore();
    }
    private void Update()
    {
        if(sceneLoaded == 1)
        {
            scoretxt = GameObject.Find("scoretxt").GetComponent<TextMeshProUGUI>();
            hiScoretxt = GameObject.Find("hiScoretxt").GetComponent<TextMeshProUGUI>();
            UpdateHiScore();
            GameSpeed += gameSpeedIncrease * Time.deltaTime;
            score += GameSpeed * Time.deltaTime;
            scoretxt.text = Mathf.FloorToInt(score).ToString("D5");
            hiScoretxt.text = Mathf.FloorToInt(hiscore).ToString("D5");
        }

    }
    public void UpdateHiScore()
    {
        hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        if(score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
    }
    public void ChangeScene(int sceneLoaded)
    {
        enabled = true;
        score = 0f;
        initialGameSpeed = 2f;
        GameSpeed = initialGameSpeed;
        this.sceneLoaded = sceneLoaded;

    }
}
