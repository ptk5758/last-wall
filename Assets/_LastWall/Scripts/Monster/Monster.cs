using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{
    public float Health { get; }
    public float Speed { get; }
    public float Damage { get; }
    public float Range { get; }
    public float Delay { get; }
}
public class Monster : MonoBehaviour, IMonster
{
    [Header("Require")]
    [SerializeField]
    private MonsterData monsterData;

    #region Attribute
    [Header("Attribute")]
    [SerializeField]
    private float health;
    public float Health { get => health; set => health = value; }
    [SerializeField]
    private float speed;
    public float Speed { get => speed; set => speed = value; }
    [SerializeField]
    private float damage;
    public float Damage { get => damage; set => damage = value; }
    [SerializeField]
    private float range;
    public float Range { get => range; set => range = value; }
    [SerializeField]
    private float delay;
    public float Delay { get => delay; set => delay = value; }
    #endregion
    private void Start()
    {
        
    }
}