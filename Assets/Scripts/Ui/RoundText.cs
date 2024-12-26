using System;
using System.Diagnostics.Tracing;
using Characters;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class RoundText : MonoBehaviour
    {
        private void OnEnable()
        {
            GlobalEvents.GetRoundState += OnGetRoundState;
        }

        private void OnDisable()
        {
            GlobalEvents.GetRoundState -= OnGetRoundState;
        }

        private void OnGetRoundState(RoundManager obj)
        {
            Debug.Log("改变回合文本");
            if (obj.ECharacterCamp == ECharacterCamp.enemy)
            {
                gameObject.GetComponent<TMP_Text>().text = "Enemy turn";
            }
            else
            {
                gameObject.GetComponent<TMP_Text>().text = "Your turn";
            }
        }

        private void Update()
        {
      
        }
    }
}