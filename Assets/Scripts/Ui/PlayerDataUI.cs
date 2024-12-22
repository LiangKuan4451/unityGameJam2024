using TMPro;
using UnityEngine;

namespace Ui
{
    public enum EPlayerData
    {
        infectivity,
        destructiveness,
        invisibility,
        computingPower
    }
    public class PlayerDataUI: MonoBehaviour
    {
        [Header("绑定的玩家数据")]
        public PlayerData playerData;

        [Header("选择要显示的属性")]
        public EPlayerData selectedField;
        private TMP_Text textComponent;

        private void Start()
        {
            textComponent = GetComponent<TMP_Text>();

            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                playerData = playerObject.GetComponent<PlayerData>();
                if (playerData == null)
                {
                    Debug.LogError("在玩家对象上未找到 PlayerData 组件！");
                }
            }
            else
            {
                Debug.LogError("未找到带有 'Player' 标签的对象！");
            }
        }
        void Update()
        {
            switch (selectedField)
            {
                case EPlayerData.infectivity:
                    textComponent.text = playerData.infectivity.ToString();
                    break;
                case EPlayerData.destructiveness:
                    textComponent.text = playerData.invisibility.ToString();
                    break;
                case EPlayerData.invisibility:
                    textComponent.text = playerData.destructiveness.ToString();
                    break;
                case EPlayerData.computingPower:
                    textComponent.text = playerData.computingPower.ToString();
                    break;
            }
        }
    }
}