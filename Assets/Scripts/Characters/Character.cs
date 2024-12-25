using System;
using System.Collections.Generic;
using Scripts.Buffs;
using Skills;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Character : MonoBehaviour, ICharacter
    {
        public string nickName;
        public ECharacterCamp eCamp;
        public ECharacterFightState eFightState;
        public ECharacterActionState eAction;
        public int maxHealth;
        public int currentHealth;
        public int moveSpeed;
        public List<Skill> skillList;
        public List<Buff> buffList;

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
            Debug.Log(gameObject.name + "受到伤害" + damage);
            currentHealth -= damage;
            if (currentHealth <= 0) Die();
        }

        public void AddBuff(Buff buffName)
        {
            // TODO: 添加buff
            buffList.Add(buffName);
        }

        public void RemoveBuff(Buff buffName)
        {
            // TODO: 移除buff
            buffList.Remove(buffName);
        }

        public void Heal(int heal)
        {
            currentHealth += heal;
        }

        public void Move(Transform transform)
        {
            gameObject.transform.position = transform.position;
        }

        public void Die()
        {
            Debug.Log(gameObject.name + "死亡");
            if (eCamp == ECharacterCamp.enemy) ChangeCamp(ECharacterCamp.allies);
        }

        public void ChangeState(ECharacterFightState characterFightState)
        {
            Debug.Log(gameObject.name + "状态变为" + characterFightState);
            eFightState = characterFightState;
        }

        public void ChangeCamp(ECharacterCamp characterCamp)
        {
            Debug.Log(gameObject.name + "阵营变为" + characterCamp);
            eCamp = characterCamp;
        }

       
        
    }
}