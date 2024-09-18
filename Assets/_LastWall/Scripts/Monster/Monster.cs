using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{

}
public class Monster : MonoBehaviour
{
    [Header("Require")]
    [SerializeField]
    private MonsterData monsterData;

    [Header("Attribute")]
    public float health; // HP
    public float speed; // 이동 속도
    public float damage; // 공격력
    public float range; // 공격 범위 콜리전에 적용할듯함
    public float delay; // 공격 간격
    private void Start()
    {
        
    }
}