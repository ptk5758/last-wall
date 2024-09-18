using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonsterData", menuName ="LastWall/MonsterData")]
public class MonsterData : ScriptableObject
{
    [Header("General Information")]
    public string monsterName; // 이름

    [Header("Attribute")]
    public float health; // HP
    public float speed; // 이동 속도
    public float damage; // 공격력
    public float range; // 공격 범위 콜리전에 적용할듯함
    public float delay; // 공격 간격
}