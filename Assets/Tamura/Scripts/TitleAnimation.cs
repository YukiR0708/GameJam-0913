using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
/// <summary>タイトルシーンのアニメーションを管理する</summary>
public class TitleAnimation : MonoBehaviour
{
    [SerializeField, Header("タイトル画像")] Image _title;
    [SerializeField, Header("クリックtoスタートのテキスト")] GameObject _text;
    [SerializeField, Header("操作説明")] GameObject _setumei;
    AudioSource _audio;
    [SerializeField, Header("クリックしたときとかになる音")] AudioClip _click;
    bool _go;
    bool _go1;
    bool _go2;
    bool _showSetumei;

    void Start()
    {
        //テキストを上下に移動
        _text.transform.DOMoveY(-15f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
        _go = true;
        _audio = GetComponent<AudioSource>();
        _setumei.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && _go && !_showSetumei)
        {
            _go = false;
            _audio.PlayOneShot(_click);
            _text.transform.DORewind();
            _title.DOColor(new Color(0, 0, 0, 1), 1.5f).OnComplete(() => SceneManager.LoadScene("Game"));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_showSetumei)
        {
            Debug.Log("kurikku");
            _showSetumei = true;
            _setumei.SetActive(true);
            _audio.PlayOneShot(_click);

            if (!_go1)
            {
                _go1 = true;
                _go2 = false;
                _text.transform.DOPause();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _showSetumei)
        {
            _showSetumei = false;
            _setumei.SetActive(false);
            _audio.PlayOneShot(_click);

            if (!_go2)
            {
                _go2 = true;
                _go1 = false;
                _text.transform.DOPlay();
            }
        }

    }
}
