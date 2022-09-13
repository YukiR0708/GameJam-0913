using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 勝敗判定 </summary>

public class ResultJudgement : MonoBehaviour
{
    StartGameScene _timeAndCount;

    // Start is called before the first frame update
    void Start()
    {
        _timeAndCount = GetComponent<StartGameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        //2人とも正解なら両方Win！
        
        //どちらかが正解ならそっちがWin！

        //どちらも不正解ならDraw
    }
}
