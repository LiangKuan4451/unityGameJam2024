using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public int gameSpeed;
    public Character currentSelectCharacter;
    

    private void OnEnable()
    {
        GlobalEvents.GetCharacterSelected += GetSelectCharacter;
    }

    private void OnDisable()
    {
        GlobalEvents.GetCharacterSelected -= GetSelectCharacter;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        gameSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    private void GetSelectCharacter(Character character)
    {
        currentSelectCharacter = character;
        Debug.Log($"Selected character: {character}");
    }
 
   
}
