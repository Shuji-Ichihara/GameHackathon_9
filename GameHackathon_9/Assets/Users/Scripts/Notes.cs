using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5.0f;

    private bool IsTap = false;
    private NotesManager _notesManager = null;

    // Start is called before the first frame update
    void Start()
    {
        _notesManager = NotesManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        MoveNotes();
    }

    /// <summary>
    /// Notes の移動処理
    /// </summary>
    private void MoveNotes()
    {
        Vector3 move = Vector3.right * _moveSpeed * Time.deltaTime ;
        transform.Translate(move);
    }

    public void TapNotes()
    {
        // タップ成功の範囲
        var tapSuccess = _notesManager.TapZone.transform.position.x / 2; 

        if(Input.GetKeyDown(KeyCode.Space) 
            && (transform.position.x == _notesManager.TapZone.transform.position.x - tapSuccess
            || transform.position.x == _notesManager.TapZone.transform.position.x + tapSuccess))
        {
            IsTap = true;
        }
    }
}
