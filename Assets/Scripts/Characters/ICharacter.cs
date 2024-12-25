using Scripts.Buffs;
using UnityEngine;

namespace Characters
{
    public interface ICharacter
    {
        void Damage(int damage);
        void AddBuff(Buff buffName);
        void RemoveBuff(Buff buffName);
        void Heal(int heal);
        void Move(Transform transform);
        void Die();
        void ChangeState(ECharacterFightState characterFightState);
        void ChangeCamp(ECharacterCamp characterCamp);
    }
}