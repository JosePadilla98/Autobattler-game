﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Auttobattler
{
    public enum NumberPopupTypes
    {
        DAMAGE, CRITICAL_DAMAGE, HEALTH
    }
    
    [System.Serializable]
    public struct NumberPopupData
    {
        public Color color;
        public float fontSize;
    }

    public class NumberPopup : MonoBehaviour
    {
        private const float DISAPPEAR_TIMER_MAX = 0.7f;

        private TMP_Text textMesh;
        private float disappearTimer;
        private Vector2 moveVector;
        private RectTransform rect;

        [SerializeField]
        private NumberPopupData damageData;
        [SerializeField]
        private NumberPopupData criticalData;
        [SerializeField]
        private NumberPopupData healthData;

        public static NumberPopup Create(Transform parent, int value, NumberPopupTypes type)
        {
            NumberPopup damagePopup = Instantiate(GameAssets.Instance.damagePopup, parent);
            damagePopup.Setup(value, type);

            return damagePopup;
        }

        private void Awake()
        {
            textMesh = GetComponent<TMP_Text>();
            rect = GetComponent<RectTransform>();
        }

        public void Setup(int value, NumberPopupTypes type)
        {
            textMesh.SetText(value.ToString());

            float fontSize = 0f;
            Color color = Color.white;
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
            disappearTimer = DISAPPEAR_TIMER_MAX;

            float y = Random.Range(0.6f, 1);
            float x = Random.Range(-0.3f, 0.3f);
            Vector2 normalizedVector = new Vector2(x, y);
            Debug.Log(normalizedVector);

            moveVector = normalizedVector * 600f;
        }

        private void Update()
        {
            rect.anchoredPosition += moveVector * Time.deltaTime;
            moveVector -= moveVector * 8f * Time.deltaTime;

            if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
            {
                // First half of the popup lifetime
                float increaseScaleAmount = 1f;
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                // Second half of the popup lifetime
                float decreaseScaleAmount = 1f;
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }

            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                // Start disappearing
                float disappearSpeed = 3f;
                Color tmp = textMesh.color;
                tmp.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = tmp;
                if (tmp.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}