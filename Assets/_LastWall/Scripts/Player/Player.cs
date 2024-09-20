using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayer
{
    public void Attack(Monster monster);
}
public class Player : MonoBehaviour, IPlayer
{
    [SerializeField]
    private Monster t_target;

    public float attackPower;

    [ContextMenu("TestAttack")]
    public void T_Attack() => Attack(t_target);
    public void Attack(Monster monster)
    {
        if (monster != null)
        {
            monster.Hit(attackPower);
        }
    }
}
