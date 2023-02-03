using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;          //↓場合によってTextMeshProに変更の可能性
                                     //private TextMeshPro scoreText;

    [SerializeField]
    private Text highScoreText;          //↓場合によってTextMeshProに変更の可能性
                                         //private TextMeshPro scoreText;

    void Start()
    {

        scoreText.text = "SCORE:" + Score.GetScore();
        highScoreText.text = "HIGHSCORE:" + Score.GetHighScore();

    }

}
