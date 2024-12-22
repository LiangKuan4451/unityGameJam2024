using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Unity.Collections;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;


public enum EInfectionState
{
    Uninfected,  // 未感染
    Infecting,   // 感染中
    FullyInfected // 完全感染
}

public enum EDestructionState
{
    Undestroyed,  // 未破坏
    Destroying,   // 破坏中
    FullyDestroyed // 完全破坏
}

public enum EInfectableState
{
    NotInfectable, // 不可感染
    Infectable   // 可感染
}

public enum EParticipationState
{
    NotParticipating, // 未参与
    Participating // 正在参与
}

[ExecuteInEditMode]
public class Area : MonoBehaviour
{
    #region 区域属性

    [Header("抗感染性")]
    public int antiInfectivity;
    
    [Header("抗破坏性")]
    public int antiDestructiveness;
    
    [Header("抗隐蔽性")]
    public int antiInvisibility;
    
    [Header("数据总量")]
    public int dataTotal;
    
    [Header("相邻区域列表")]
    public List<Area> adjacentAreas;
    
    [Header("感染数量")]
    public int _infectionTotal;
    
    [Header("破坏数量")]
    public int _destructionTotal;
    
    [Header("感染速率")]
    public float _infectionRate;
    
    #endregion
    
    [Header("感染状态")]
    public EInfectionState eInfectionState = EInfectionState.Uninfected;

    [Header("破坏状态")]
    public EDestructionState eDestructionState = EDestructionState.Undestroyed;

    [Header("可感染状态")]
    public EInfectableState eInfectableState = EInfectableState.NotInfectable;

    [Header("参与解析状态")]
    public EParticipationState eParticipationState = EParticipationState.NotParticipating;


    public PlayerData _playerData;
    public GameManager _gameManager;
    public LayerMask detectionLayer;
    

    private UniTaskVoid infectionTask;
    private LineRenderer lineRenderer;


    public void Infection(int data)
    {
        dataTotal -= data;
        _infectionTotal += data;
    }

    public void Destruct(int data)
    {
        _infectionTotal -= data;
        _destructionTotal += data;
    }
    
    public void StartInfection()
    {
        if (eInfectableState == EInfectableState.Infectable)
        {
            Debug.Log("开始感染");
            _infectionTotal+= 1;
            eInfectionState = EInfectionState.Infecting;
            infectionTask = UpdateInfectionData();
        }
    }
    private void HandleObject(Color color)
    {
        // 示例：更改对象的颜色
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    private async UniTaskVoid UpdateInfectionData()
    {
        while (eInfectionState == EInfectionState.Infecting)
        {
            if (_infectionTotal < dataTotal)
            {
                _infectionTotal += (int)(_infectionRate * _gameManager.gameSpeed);
                if (_infectionTotal > dataTotal)
                {
                    _infectionTotal = dataTotal;
                }
            }

            if (_destructionTotal > dataTotal)
            {
                _destructionTotal = dataTotal;
            }

            await UniTask.Delay(1000); // 延迟 1 秒
        } 
    }

    private void Start()
    {
        // 初始化 LineRenderer
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f; // 设置线条宽度
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // 使用简单材质
        lineRenderer.startColor = Color.cyan; // 设置起始颜色
        lineRenderer.endColor = Color.cyan;
        lineRenderer.useWorldSpace = true; // 使用世界坐标
    }

    private void Update()
    {
        //感染速率
        _infectionRate = _playerData.infectivity - antiInfectivity;
        UpdateLines();
        foreach (var obj in adjacentAreas.ToList())
        {
            Debug.Log(obj);
            if (obj == null)
            {
                adjacentAreas.Remove(obj);
            }
        }
    }

    private void OnMouseOver()
    {
        HandleObject(Color.red);
    }

    private void OnMouseExit()
    {
        HandleObject(Color.white);
    }

    private void OnMouseUp()
    {
        if (_playerData.infectivity >= antiInfectivity && eInfectableState == EInfectableState.NotInfectable)
        {
            eInfectableState = EInfectableState.Infectable;
            _gameManager.infectedAreaList.Add(this);
            StartInfection();
        }
        else
        {
            Debug.Log("感染失败");
        }
        
    }
  
    private void UpdateLines()
    {
        if (adjacentAreas == null || adjacentAreas.Count == 0)
        {
            lineRenderer.positionCount = 0;
            return;
        }

        // 为每个相邻区域绘制线条
        lineRenderer.positionCount = adjacentAreas.Count * 2; // 每条线两个点
        int index = 0;

        foreach (var adjacentArea in adjacentAreas)
        {
            if (adjacentArea != null)
            {
                // 设置线段起点和终点
                lineRenderer.SetPosition(index++, transform.position);
                lineRenderer.SetPosition(index++, adjacentArea.transform.position);
            }
        }
    }
}
