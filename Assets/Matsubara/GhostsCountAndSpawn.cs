using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsCountAndSpawn : MonoBehaviour
{
    [Header("出現させたいオブジェクト")] [SerializeField] GameObject _ghost;
    [SerializeField] Transform _rangeA;
    [SerializeField] Transform _rangeB;
    [Header("最大出現数"), SerializeField] int _maxcount = 30;
    [Header("最小出現数"), SerializeField] int _mincount = 20;
    [SerializeField] TimeAndCount _count;
    bool _go = true;
    
    
    private void Update()
    {
        if (_count._timeStartToF && _go)
        {
            _go = false;
            GhostPop();
            
        }


        if (_count._timeLimitToF == true && _count._ghostList.Count != 0)
        {
            Destroy(_count._ghostList[0]);
            _count._ghostList.RemoveAt(0);
            _count._ghostCount++;
            Debug.Log(_count._ghostCount);
        }
        else if (_count._timeLimitToF == true && _count._ghostList.Count == 0)
        {
            _count._ghostCountToF = true;
        }
    }

    void GhostPop()
    {
        int spawnCount = Random.Range(_mincount, _maxcount);
        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(_rangeB.position.x, _rangeA.position.x);
            float y = Random.Range(_rangeB.position.y, _rangeA.position.y);
            _count._ghostList.Add(Instantiate(_ghost, new Vector2(x, y), Quaternion.identity));
        }
    }
}
