using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用UI

public class BGupdate : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip enemyBoomSE;
    public AudioClip playerBoomSE;
    public AudioClip hitSE;

    public GameObject enemy; //宣告物件，名稱Enemy
    public float time; //宣告浮點數，名稱time
    public LifeCounter lifeCounter;
    public playerControl player;


    public Text ScoreText; //宣告叫ScoreText的Text物件
    public int Score = 0; // 宣告一整數 Score
    public static BGupdate Instance; // 設定Instance，讓其他程式能讀取BGupdate裡的東西


    public GameObject GameTitleText; //宣告GameTitle物件
    public GameObject GameOverText; //宣告GameOverTitle物件
    public GameObject PlayButton; //宣告PlayButton物件
    public bool IsPlaying = false; // 宣告 IsPlaying 的布林物件，並設定初始值false

    public GameObject RestartButton; //宣告RestartButton的物件
    public GameObject ExitButton; //宣告ExitButton的物件


    // Start is called before the first frame update
    void Start()
    {
       // Screen.SetResolution(800,800,false);
        Application.targetFrameRate = 60; //fps 60

        Instance = this; //指定這個script
        
        GameTitleText.SetActive(true); //設定GameTitle顯示
        GameOverText.SetActive(false); //設定GameOverTitle不顯示
        RestartButton.SetActive(false); //RestartButton設定成不顯示
    }
    // 開始遊戲
    public void GameStart()
    {
        IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中
        player.life = 3;
        lifeCounter.LifeRefresh(player.life);
        GameTitleText.SetActive(false); // 不顯示GameTitle
        PlayButton.SetActive(false); // 不顯示PlayButton
        ExitButton.SetActive(false); //不顯示ExitButton

    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //時間增加
        if (time > Random.Range(0.3f, 0.5f) && IsPlaying) //如果時間大於0.5(秒)而且開始遊玩中
        {
            Vector3 pos = new Vector3(Random.Range(-5f, 1.672f), 4.5f, 0); //宣告位置pos，Random.Range(-5f, 1.672f)代表X是1.672到-5之間隨機
            Instantiate(enemy, pos, transform.rotation);//產生敵人
            time = 0f; //時間歸零
        }
    }

    // 增減分數
    public void AddScore(int score)
    {
        Score += score; //分數增加
        ScoreText.text = Score.ToString(); // 更改ScoreText的內容
    }


    public void PlayHitSE() {
        audioSource.PlayOneShot(hitSE, 0.5f);
    }
    public void PlayEnemyBoomSE() {
        audioSource.PlayOneShot(enemyBoomSE, 0.8f);
    }
    public void PlayPlayerBoomSE() {
        audioSource.PlayOneShot(playerBoomSE, 1f);
    }


    // 扣命
    public void LifeMinus() 
    {
        player.LifeMinus();
        lifeCounter.LifeRefresh(player.life);

        if (player.life <= 0) {
            GameOver();
        }
        
    }

    //GameOver的Function
    public void GameOver() 

    {
        IsPlaying = false; //IsPlaying 設定成false，停止產生敵人
        GameOverText.SetActive(true); //設定為ture，顯示 GameOverText
        RestartButton.SetActive(true); //RestartButton設定成顯示
        ExitButton.SetActive(true); //ExitButton設定成顯示
    }
    //RestartButton的功能
    public void ResetGame() 
    {
        Application.LoadLevel(Application.loadedLevel); //讀取關卡(已讀取的關卡)
    }
    //ExitButton的功能
    public void ExitGame() 
    {
        Application.Quit(); //離開應用程式
    }



}
