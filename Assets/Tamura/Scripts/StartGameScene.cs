using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>ゲームシーンが始まった時の動き</summary>
public class StartGameScene : MonoBehaviour
{
    [SerializeField, Header("フェード用パネル")] Image _fadePanel;
    [SerializeField, Header("タイムカウントスクリプト")] TimeAndCount _timeAndCount;
    bool _start;
    float _countDown = 3;
    [SerializeField, Header("カウントダウンするテキスト")] Text _countDownText;

    void Start()
    {
        _fadePanel.DOFade(0, 1.0f).OnComplete(() => _start = true).SetAutoKill();
        _countDownText.text = $"{_countDown}";
    }

    void Update()
    {
        
        if(_start)
        {
            _countDown -= Time.deltaTime;
        }

    }
}
