using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class NotesManager : MonoBehaviour
{
    private GameManager _gameManager = null;

    private CancellationTokenSource _token = new CancellationTokenSource();

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager._list_notesGenerator[(int)NotesPop.NotesPop1].ObjectName == gameObject.name)
        {
            _gameManager.GenerateNotes1(_gameManager._list_notesGenerator[(int)NotesPop.NotesPop1]);
            _gameManager.TapNotes(NotesPop.NotesPop1);
        }
        if (_gameManager._list_notesGenerator[(int)NotesPop.NotesPop2].ObjectName == gameObject.name)
        {
            _gameManager.GenerateNotes2(_gameManager._list_notesGenerator[(int)NotesPop.NotesPop2], _token).Forget();
            _gameManager.TapNotes(NotesPop.NotesPop2);
        }
    }
}
