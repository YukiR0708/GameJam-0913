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
    /// <summary>お化けのカウント用変数</summary>
    [Header("お化けのCount変数"), SerializeField] public int _ghostCount;
    /// <summary>制限時間に達したらtrue </summary>
    [Header("制限時間に達しているかどうか"), SerializeField] public bool _timeLimitToF = false;
    /// <summary>Player1がclear下かどうかの判定</summary>
    [Header("Player1がclearしたかどうか"), SerializeField] public bool _player1ClearToF = false;
    /// <summary>Player2がclear下かどうかの判定</summary>
    [Header("Player2がclearしたかどうか"), SerializeField] public bool _player2ClearToF = false;
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
