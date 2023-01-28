using System;
using UnityEngine;

public class SingletonMonoBehaviour<T>: MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Type t = typeof(T);
                instance = (T)FindObjectOfType(t);
                if(instance = null)
                {
                    Debug.LogError(t + "をアタッチしている GameObject はありません。");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // 他の GameObject にアタッチされているかを調べる。
        // アタッチされている場合は破棄する。
        if (this != Instance)
        {
            Destroy(this);
            Debug.LogError(
                typeof(T)
                + " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました."
                + " アタッチされている GameObject は" + Instance.gameObject.name + "です。");
            return;
        }

        // Manager的なSceneを跨いでこのGameObjectを有効にしたい場合は
        // ↓コメントアウトを外す.
        //DontDestroyOnLoad(this.gameObject);
    }
}
