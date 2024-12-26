using System;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.UI
{
    public class CharacterFightMenu : CharacterFightUI
    {
        public Image background;
        protected override void Start()
        {
            base.Start();
            background =gameObject.GetComponentInChildren<Image>();
            background.gameObject.SetActive(false);
        }

        private void Update()
        {
            background.gameObject.SetActive(character.isSelect);
        }
    }
}