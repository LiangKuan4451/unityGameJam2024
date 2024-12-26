using UnityEngine;

namespace Characters.UI
{
    public class CharacterFightUI : MonoBehaviour
    {
        public Character character;
        protected virtual void Start()
        {
            character = gameObject.GetComponentInParent<Character>();
        }

        void Update()
        {
            
        }
    }
}