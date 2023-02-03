using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        MoveNotes();
        EraseNotes();
    }

    /// <summary>
    /// ノーツの移動処理
    /// </summary>
    private void MoveNotes()
    {
        Vector3 move = Vector3.right * _moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    /// <summary>
    /// 画面外に出たらノーツを消す処理
    /// </summary>
    private void EraseNotes()
    {
        if (transform.position.x > Screen.width / 2 + transform.localScale.x / 2)
        {
            gameObject.SetActive(false);
        }
    }
}
