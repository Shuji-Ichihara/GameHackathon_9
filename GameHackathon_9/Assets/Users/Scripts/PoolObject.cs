using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�v�[���ɕK�v�ȋ@�\
/// </summary>
public class PoolObject : MonoBehaviour
{
    Transform _transform = null;

    public void InitItem(Vector3 pos)
    {
        _transform = GetComponent<Transform>();
        // �I�u�W�F�N�g�̐����ʒu��ݒ�
        _transform.position = pos;
        // �A�C�e�����A�N�e�B�u�ɂ���
        gameObject.SetActive(true);
    }
}
