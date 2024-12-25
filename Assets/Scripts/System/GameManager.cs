using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public int gameSpeed;
    public Character currentSelectCharacter;
    public List<Character> characterList;

    private void OnEnable()
    {
        GlobalEvents.OnCharacterSelected += SelectCharacter;
    }

    private void OnDisable()
    {
        GlobalEvents.OnCharacterSelected -= SelectCharacter;
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
    
    private void SelectCharacter(Character character)
    {
        currentSelectCharacter = character;
        Debug.Log($"Selected character: {character}");
    }

    public Character GetSelectedCharacter()
    {
        return currentSelectCharacter;
    }
}
