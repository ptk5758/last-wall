using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    public Monster prefab;
    public float delay;

    public Wave(Monster prefab)
    {
        this.prefab = prefab;
        this.delay = 0f;
    }

    public Wave(Monster prefab, float delay) : this(prefab)
    {
        this.delay = delay;
    }
}

[CreateAssetMenu(fileName="RoundData", menuName= "LastWall/Round", order=1)]
public class RoundData : ScriptableObject
{
    public List<Wave> waves;
}
