using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Serializable]
    public struct eData
    {
        public GameObject enemy;
        public int[] hp;
        public int[] chamberAppear;
    }

    public List<eData> datas;
}
