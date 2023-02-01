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
    }

    /// <summary>
    /// ノーツの移動処理
    /// </summary>
    private void MoveNotes()
    {
        Vector3 move = Vector3.right * _moveSpeed * Time.deltaTime ;
        transform.Translate(move);
    }
}
