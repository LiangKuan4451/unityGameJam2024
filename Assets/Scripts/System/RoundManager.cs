using System.Collections.Generic;
using Characters;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace System
{
    public class RoundManager : MonoBehaviour
    {
        public List<Character> aliveCharacters;
        public List<Character> enemyCharacters;
        public ECharacterCamp ECharacterCamp;
        private void OnEnable()
        {
            GlobalEvents.GetCharacterFightState += OnGetCharacterFightState;
        }

        private void OnDisable()
        {
            GlobalEvents.GetCharacterFightState -= OnGetCharacterFightState;
        }

        private void OnGetCharacterFightState(Character obj)
        {
            if (obj.eFightState == ECharacterFightState.waitEnd || obj.eAction == ECharacterAction.die)
            {
                aliveCharacters.Remove(obj);
                enemyCharacters.Remove(obj);
            }
            
        }

        public void GetCharacter()
        {
            GameObject[] characterObjects = GameObject.FindGameObjectsWithTag("Character");

            foreach (GameObject obj in characterObjects)
            {
                // 尝试获取 Character 组件
                Character character = obj.GetComponent<Character>();
                character.ChangeFightState(ECharacterFightState.start);
                if (character != null)
                {

                    if (character.eCamp == ECharacterCamp.allies)
                    {
                        aliveCharacters.Add(character);
                    }

                    if (character.eCamp == ECharacterCamp.enemy)
                    {
                        enemyCharacters.Add(character);
                    }
                }
                else
                {
                    Debug.LogWarning($"GameObject {obj.name} has 'Character' tag but no Character component!");
                }
            }
        }
        public void Start()
        {
            ECharacterCamp = ECharacterCamp.allies;
            GetCharacter();
            GlobalEvents.GetRoundState?.Invoke(gameObject.GetComponent<RoundManager>());

        }

      
        public void Update()
        {
            if (ECharacterCamp == ECharacterCamp.allies && aliveCharacters.Count == 0)
            {
                ECharacterCamp = ECharacterCamp.enemy;
                GlobalEvents.GetRoundState?.Invoke(gameObject.GetComponent<RoundManager>());
            }

            if (ECharacterCamp == ECharacterCamp.enemy && enemyCharacters.Count == 0)
            {
                ECharacterCamp = ECharacterCamp.allies;
                GlobalEvents.GetRoundState?.Invoke(gameObject.GetComponent<RoundManager>());
            }

            if (aliveCharacters.Count == 0 && enemyCharacters.Count == 0)
            {
                GetCharacter();
            }
        }
    }
}