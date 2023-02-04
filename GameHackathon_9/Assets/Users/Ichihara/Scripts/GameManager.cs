using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// ノーツの挙動を管理
/// </summary>
[RequireComponent(typeof(Score))]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private float _notesSpawnInterval = 3.0f;
    private float _dummyNotesSpawnInterval = 0.0f;

    [SerializeField]
    private GameObject _tapZone = null;

    public List<NotesGenerator> _list_notesGenerator = new List<NotesGenerator>();
    private Score _score = null;

    // Start is called before the first frame update
    void Start()
    {
        _dummyNotesSpawnInterval = _notesSpawnInterval;
        _score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    /// <summary>
    /// ノーツの生成
    /// </summary>
    /// <param name="notesGenerator">NotesGenerator のインスタンス</param>
    public void GenerateNotes1(NotesGenerator notesGenerator)
    {
        _dummyNotesSpawnInterval -= Time.deltaTime;
        if (_dummyNotesSpawnInterval < 0.0f)
        {
            notesGenerator.Generate(notesGenerator.transform.position, new CancellationTokenSource()).Forget();
            _dummyNotesSpawnInterval = _notesSpawnInterval;
        }
    }

    public async UniTask GenerateNotes2(NotesGenerator notesGenerator, CancellationTokenSource token)
    {
        _dummyNotesSpawnInterval -= Time.deltaTime;
        if (_dummyNotesSpawnInterval < 0.0f)
        {
            int popNotes = 4;
            int count = 0;
            while (count < popNotes)
            {
                notesGenerator.Generate(notesGenerator.transform.position, new CancellationTokenSource()).Forget();
                count++;
                await UniTask.Yield();
            }
        }
        _dummyNotesSpawnInterval = _notesSpawnInterval;
        token.Cancel();
    }


    /// <summary>
    /// ノーツをタップした時の成功、失敗の判定
    /// </summary>
    public void TapNotes(NotesPop notesPop)
    {
        // タップ成功の範囲
        var tapSuccess = _tapZone.transform.localScale.x / 2;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _list_notesGenerator[(int)notesPop]._list_notes.Count; i++)
            {
                if (_list_notesGenerator[(int)notesPop]._list_notes[i].transform.position.x >= _tapZone.transform.position.x - tapSuccess
                && _list_notesGenerator[(int)notesPop]._list_notes[i].transform.position.x <= _tapZone.transform.position.x + tapSuccess)
                {
                    _list_notesGenerator[(int)notesPop]._list_notes[i].gameObject.SetActive(false);
                    _score.AddScore();
                    break;
                }
            }
        }
    }
}