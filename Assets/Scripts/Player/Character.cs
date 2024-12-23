
using System;
using Player;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Serialization;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Character : MonoBehaviour,ICharacter
{
    [FormerlySerializedAs("camp")] public ECharacterCamp eCharacterCamp;
    [FormerlySerializedAs("fightState")] public ECharacterFightState eCharacterFightState;
    public int maxHealth;
    public int currentHealth;
    public int moveSpeed;

    public void Awake()
    {
        currentHealth = maxHealth;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        
    }

    public void Damage(int damage)
    {
        Debug.Log(gameObject.name+ "受到伤害" + damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
    }

    public void Move()
    {
        throw new NotImplementedException();
    }

    public void Die()
    {
        Debug.Log(gameObject.name + "死亡");
        if (eCharacterCamp == ECharacterCamp.enemy)
        {
            ChangeCamp(ECharacterCamp.allies);
        }
    }

    public void ChangeState(ECharacterFightState characterFightState)
    {
        Debug.Log(gameObject.name +  "状态变为" + characterFightState);
        eCharacterFightState = characterFightState;
    }

    public void ChangeCamp(ECharacterCamp characterCamp)
    {
        Debug.Log(gameObject.name + "阵营变为" + characterCamp);
        eCharacterCamp = characterCamp;
    }
}
