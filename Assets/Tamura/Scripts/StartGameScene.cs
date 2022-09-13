using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
/// <summary>�Q�[���V�[�����n�܂������̓���</summary>
public class StartGameScene : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h�p�p�l��")] Image _fadePanel;
    [SerializeField, Header("�^�C���J�E���g�X�N���v�g")] TimeAndCount _timeAndCount;
    bool _start;
    [SerializeField, Header("�J�E���g�_�E������e�L�X�g")] Text _countDownText;
    AudioSource _audio;
    [SerializeField, Header("�J�E���g�_�E������Ƃ��̉�")] AudioClip _count;
    [SerializeField, Header("�X�^�[�g����Ƃ��̉�")] AudioClip _gameStart;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _fadePanel.DOFade(0, 2.0f).OnComplete(() => _start = true).SetAutoKill();
        _countDownText.enabled = false;
    }

    void Update()
    {

        if (_start)
        {
            _countDownText.enabled = true;
            _start = false;
            StartCoroutine(GameStart());
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
