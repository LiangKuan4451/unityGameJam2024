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
        public ECharacterAction eAction;
        public int maxHealth;
        public int currentHealth;
        public int moveSpeed;
        public List<Skill> skillList;
        public List<Buff> buffList;
        public bool isSelect;
        private RoundManager roundManager;
        public ECharacterFightState ifeFightState
        {
            get => eFightState;
            set
            {
                if (eFightState != value)
                {
                    Debug.Log("asdasdsadas");
                    eFightState = value;
                    GlobalEvents.GetCharacterFightState?.Invoke(gameObject.GetComponent<Character>());
                }
            }
        }
        
        private void OnGetRoundState(RoundManager obj)
        {
            roundManager = obj;
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

        public void ChangeFightState(ECharacterFightState characterFightState)
        {
            Debug.Log(gameObject.name + "战斗状态变为" + characterFightState);
            ifeFightState = characterFightState;
        }

        public void ChangeCamp(ECharacterCamp characterCamp)
        {
            Debug.Log(gameObject.name + "阵营变为" + characterCamp);
            eCamp = characterCamp;
            GlobalEvents.GetCharacterSelected?.Invoke(gameObject.GetComponent<Character>());
        }

        public void ChangeAtion(ECharacterAction characterAction)
        {
            eAction = characterAction;
        }

        private void SelectCharacter()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, LayerMask.GetMask("Character"));
                // 检查是否击中当前对象
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("选中角色" + gameObject.name);
                    if (eCamp == ECharacterCamp.allies)
                    {
                        GlobalEvents.GetCharacterSelected?.Invoke(gameObject.GetComponent<Character>());
                        isSelect = true;
                    }
                }
                else if (hit.collider != null && hit.collider.gameObject != gameObject)
                {
                   
                    isSelect = false;
                }
                //临时
                if (eCamp == ECharacterCamp.enemy && roundManager.ECharacterCamp == ECharacterCamp.enemy)
                {
                    ChangeFightState(ECharacterFightState.waitEnd);
                }
            }
        }
        public void Awake()
        {
            currentHealth = maxHealth;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.layer = LayerMask.NameToLayer("Character");
            gameObject.tag = "Character";
        }

        private void OnEnable()
        {
            GlobalEvents.GetRoundState += OnGetRoundState;
        }
        private void OnDisable()
        {
            GlobalEvents.GetRoundState -= OnGetRoundState;
        }
       

        private void Update()
        {
            SelectCharacter();
            
        }
    }
}