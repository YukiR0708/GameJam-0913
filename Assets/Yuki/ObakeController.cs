using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���΂��̋����BGameManager����Instanciate���ꂽ��쓮����</summary>
public class ObakeController : MonoBehaviour
{
    TimeAndCount _timeAndCount;

    private void Start()
    {
        _timeAndCount = GetComponent<TimeAndCount>();
    }

    private void OnDestroy()
    {
        //GameManager�̃J�E���g�p�ϐ����J�E���g�A�b�v
        _timeAndCount._ghostCount++;
    }
}
