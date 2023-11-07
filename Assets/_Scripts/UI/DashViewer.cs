using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.UI
{
    public class DashViewer : MonoCache
    {
        [SerializeField] private List<GameObject> dashView;
        private int _dashCount;

        private void OnEnable()
        {
            _dashCount = dashView.Count;
            EventMediator.DashEnabled += OnDashEnabled;
            EventMediator.Dashed += OnDashed;
        }

        private void OnDisable()
        {
            EventMediator.DashEnabled -= OnDashEnabled;
            EventMediator.Dashed -= OnDashed;
        }


        private void OnDashEnabled()
        {
            _dashCount += 1;
            UpdateView();
        }

        private void OnDashed()
        {
            _dashCount -= 1;
            UpdateView();
        }

        private void UpdateView()
        {
            for (var i = 0; i < _dashCount; i++)
                dashView[i].SetActive(true);
            for (var i = _dashCount; i < dashView.Count; i++)
                dashView[i].SetActive(false);
        }
    }
}