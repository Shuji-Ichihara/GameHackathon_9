using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class NotesManager : SingletonMonoBehaviour<NotesManager>
{
    [SerializeField]
    private float _notesSpawnInterval = 3.0f;
    private float _dummyNotesSpawnInterval = 0.0f;

    [SerializeField]
    private GameObject _tapZone = null;
    public GameObject TapZone => _tapZone;

    [SerializeField]
    private NotesGenerator _noteGenerator = null;

    private bool IsTap = false;

    // Start is called before the first frame update
    void Start()
    {
        _dummyNotesSpawnInterval = _notesSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateNotes(_noteGenerator);
    }

    private void GenerateNotes(NotesGenerator notesGenerator)
    {
        _dummyNotesSpawnInterval -= Time.deltaTime;
        if(_dummyNotesSpawnInterval == 0.0f)
        { 
            notesGenerator.Generate(notesGenerator.gameObject.transform.position);
            _dummyNotesSpawnInterval = _notesSpawnInterval;
        }
    }


    /// <summary>
    /// ノーツをタップした時の成功、失敗の判定
    /// </summary>
    private void TapNotes()
    {
        // タップ成功の範囲
        var tapSuccess = TapZone.transform.position.x / 2;

        if (Input.GetKeyDown(KeyCode.Space)
            && (transform.position.x == TapZone.transform.position.x - tapSuccess
            || transform.position.x == TapZone.transform.position.x + tapSuccess))
        {
            IsTap = true;
        }
        else if (transform.position.x > 
                 Screen.width + _noteGenerator.NotesObject.transform.position.x / 2)
        {
            _noteGenerator.NotesObject.SetActive(false);
        }
    }

}
