using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
/// <summary>�^�C�g���V�[���̃A�j���[�V�������Ǘ�����</summary>
public class TitleAnimation : MonoBehaviour
{
    [SerializeField, Header("�^�C�g���摜")] Image _title;
    [SerializeField, Header("�N���b�Nto�X�^�[�g�̃e�L�X�g")] GameObject _text;
    [SerializeField, Header("�������")] GameObject _setumei;
    AudioSource _audio;
    [SerializeField, Header("�N���b�N�����Ƃ��Ƃ��ɂȂ鉹")] AudioClip _click;
    bool _go;
    bool _showSetumei;

    void Start()
    {
        //�e�L�X�g���㉺�Ɉړ�
        //�C���X�y�N�^�[�ŐF���������Ă��炤
        _title.DOColor(new Color(1, 1, 1, 1), 1.5f).SetEase(Ease.Linear).SetAutoKill();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(!_showSetumei)
            {
                _showSetumei = true;
                _setumei.SetActive(true);
                _audio.PlayOneShot(_click);
                _text.transform.DOPause();
            }
            else
            {
                _showSetumei = false;
                _setumei.SetActive(false);
                _audio.PlayOneShot(_click);
                _text.transform.DOPlay();
            }

        }

    }
}
