using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="StageData",menuName="LastWall/Stage", order=1)]
public class StageData : ScriptableObject
{
    public List<RoundData> rounds;
}
