using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    public GameObject prefab;
    public float delay;

    public Wave(GameObject prefab)
    {
        this.prefab = prefab;
        this.delay = 0f;
    }

    public Wave(GameObject prefab, float delay) : this(prefab)
    {
        this.delay = delay;
    }
}

[CreateAssetMenu(fileName="RoundData", menuName= "LastWall/Round", order=1)]
public class RoundData : ScriptableObject
{
    public List<Wave> waves;
}
