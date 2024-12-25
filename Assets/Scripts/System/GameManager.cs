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
        OnSelectAllies();
    }
    
    private void SelectCharacter(Character character)
    {
        currentSelectCharacter = character;
        Debug.Log($"Selected character: {character}");
    }

    private void OnSelectAllies()
    {
    
            Debug.Log("点击");
            // 将鼠标位置转换为世界坐标
           
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(Input.mousePosition);
                Debug.Log(mousePosition);
                // 使用射线检测
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                    
                // 检查是否击中当前对象
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("选中角色" + gameObject.name);
                    GlobalEvents.OnCharacterSelected?.Invoke(gameObject.GetComponent<Character>());
                }
         
                
        
    }
}
