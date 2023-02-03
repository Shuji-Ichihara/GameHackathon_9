﻿using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// ノーツオブジェクトのプール
/// </summary>
public class NotesGenerator : MonoBehaviour
{
    public string ObjectName { get; private set; } = "";

    [SerializeField]
    private GameObject _notesObject = null;
    [SerializeField]
    private const int _maxNotes = 10;

    [System.NonSerialized]
    public List<PoolObject> _list_notes = new List<PoolObject>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectName = gameObject.name;
        for (int i = 0; i < _maxNotes; i++)
        {
            PoolObject poolObject;
            poolObject = Instantiate(_notesObject).GetComponent<PoolObject>();
            poolObject.transform.parent = transform;
            poolObject.gameObject.SetActive(false);
            _list_notes.Add(poolObject);
        }
    }

    /// <summary>
    /// _list_notes 内のオブジェクトがアクティブ化をチェック
    /// </summary>
    /// <param name="pos"></param>
    public async UniTask Generate(Vector3 pos, CancellationTokenSource token)
    {
        for (int i = 0; i < _list_notes.Count; i++)
        {
            if (false == _list_notes[i].gameObject.activeSelf)
            {
                _list_notes[i].InitItem(pos);
                break;
            }
            await UniTask.Yield();
        }
        token.Cancel();
    }
}
