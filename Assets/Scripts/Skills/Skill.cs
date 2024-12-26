using Unity.VisualScripting;
using UnityEngine;

namespace Skills
{
    

    public class Skill : ScriptableObject
    {
        [Header("技能范围")]
        [Range(0,99)]
        public int skillRange; 
        [Header("技能有效范围")]
        [Range(0,99)]
        public int skillEffectiveRange;
        [Header("技能伤害")]
        [Range(0,9999)]
        public int skillDamage;

        public virtual void UseSkill()
        {
            //TODO:使用技能
            Debug.Log(1);
        }
        
    }

}