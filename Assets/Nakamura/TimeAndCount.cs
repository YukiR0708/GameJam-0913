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
    /// <summary>�������̃J�E���g�p�ϐ�(OnDestroy)</summary>
    [Header("��������Count�ϐ�"), SerializeField] public int _ghostCount;
    /// <summary>�������ԂɒB������true </summary>
    [Header("�������ԂɒB���Ă��邩�ǂ���"), SerializeField] public bool _timeLimitToF = false;
    /// <summary>Player1��clear�����ǂ����̔���</summary>
    [Header("Player1��clear�������ǂ���"), SerializeField] public bool _player1ClearToF = false;
    /// <summary>Player2��clear�����ǂ����̔���</summary>
    [Header("Player2��clear�������ǂ���"), SerializeField] public bool _player2ClearToF = false;
    /// <summary>���ݎ�����\������</summary>
    [Header("time��\������p��Text��ݒ�"),SerializeField] Text _timeText = default;
    /// <summary>TimeLimit���n�߂�Trigger</summary>
    [Header("�X�^�[�g�܂ł̃J�E���g"), SerializeField] public bool _timeStartToF = false;
    /// <summary>Result�p��Text�ϐ�</summary>
    [Header("Result��\������Text��ݒ�"), SerializeField] Text _ResultText = default;
    // Start is called before the first frame update
    void Start()
    {
        _time = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeStartToF)
        {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString("00");
        }
        
        if (_time == 0)
        {
            _timeLimitToF = true;
        }
    }

    public void Result()
    {
        if (_player1ClearToF && _player2ClearToF)
        {
            _ResultText.text = ("Your are Win!!");
        }
        else if (_player1ClearToF)
        {
            _ResultText.text = ("Player1 Win!!");
        }
        else if (_player2ClearToF)
        {
            _ResultText.text = ("Player2 Win!!");
        }
        else
        {
            _ResultText.text = ("Draw");
        }
    }
}
