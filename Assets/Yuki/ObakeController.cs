using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>おばけの挙動。GameManagerからInstanciateされたら作動する</summary>
public class ObakeController : MonoBehaviour
{
    TimeAndCount _timeAndCount;

    private void Start()
    {
        _timeAndCount = GetComponent<TimeAndCount>();
    }

    private void Update()
    {
        if (_timeAndCount._timeLimitToF)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        //GameManagerのカウント用変数をカウントアップ
        _timeAndCount._ghostCount++;
        Debug.Log(_timeAndCount._ghostCount);
    }
}
