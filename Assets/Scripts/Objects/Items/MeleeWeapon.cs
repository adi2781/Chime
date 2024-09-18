using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : AItem
{
    [SerializeField] protected string WeaponName;
    [SerializeField] protected float MaxHP;
    [SerializeField] protected float HP;
    [SerializeField] protected float AttackCooldown;
    [SerializeField] protected float AttackSpeed;
    [SerializeField] protected float Range;
    [SerializeField] protected float Damage;   

    public override void PrimaryAction() 
    {

    }

    public void WeaponTakeDamage(float damage) 
    {
        if (HP > damage) {
            HP -= damage;
        }
        else {
            Destroy(gameObject);
        }
            
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy") {
            BasicEnemy enemy = other.gameObject.GetComponent<BasicEnemy>();
            enemy.TakeDamage(Damage, enemy.GetEnemyType()); // enemy takes damage
            WeaponTakeDamage(enemy.Damage); // weapon also takes damage
        }
    }

    public void UpgradeWeapon(float additionalDamage, float additionalSpeed, float additionalRange, float additionalHP)
    {
        Damage += additionalDamage;
        AttackSpeed += additionalSpeed;
        Range += additionalRange;
        MaxHP += additionalHP;
    }


    public abstract void Attack();

    


}