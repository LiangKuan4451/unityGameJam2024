using Skills;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Characters.UI
{
    public class CharacterFightMenuButton : MonoBehaviour
    {
        public Skill Skill;
        
        public void useSkill()
        {
            Skill.UseSkill();
        }


       
    }
}