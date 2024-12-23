using System;
using System.ComponentModel;
using Player;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestObject : MonoBehaviour
    {    
        public Camera mainCamera; // 摄像机（可在 Inspector 中赋值）
        private void Update()
        {
            // 获取鼠标在屏幕上的位置
            Vector3 mousePosition = Input.mousePosition;

            // 转换为世界坐标
            mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // 设置深度
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            // 更新 GameObject 的位置
            transform.position = worldPosition;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ICharacter character = other.GetComponent<ICharacter>();
            if (other != null)
            {
                character.Damage(10);
            }
        }
    }
}