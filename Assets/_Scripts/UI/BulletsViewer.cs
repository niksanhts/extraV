using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.UI
{
    public class BulletsViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private char separator = '/';
        
        private void OnEnable() 
            => EventMediator.BulletCountChanged += OnBulletsCountChange;
        private void OnDisable() 
            => EventMediator.BulletCountChanged -= OnBulletsCountChange;

        private void OnBulletsCountChange(int current, int all)
        {
            textMesh.text = current.ToString() + separator + all.ToString();
        }
    }
}