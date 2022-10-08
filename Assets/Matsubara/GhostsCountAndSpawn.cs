using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GhostsCountAndSpawn : MonoBehaviour
{
    [Header("出現させたいオブジェクト")] [SerializeField] GameObject _ghost;
    [SerializeField] Transform _rangeA;
    [SerializeField] Transform _rangeB;
    [Header("最大出現数"), SerializeField] int _maxcount = 25;
    [Header("最小出現数"), SerializeField] int _mincount = 17;
    [SerializeField] TimeAndCount _count;
    [SerializeField] Text _countText;
    [SerializeField] AudioClip _ghostFade;
    bool _go = true;
    bool _goResult = true;
    float _interval = 0.0f;
    int _currentFontSize;

    private void Start()
    {
        _currentFontSize = _countText.fontSize;
    }
    private void Update()
    {
        if (_count._timeStartToF && _go)
        {
            _go = false;
            GhostPop();

        }


        if (_count._timeLimitToF == true)
        {

            if (_interval >= 1.2f)
            {

                if (_count._ghostList.Count != 0)
                {
                    _interval = 0.5f;
                    _count._ghostCount++;
                    GetComponent<AudioSource>().PlayOneShot(_ghostFade, 2.0f);
                    GameObject ghost = _count._ghostList[_count._ghostList.Count - 1];

                    if (ghost.GetComponent<SpriteRenderer>().flipX)
                    {
                        ghost.GetComponent<Transform>().DOMoveX(-1.0f, 0.7f).SetEase(Ease.Linear).SetRelative();
                    }
                    else
                    {
                        ghost.GetComponent<Transform>().DOMoveX(1.0f, 0.7f).SetEase(Ease.Linear).SetRelative();

                    }

                    _count._ghostList[_count._ghostList.Count - 1].GetComponent<SpriteRenderer>().DOFade(0, 0.7f).SetEase(Ease.Linear)
                        .OnComplete(() => { Destroy(_count._ghostList[_count._ghostList.Count - 1]); _count._ghostList.RemoveAt(_count._ghostList.Count - 1); }).SetAutoKill();
                    _countText.text = _count._ghostCount.ToString();

                    //↓謎の挙動発生
                    //Destroy(_count._ghostList[0]);
                    //_count._ghostList.RemoveAt(0);

                    Debug.Log(_count._ghostCount);
                }
                else
                {

                    if (_goResult)
                    {
                        _goResult = false;
                        DOTween.To(() => _currentFontSize,
                        x => _countText.fontSize = x,
                        130, 1).OnComplete(() => _count._ghostCountToF = true);
                    }

                }

            }
            else
            {
                _interval += Time.deltaTime;
            }
        }
    }

    void GhostPop()
    {
        int spawnCount = Random.Range(_mincount, _maxcount);
        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(_rangeB.position.x, _rangeA.position.x);
            float y = Random.Range(_rangeB.position.y, _rangeA.position.y);
            GameObject ghost = Instantiate(_ghost, new Vector2(x, y), Quaternion.identity);
            ghost.name = $"ghost{i}";
            _count._ghostList.Add(ghost);
        }
    }
}
