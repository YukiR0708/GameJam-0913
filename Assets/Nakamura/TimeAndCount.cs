using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// <summary>Player1��clear�����ǂ����̔���</summary>
    [Header("Player1��clear�������ǂ���"), SerializeField] public bool _player1ClearToF = false;
    /// <summary>Player2��clear�����ǂ����̔���</summary>
    [Header("Player2��clear�������ǂ���"), SerializeField] public bool _player2ClearToF = false;
    [SerializeField] Text _timeText = default;
    // Start is called before the first frame update
    void Start()
    {
        _time = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = _time.ToString("D2");
        
        if (_time == 0)
        {
            _timeLimitToF = true;
        }
    }

    void PLayerResult ()
    {

    }
}
