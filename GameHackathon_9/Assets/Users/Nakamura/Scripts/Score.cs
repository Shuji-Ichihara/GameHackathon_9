using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;          //↓場合によってTextMeshProに変更の可能性
  //private TextMeshPro scoreText;

    private int _score;

    void Start()
    {
        
    }

    void Update()
    {
        //  テスト用　関数呼ぶ処理出来たら削除
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore();
        }
    }





    /// <summary>
    /// ノーツ消す際に関数を呼び出してもらう。
    /// </summary>
    /// <param name="score">追加するスコア 設定されてなかったら10追加b</param>
    void AddScore(int score = 10) 
    {
        _score += score;
        scoreText.text = "SCORE:" + _score.ToString();
    }

}
