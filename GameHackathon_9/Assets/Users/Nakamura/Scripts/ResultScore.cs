using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;          //���ꍇ�ɂ����TextMeshPro�ɕύX�̉\��
                                     //private TextMeshPro scoreText;

    [SerializeField]
    private Text highScoreText;          //���ꍇ�ɂ����TextMeshPro�ɕύX�̉\��
                                         //private TextMeshPro scoreText;

    void Start()
    {

        scoreText.text = "SCORE:" + Score.GetScore();
        highScoreText.text = "HIGHSCORE:" + Score.GetHighScore();

    }

}
