using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;          //���ꍇ�ɂ����TextMeshPro�ɕύX�̉\��
  //private TextMeshPro scoreText;

    private int _score;

    void Start()
    {
        
    }

    void Update()
    {
        //  �e�X�g�p�@�֐��Ăԏ����o������폜
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore();
        }
    }





    /// <summary>
    /// �m�[�c�����ۂɊ֐����Ăяo���Ă��炤�B
    /// </summary>
    /// <param name="score">�ǉ�����X�R�A �ݒ肳��ĂȂ�������10�ǉ�b</param>
    void AddScore(int score = 10) 
    {
        _score += score;
        scoreText.text = "SCORE:" + _score.ToString();
    }

}
