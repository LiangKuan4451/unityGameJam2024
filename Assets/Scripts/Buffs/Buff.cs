using UnityEngine;

namespace Scripts.Buffs
{
    [CreateAssetMenu(fileName = "Buff", menuName = "Buff", order = 1)]
    public class Buff : ScriptableObject
    {
        
        public string buffName;
        public int value;
        public int addRound;
        public int haveRound;
        public bool deBuff;

        public virtual void OnEnable()
        {
            
        }
    }
}