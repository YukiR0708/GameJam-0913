using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>�^�C�g���V�[���̃A�j���[�V�������Ǘ�����</summary>
public class TitleAnimation : MonoBehaviour
{
    [SerializeField, Header("�^�C�g���摜")]  Image _title;
    [SerializeField, Header("�N���b�Nto�X�^�[�g�̃e�L�X�g")] GameObject _text;
    [SerializeField, Header("�Q�[���V�[��")] Scene _gameScene;
    bool _go;

    void Start()
    {
        //�e�L�X�g���㉺�Ɉړ�
        _text.transform.DOMoveY(-15f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
        _go = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && _go)
        {
            _go = false;
            _text.transform.DORewind();
            _title.DOColor(new Color(0, 0, 0, 1), 1.5f).OnComplete(() => SceneManager.LoadScene("Game"));
        }

    }
}
