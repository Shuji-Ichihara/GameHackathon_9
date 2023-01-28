using UnityEngine;

/// <summary>
/// オブジェクトプールに必要な機能
/// </summary>
public class PoolObject : MonoBehaviour
{
    Transform _transform = null;

    public void InitItem(Vector3 pos)
    {
        _transform = GetComponent<Transform>();
        // オブジェクトの生成位置を設定
        _transform.position = pos;
        // アイテムをアクティブにする
        gameObject.SetActive(true);
    }
}
