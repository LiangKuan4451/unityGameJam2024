using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Skill/Attack", order = 1)]
    public class Attack : Skill
    {
        public override void UseSkill()
        {
            base.UseSkill();
            
        }
    }
}