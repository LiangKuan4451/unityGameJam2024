using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "SceiptableObjects/Player Data", order = 100)]
public class PlayerDataSO : ScriptableObject
{
   [Header("感染性")]
   [SerializeField]private float infectivity;
   [Header("破坏性")]
   [SerializeField]private float destructiveness;
   [Header("隐蔽性")]
   [SerializeField]private float invisibility;

   public float Infectivity
   {
      get => infectivity;
      set => infectivity = value;
   }

   public float Destructiveness
   {
      get => destructiveness;
      set => destructiveness = value;
   }

   public float Invisibility
   {
      get => invisibility;
      set => invisibility = value;
   }
}
