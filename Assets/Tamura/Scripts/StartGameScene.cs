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
    float _countDown = 3;
    [SerializeField, Header("�J�E���g�_�E������e�L�X�g")] Text _countDownText;

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
