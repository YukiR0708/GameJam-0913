using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCheck : MonoBehaviour
{
    /// <summary> Playerのカウント入力を受け取るクラス </summary>
    [SerializeField,Header("Player1のカウント数")] Text _p1CountText;
    [SerializeField,Header("Player2のカウント数")] Text _p2CountText;
    TimeAndCount _timeAndCount;
    AudioSource _audioSource;
    [SerializeField, Header("カウント時のSE")] AudioClip _countSE;



    // Start is called before the first frame update
    void Start()
    {
        _timeAndCount = GetComponent<TimeAndCount>();
        _audioSource = GetComponent<AudioSource>();

        _p1CountText.text = _timeAndCount._p1Count.ToString();
        _p2CountText.text = _timeAndCount._p2Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timeAndCount._timeLimitToF && _timeAndCount._timeStartToF)
        {
            //Player1の操作 → Wでプラス、Sでマイナス
            //Player2の操作 → Oでプラス、Lでマイナス　
            if (Input.GetKeyDown(KeyCode.W))
            {
                _timeAndCount._p1Count++;
                _audioSource.PlayOneShot(_countSE);
            }
            else if (Input.GetKeyDown(KeyCode.S) && _timeAndCount._p1Count > 0)
            {
                _timeAndCount._p1Count--;
                _audioSource.PlayOneShot(_countSE);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                _timeAndCount._p2Count++;
                _audioSource.PlayOneShot(_countSE);
            }
            else if (Input.GetKeyDown(KeyCode.L) && _timeAndCount._p2Count > 0)
            {
                _timeAndCount._p2Count--;
                _audioSource.PlayOneShot(_countSE);
            }

            _p1CountText.text = _timeAndCount._p1Count.ToString();
            _p2CountText.text = _timeAndCount._p2Count.ToString();
        }
    }
}
