using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsCountAndSpawn : MonoBehaviour
{
    [Header("�o�����������I�u�W�F�N�g")] [SerializeField] GameObject _ghost;
    [SerializeField] Transform _rangeA;
    [SerializeField] Transform _rangeB;
    [Header("�ő�o����"), SerializeField] int _maxcount = 30;
    [Header("�ŏ��o����"), SerializeField] int _mincount = 20;
    bool _timeLimit;
    List<GhostsCountAndSpawn> _ghosts;
    [SerializeField] TimeAndCount _count;
    private void Awake()
    {
        //_ghosts = new List<GameObject>();
    }
    void Start()
    {
        //_ghosts = GetComponent<TimeAndCount>()._ghostList;
        //_timeLimit = GetComponent<TimeAndCount>()._timeLimitToF;
        int spawnCount = Random.Range(_mincount, _maxcount);
        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(_rangeB.position.x, _rangeA.position.x);
            float y = Random.Range(_rangeB.position.y, _rangeA.position.y);

            //Instantiate(_ghost, new Vector2(x, y), Quaternion.identity);
            _count._ghostList.Add(Instantiate(_ghost, new Vector2(x, y), Quaternion.identity));
        }
    }
    private void Update()
    {
        if (_timeLimit == true)
        {
            while(_ghosts.Count == 0)
            {
                Destroy(_ghosts[0]);
            }
        }
    }
}
