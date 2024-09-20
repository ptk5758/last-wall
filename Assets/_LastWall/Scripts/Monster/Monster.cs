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
    public void Hit(float damage);
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

    protected virtual void Awake()
    {
        Health = monsterData.health;
        Speed = monsterData.speed;
        Damage = monsterData.damage;
        Range = monsterData.range;
        Delay = monsterData.delay;
    }

    public virtual void Hit(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        } 
    }

    private void Die()
    {
        Event.OnDiedTrigger(this);
        gameObject.SetActive(false);
    }

    public static class Event
    {
        public static event System.Action<Monster> MonsterDied;
        public static void OnDiedTrigger(Monster data)
        {
            MonsterDied?.Invoke(data);
        }
    }
}