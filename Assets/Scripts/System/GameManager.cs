using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    [FormerlySerializedAs("GameSpeed")] public int gameSpeed;
    // Start is called before the first frame update
    
    void Start()
    {
        gameSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
