using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
/// <summary>ゲームシーンが始まった時の動き</summary>
public class StartGameScene : MonoBehaviour
{
    [SerializeField, Header("フェード用パネル")] Image _fadePanel;
    [SerializeField, Header("タイムカウントスクリプト")] TimeAndCount _timeAndCount;
    bool _start;
    [SerializeField, Header("カウントダウンするテキスト")] Text _countDownText;
    AudioSource _audio;
    [SerializeField, Header("カウントダウンするときの音")] AudioClip _count;
    [SerializeField, Header("スタートするときの音")] AudioClip _gameStart;
    [SerializeField, Header("クリックするときの音")] AudioClip _click;
    bool _go;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _fadePanel.DOFade(0, 2.0f).OnComplete(() => _start = true).SetAutoKill();
        _countDownText.enabled = false;
        _go = true;
    }

    void Update()
    {

        if (_start)
        {
            _countDownText.enabled = true;
            _start = false;
            StartCoroutine(GameStart());
        }

        if(_timeAndCount._timeLimitToF && _timeAndCount._ghostCountToF && Input.GetKeyDown(KeyCode.Mouse0) && _go)
        {
            _go = false;
            _audio.PlayOneShot(_click);
            _fadePanel.DOFade(255, 1.5f).OnComplete(() => SceneManager.LoadScene("Title")).SetAutoKill();
        }

    }

    IEnumerator GameStart()
    {
        _countDownText.text = "3";
        _audio.PlayOneShot(_count);
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = "2";
        _audio.PlayOneShot(_count);
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = "1";
        _audio.PlayOneShot(_count);
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = $"START!";
        _audio.PlayOneShot(_gameStart);
        yield return new WaitForSeconds(1.0f);
        _countDownText.enabled = false;
        _timeAndCount._timeStartToF = true;
    }
}
