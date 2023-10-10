using System;
using _Game.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class ResourceBarItem : MonoBehaviour
    {
        [SerializeField] protected Text currencyAmount;
        [SerializeField] protected Button btnAdd;
        
        [SerializeField] protected ECurrency currencyType;
        [SerializeField] protected int giftType;

        private long _amount;
        private void Start()
        {
            btnAdd.onClick.AddListener(OnAddCurrencyClick);
            UpdateCurrencyAmount();
        }

        private void OnAddCurrencyClick()
        {
            UIManager.Instance.PushPopupPanel("资源商店", "欢迎光临资源商城");
        }

        private void UpdateCurrencyAmount()
        {
            _amount = DataManager.Instance.GetCurrencyAmount(currencyType, giftType);
            currencyAmount.text = _amount.ToString();
        }

        private void OnDestroy()
        {
            btnAdd.onClick.RemoveListener(OnAddCurrencyClick);
        }
    }

    public enum ECurrency
    {
        Coin,
        Rose,
        Gift
    }
}