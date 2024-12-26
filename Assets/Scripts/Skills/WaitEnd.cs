using System;
using Characters;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(fileName = "WaitEnd", menuName = "Skill/WaitEnd", order = 1)]
    public class WaitEnd : Skill
    {
        public ICharacter icharater;
        private void OnEnable()
        {
            GlobalEvents.GetCharacterSelected += GetSelectCharacter;
        }


        private void OnDisable()
        {
            GlobalEvents.GetCharacterSelected -= GetSelectCharacter;
        }
        private void GetSelectCharacter(Character obj)
        {
            icharater = obj.GetComponent<ICharacter>();
        }
        public override void UseSkill()
        {
            base.UseSkill();
            icharater.ChangeFightState(ECharacterFightState.waitEnd);
        }
    }
}