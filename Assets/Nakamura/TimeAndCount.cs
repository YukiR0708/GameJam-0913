using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndCount : MonoBehaviour
{
    /// <summary>制限時間</summary>
    [Header("制限時間の設定"), SerializeField] public int _timeLimit = 30;
    /// <summary>時間用変数</summary>
    float _time = 0f;
    /// <summary>Plyer1のCount変数</summary>
    [Header("Player1のCount"), SerializeField] public int _p1Count = 0;
    /// <summary>Player2のCount変数</summary>
    [Header("Player2のCount"), SerializeField] public int _p2Count = 0;
    /// <summary>お化けの管理用List</summary>
    [Header("お化けのList"), SerializeField] public List<GameObject> _ghostList = new List<GameObject>();
    /// <summary>お化けのカウント用変数(OnDestroy)</summary>
    [Header("お化けのCount変数"), SerializeField] public int _ghostCount;
    /// <summary>制限時間に達したらtrue </summary>
    [Header("制限時間に達しているかどうか"), SerializeField] public bool _timeLimitToF = false;
    /// <summary>Player1がclear下かどうかの判定</summary>
    [Header("Player1がclearしたかどうか"), SerializeField] public bool _player1ClearToF = false;
    /// <summary>Player2がclear下かどうかの判定</summary>
    [Header("Player2がclearしたかどうか"), SerializeField] public bool _player2ClearToF = false;
    /// <summary>現在時刻を表示する</summary>
    [Header("timeを表示する用のTextを設定"),SerializeField] Text _timeText = default;
    /// <summary>TimeLimitを始めるTrigger</summary>
    [Header("スタートまでのカウント"), SerializeField] public bool _timeStartToF = false;
    /// <summary>Result用のText変数</summary>
    [Header("Resultを表示するTextを設定"), SerializeField] Text _ResultText = default;
    // Start is called before the first frame update
    void Start()
    {
        _time = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //開始の合図でカウントダウンが始まる
        if (_timeStartToF)
        {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString("00");
        }
        
        //制限時間がゼロになったらtrueを返す
        if (_time == 0)
        {
            _timeLimitToF = true;
            _time = 0;
            _timeText.text ="";
        }

        //制限時間が0になったときに集計を開始する
        if (_timeLimitToF)
        {
            //Player1の集計
            if (_p1Count == _ghostCount)
            {
                _player1ClearToF = true;
            }

            //Player2の集計
            if (_p2Count == _ghostCount)
            {
                _player2ClearToF = true;
            }

            Result();
        }
    }

    //集計が終わった後に結果を表示する
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
