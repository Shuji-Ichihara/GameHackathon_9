using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ノーツオブジェクトのプール
/// </summary>
public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _notesObject = null;

    private List<PoolObject> _list_notes = new List<PoolObject>();
    [SerializeField]
    private const int _maxNotes = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxNotes; i++)
        {
            PoolObject poolObject;

            poolObject = Instantiate(_notesObject).GetComponent<PoolObject>();
            poolObject.transform.parent = this.transform;
            poolObject.gameObject.SetActive(false);
            _list_notes.Add(poolObject);
        }
    }

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
