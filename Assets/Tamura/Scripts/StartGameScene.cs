using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    [SerializeField, Header("�N���b�N����Ƃ��̉�")] AudioClip _click;
    float _second = 1;
    int _countDown = 3;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _fadePanel.DOFade(0, 2.0f).OnComplete(() => { _start = true; _audio.PlayOneShot(_count, 1.5f); }).SetAutoKill();
        _countDownText.enabled = false;
    }

    void Update()
    {
        
        if (_start)
        {
            _countDownText.enabled = true;
            _second -= Time.deltaTime;

            if (_second < 0)
            {
                _countDown--;

                if(_countDown > 0)
                {
                    _audio.PlayOneShot(_count, 2.0f);
                    _countDownText.text = $"{_countDown}";
                    _second = 1;
                }
                else
                {
                    _start = false;
                    StartCoroutine(GameStart());
                }
                
            }

        }

        if(_timeAndCount._timeLimitToF && _timeAndCount._ghostCountToF)
        {

            if (Input.GetKeyDown(KeyCode.T))
            {
                _audio.PlayOneShot(_click);
                _fadePanel.DOFade(1, 1.0f).OnComplete(() => SceneManager.LoadScene("Title"))
                    .SetEase(Ease.Linear).SetAutoKill();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                _audio.PlayOneShot(_click);
                _fadePanel.DOFade(1, 1.0f).OnComplete(() => SceneManager.LoadScene("Game"))
                    .SetEase(Ease.Linear).SetAutoKill();
            }

        }

    }

    IEnumerator GameStart()
    {
        _countDownText.text = $"START!";
        _audio.PlayOneShot(_gameStart, 2.0f);
        yield return new WaitForSeconds(1.0f);
        _countDownText.enabled = false;
        _timeAndCount._timeStartToF = true;
    }

}
