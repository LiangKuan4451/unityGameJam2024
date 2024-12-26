using System.Collections;
using System.Collections.Generic;
using Characters;
using Characters.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterFightHealthBar : CharacterFightUI
{
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().fillAmount = (float)character.currentHealth / character.maxHealth;
    }
}
