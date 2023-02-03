using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;          //���ꍇ�ɂ����TextMeshPro�ɕύX�̉\��
                                     //private TextMeshPro scoreText;

    [SerializeField]
    private Text highScoreText;          //���ꍇ�ɂ����TextMeshPro�ɕύX�̉\��
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
        //  �e�X�g�p�@�֐��Ăԏ����o������폜
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddScore();
        }

        //�n�C�X�R�A���̏���
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
    /// �m�[�c�����ۂɊ֐����Ăяo���Ă��炤�B
    /// </summary>
    /// <param name="score">�ǉ�����X�R�A �ݒ肳��ĂȂ�������10�ǉ�b</param>
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
