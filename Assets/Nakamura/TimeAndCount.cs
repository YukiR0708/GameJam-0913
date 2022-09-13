using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndCount : MonoBehaviour
{
    /// <summary>��������</summary>
    [Header("�������Ԃ̐ݒ�"), SerializeField] public int _timeLimit = 30;
    /// <summary>���ԗp�ϐ�</summary>
    float _time = 0f;
    /// <summary>Plyer1��Count�ϐ�</summary>
    [Header("Player1��Count"), SerializeField] public int _p1Count = 0;
    /// <summary>Player2��Count�ϐ�</summary>
    [Header("Player2��Count"), SerializeField] public int _p2Count = 0;
    /// <summary>�������̊Ǘ��pList</summary>
    [Header("��������List"), SerializeField] public List<GameObject> _ghostList = new List<GameObject>();
    /// <summary>�������̃J�E���g�p�ϐ�</summary>
    [Header("��������Count�ϐ�"), SerializeField] public int _ghostCount;
    /// <summary>�������ԂɒB������true </summary>
    [Header("�������ԂɒB���Ă��邩�ǂ���"), SerializeField] public bool _timeLimitToF = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
    }
}
