using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>おばけの移動・GameManagerからInstanciateされたら作動する</summary>
public class ObakeController : MonoBehaviour
{

    void Start()
    {
        //移動・透過度変化するアニメーション起動
    }

    private void OnDestroy()
    {
        //GameManagerのカウント用変数をカウントアップ
    }
}
