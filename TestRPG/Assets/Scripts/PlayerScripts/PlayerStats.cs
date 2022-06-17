using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Transform")]
    [SerializeField] private Transform PlayerTransform;
    [Header("Stats")]
    [SerializeField] private bool is_alive;
    [SerializeField] private int max_hp;
    [SerializeField] private int current_hp;
    [SerializeField] private float player_speed;
    [SerializeField] private float attack_speed;
    [SerializeField] private float attack_damage;

    private int damage;
    private Vector3 position;

    public void GetDamage(string damage_type)
    {
        switch (damage_type)
        {
            case ("light"):
                damage = 1;
                break;
            case ("heavy"):
                damage = 3;
                break;
            default:
                Debug.Log("Unknow type of damage");
                break;
        }
        this.current_hp -= damage;
        
        if (this.current_hp <= 0)
        {
            this.is_alive = false;
        }
    }

    public int HowMuchHp()
    {
        return this.current_hp;
    }

    public int MaxHp()
    {
        return this.max_hp;
    }

    public float PlayerSpeed()
    {
        return this.player_speed;
    }

    public bool PlayerIsAlive()
    {
        return this.is_alive;
    }

    public float AttackSpeed()
    {
        return (1 / this.attack_speed);
    }

    public float AttackDamage()
    {
        return this.attack_damage;
    }
    
    public Vector3 PlayerPosition()
    {
        position = this.PlayerTransform.position;
        return this.position;
    }
}
