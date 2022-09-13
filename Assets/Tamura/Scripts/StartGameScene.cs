using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>�Q�[���V�[�����n�܂������̓���</summary>
public class StartGameScene : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h�p�p�l��")] Image _fadePanel;
    [SerializeField, Header("�^�C���J�E���g�X�N���v�g")] TimeAndCount _timeAndCount;
    bool _start;
    [SerializeField, Header("�J�E���g�_�E������e�L�X�g")] Text _countDownText;

    void Start()
    {
        _fadePanel.DOFade(0, 1.0f).OnComplete(() => _start = true).SetAutoKill();
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
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = "2";
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = "1";
        yield return new WaitForSeconds(1.0f);
        _countDownText.text = $"START!";
        yield return new WaitForSeconds(1.0f);
        _countDownText.enabled = false;
        _timeAndCount._timeStartToF = true;
    }
}
