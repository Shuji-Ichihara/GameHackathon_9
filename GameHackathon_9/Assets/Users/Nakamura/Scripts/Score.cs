using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;          //↓場合によってTextMeshProに変更の可能性
                                     //private TextMeshPro scoreText;

    [SerializeField]
    private Text highScoreText;          //↓場合によってTextMeshProに変更の可能性
                                     //private TextMeshPro scoreText;

    private static int _score;
    private static int _highScore=0 ;

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "SCORE:" + _score.ToString();
        highScoreText.text = "HIGHSCORE:" + _highScore.ToString();
    }

    void Update()
    {
        //  テスト用　関数呼ぶ処理出来たら削除
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddScore();
        }

        //ハイスコア時の処理
        if (_highScore<_score)
        {
            _highScore= _score;
            highScoreText.text = "HIGHSCORE:" + _highScore.ToString();
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("ResultScoreScene");
        }

    }





    /// <summary>
    /// ノーツ消す際に関数を呼び出してもらう。
    /// </summary>
    /// <param name="score">追加するスコア 設定されてなかったら10追加b</param>
    public void AddScore(int score = 10) 
    {
        _score += score;
        scoreText.text = "SCORE:" + _score.ToString();
    }


    public static int GetScore()
    {
        return _score;
    }

    public static int GetHighScore()
    {
        return _highScore;
    }

}
