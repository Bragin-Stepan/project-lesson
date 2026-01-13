using UnityEngine;
using UnityEngine.UI;

namespace Project.Wallet
{
    public class CurrencyImageUI : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        
        public void Initialize(Sprite icon)
        {
            _iconImage.sprite = icon;
        }
    }
}