using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>���΂��̋����BGameManager����Instanciate���ꂽ��쓮����</summary>
public class ObakeController : MonoBehaviour
{
    [Tooltip("�Q�[�������ǂ����������Ă���")] TimeAndCount _timeAndCount;
    bool _setAction = true;
    [Tooltip("���̓z��ۑ����Ă������")] float _saveUntilMove;
    [SerializeField, Header("�����܂ł̊Ԋu")] float _untilMove;
    [Tooltip("RangeA")] GameObject _rangeA;
    [Tooltip("RangeB")] GameObject _rangeB;
    float _upLimit;
    float _downLimit;
    float _rightLimit;
    float _leftLimit;

    private void Start()
    {
        _timeAndCount = GameObject.Find("GameManager").GetComponent<TimeAndCount>();
        _rangeA = GameObject.Find("RangeA");
        _rangeB = GameObject.Find("RangeB");

        _untilMove = Random.Range(3, 6);
        _saveUntilMove = _untilMove;

        _upLimit = _rangeA.transform.position.y;
        _downLimit = _rangeB.transform.position.y;
        _rightLimit = _rangeB.transform.position.x;
        _leftLimit = _rangeA.transform.position.x;
    }

    private void Update()
    {

        if (_timeAndCount._timeStartToF && !_timeAndCount._timeLimitToF)
        {
            _untilMove -= Time.deltaTime;

            if (_untilMove < 0 && _setAction)
            {
                _setAction = false;
                int actionNumber = Random.Range(1, 6);
                float moveTime = Random.Range(1.0f, 1.5f);
                float moveDistance = Random.Range(1, 3);

                switch (actionNumber)
                {
                    //�E�ɓ���
                    case 1:
                        if (_rightLimit > gameObject.transform.position.x + moveDistance)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = false;
                            gameObject.transform.DOMoveX(moveDistance, moveTime).SetEase(Ease.Linear).SetRelative().SetAutoKill()
                                .OnComplete(() => { _untilMove = _saveUntilMove; _setAction = true; });
                        }
                        else
                        {
                            _untilMove = _saveUntilMove;
                            _setAction = true;
                        }
                        break;

                    //���ɓ���
                    case 2:
                        if (_leftLimit < gameObject.transform.position.x - moveDistance)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = true;
                            gameObject.transform.DOMoveX(-moveDistance, moveTime).SetEase(Ease.Linear).SetRelative().SetAutoKill()
                                .OnComplete(() => { _untilMove = _saveUntilMove; _setAction = true; });

                        }
                        else
                        {
                            _untilMove = _saveUntilMove;
                            _setAction = true;
                        }
                        break;

                    //��ɓ���
                    case 3:
                        if (_upLimit > gameObject.transform.position.y + moveDistance)
                        {
                            gameObject.transform.DOMoveY(moveDistance, moveTime).SetEase(Ease.Linear).SetRelative().SetAutoKill()
                                .OnComplete(() => { _untilMove = _saveUntilMove; _setAction = true; });

                        }
                        else
                        {
                            _untilMove = _saveUntilMove;
                            _setAction = true;
                        }
                        break;

                    //���ɓ���
                    case 4:
                        if (_downLimit < gameObject.transform.position.y - moveDistance)
                        {
                            gameObject.transform.DOMoveY(-moveDistance, moveTime).SetEase(Ease.Linear).SetRelative().SetAutoKill()
                                .OnComplete(() => { _untilMove = _saveUntilMove; _setAction = true; });

                        }
                        else
                        {
                            _untilMove = _saveUntilMove;
                            _setAction = true;
                        }
                        break;

                    //�����ɂȂ�
                    case 5:
                        gameObject.GetComponent<SpriteRenderer>().DOFade(0.3f, moveTime)
                            .SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill()
                            .OnComplete(() => { _untilMove = _saveUntilMove; _setAction = true; });
                        break;

                    default: break;
                }

            }

        }

    }

}
