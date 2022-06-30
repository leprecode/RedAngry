using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Assets.Code.PlayerLogic
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Image _playerHealthSlider;
        [SerializeField] private Image _playerDamagedSlider;
        [SerializeField] private TextMeshProUGUI _playerHealthText;
        [SerializeField] private TextMeshProUGUI _damagedText;
        [SerializeField] private TextMeshProUGUI _healedText;
        [SerializeField] private RectTransform _popUpTarget;
        [SerializeField] private RectTransform _popUpStart;
        
        [SerializeField] private List<TextMeshProUGUI> _popUpsDamgedText = new List<TextMeshProUGUI>();
        [SerializeField] private List<TextMeshProUGUI> _popUpsHealedText = new List<TextMeshProUGUI>();

        private PlayerHealth _playerHealth;

        private Sequence _damagedSequence;


        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();

            InitializeHealthOnUI();
            PreparePopUps(_popUpsDamgedText);

            _playerHealth.OnDamage += OnDamage;
        }


        private void InitializeHealthOnUI()
        {
            //decompose

            var currentPlayerHealth = _playerHealth._currentHealth;
            _playerHealthText.SetText(currentPlayerHealth.ToString());

            var maxPlayerHealth = CalculateAmountForSlider(currentPlayerHealth);
            _playerHealthSlider.fillAmount = maxPlayerHealth;
            _playerDamagedSlider.fillAmount = maxPlayerHealth;

            _healedText.DOFade(0, 0);
        }

        private void PreparePopUps(List<TextMeshProUGUI> popUps)
        {
            for (int i = 0; i < popUps.Count; i++)
            {
                popUps[i].DOFade(0, 0);
                popUps[i].gameObject.SetActive(false);
            }
        }

        private void OnDamage(float currentHealth, float takedDamage)
        {
            ChangeTextValue(currentHealth);
            ChangeSliderValue(currentHealth);
            ShowPopUpDamage(takedDamage);
        }

        private void ShowPopUpDamage(float takedDamage)
        {
            var popUp = ChooseNewPopUp();

            if (popUp != null)
            {
                popUp.gameObject.SetActive(true);

                SetDamagedPopUpText(takedDamage, popUp);
                OnDamageSequnce(popUp);
            }

        }

        private TextMeshProUGUI ChooseNewPopUp()
        {
            for (int i = 0; i < _popUpsDamgedText.Count; i++)
            {
                if (_popUpsDamgedText[i].gameObject.activeSelf == false)
                    return _popUpsDamgedText[i];
            }

            return null;
        }

        private void SetDamagedPopUpText(float takedDamage, TextMeshProUGUI popUp)
        {
            popUp.SetText("-" + takedDamage);
        }

        private void ChangeTextValue(float currentHealth)
        {
            _playerHealthText.SetText(currentHealth.ToString());
        }

        private void ChangeSliderValue(float currentHealth)
        {
            float targetValue = CalculateAmountForSlider(currentHealth);

            _playerHealthSlider.DOFillAmount(targetValue, 0.5f);
            _playerDamagedSlider.DOFillAmount(targetValue, 2f);
        }

        private float CalculateAmountForSlider(float currentHealth)
        {
            return currentHealth / _playerHealth.MaxHealth;
        }

        private void OnDamageSequnce(TextMeshProUGUI popUpText)
        {
            _damagedSequence = DOTween.Sequence();
            _damagedSequence.Append(popUpText.DOFade(255, 0));
            _damagedSequence.Append(popUpText.rectTransform.DOMoveY(_popUpTarget.position.y, 0.5f));
            _damagedSequence.Insert(0f,popUpText.DOScale(1.5f,0.5f));
            _damagedSequence.Insert(_damagedSequence.Duration(),popUpText.DOScale(0,0.25f));
            _damagedSequence.AppendCallback(() => ResetDamagedPopUp(popUpText));
        }

        private void ResetDamagedPopUp(TextMeshProUGUI popUpText)
        {
            popUpText.gameObject.SetActive(false);
            popUpText.DOFade(0, 0);
            popUpText.DOScale(1f, 0);
            popUpText.rectTransform.position = _popUpStart.position;
        }

        private void OnHeal()
        {
        
        }
    }
}