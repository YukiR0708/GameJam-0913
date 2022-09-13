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
    [SerializeField, Header("タイトル画像")]  Image _title;
    [SerializeField, Header("クリックtoスタートのテキスト")] GameObject _text;
    [SerializeField, Header("ゲームシーン")] Scene _gameScene;
    AudioSource _audio;
    bool _go;

    void Start()
    {
        //テキストを上下に移動
        _text.transform.DOMoveY(-15f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
        _go = true;
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && _go)
        {
            _go = false;
            _audio.Play();
            _text.transform.DORewind();
            _title.DOColor(new Color(0, 0, 0, 1), 1.5f).OnComplete(() => SceneManager.LoadScene("Game"));
        }

    }
}
