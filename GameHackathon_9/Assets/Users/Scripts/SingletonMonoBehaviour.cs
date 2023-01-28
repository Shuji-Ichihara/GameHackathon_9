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
                    Debug.LogError(t + "���A�^�b�`���Ă��� GameObject �͂���܂���B");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // ���� GameObject �ɃA�^�b�`����Ă��邩�𒲂ׂ�B
        // �A�^�b�`����Ă���ꍇ�͔j������B
        if (this != Instance)
        {
            Destroy(this);
            Debug.LogError(
                typeof(T)
                + " �͊��ɑ���GameObject�ɃA�^�b�`����Ă��邽�߁A�R���|�[�l���g��j�����܂���."
                + " �A�^�b�`����Ă��� GameObject ��" + Instance.gameObject.name + "�ł��B");
            return;
        }

        // Manager�I��Scene���ׂ��ł���GameObject��L���ɂ������ꍇ��
        // ���R�����g�A�E�g���O��.
        //DontDestroyOnLoad(this.gameObject);
    }
}
