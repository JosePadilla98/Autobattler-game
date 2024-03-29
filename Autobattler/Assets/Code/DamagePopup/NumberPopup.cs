﻿using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Autobattler.DamagePopup
{
    public enum NumberPopupTypes
    {
        DAMAGE,
        CRITICAL_DAMAGE,
        HEALTH
    }

    [Serializable]
    public struct NumberPopupData
    {
        public Color color;
        public float fontSize;
    }

    //TODO: Hacer este sistema en condiciones
    public class NumberPopup : MonoBehaviour
    {
        [SerializeField] private NumberPopupData criticalData;

        [SerializeField] private NumberPopupData damageData;

        [SerializeField] private readonly float DISAPPEAR_TIME = 0.7f;

        private float disappearTimer;

        [SerializeField] private NumberPopupData healthData;

        private Vector2 moveVector;
        private RectTransform rect;

        private TMP_Text textMesh;

        public static NumberPopup Create(Transform parent, int value, NumberPopupTypes type)
        {
            var damagePopup = NumberPopupPool.Get();
            damagePopup.Setup(parent, value, type);

            return damagePopup;
        }

        private void Awake()
        {
            textMesh = GetComponent<TMP_Text>();
            rect = GetComponent<RectTransform>();
        }

        public void Setup(Transform parent, int value, NumberPopupTypes type)
        {
            textMesh.SetText(value.ToString());

            #region SET_FONT

            var fontSize = 0f;
            var color = Color.white;
            switch (type)
            {
                case NumberPopupTypes.DAMAGE:
                    fontSize = damageData.fontSize;
                    color = damageData.color;
                    break;

                case NumberPopupTypes.CRITICAL_DAMAGE:
                    fontSize = criticalData.fontSize;
                    color = criticalData.color;
                    break;

                case NumberPopupTypes.HEALTH:
                    fontSize = healthData.fontSize;
                    color = healthData.color;
                    break;
            }

            textMesh.fontSize = fontSize;
            textMesh.color = color;

            #endregion

            #region MOVEMENT

            disappearTimer = DISAPPEAR_TIME;
            var y = Random.Range(0.6f, 1);
            var x = Random.Range(-0.6f, 0.6f);
            var normalizedVector = new Vector2(x, y);
            moveVector = normalizedVector * 600f;

            #endregion

            transform.SetParent(parent);
            transform.localScale = Vector3.one;
            rect.anchoredPosition = Vector2.zero;
            enabled = true;
        }

        private void Update()
        {
            rect.anchoredPosition += moveVector * Time.deltaTime;
            moveVector -= moveVector * 8f * Time.deltaTime;

            if (disappearTimer > DISAPPEAR_TIME * .5f)
            {
                // First half of the popup lifetime
                var increaseScaleAmount = 1f;
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                // Second half of the popup lifetime
                var decreaseScaleAmount = 1f;
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }

            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                // Start disappearing
                var disappearSpeed = 3f;
                var tmp = textMesh.color;
                tmp.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = tmp;
                if (tmp.a < 0)
                {
                    enabled = false;
                    NumberPopupPool.Release(this);
                }
            }
        }
    }
}