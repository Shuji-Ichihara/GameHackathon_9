using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// ノーツオブジェクトのプール
/// </summary>
public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _notesObject = null;
    public GameObject NotesObject { get; set; }
    [SerializeField]
    private const int _maxNotes = 10;

    private List<PoolObject> _list_notes = new List<PoolObject>();

    // Start is called before the first frame update
    void Start()
    {
        NotesObject = _notesObject;
        for (int i = 0; i < _maxNotes; i++)
        {
            PoolObject poolObject;
            poolObject = Instantiate(NotesObject).GetComponent<PoolObject>();
            poolObject.transform.parent = transform;
            poolObject.gameObject.SetActive(false);
            _list_notes.Add(poolObject);
        }
    }

    /// <summary>
    /// _list_notes 内のオブジェクトがアクティブ化をチェック
    /// </summary>
    /// <param name="pos"></param>
    public void Generate(Vector3 pos)
    {
        for (int i = 0; i < _list_notes.Count; i++)
        {
            if (false == _list_notes[i].gameObject.activeSelf)
            {
                _list_notes[i].InitItem(pos);
                break;
            }
        }
    }
}
