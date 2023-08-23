using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Slider _hpBar;

        public void SetHpBar(int health)
        {
            _hpBar.value = health;
        }

        public void SetMaxHealth(int health)
        {
            _hpBar.maxValue = health;
            _hpBar.value = health;
        }
    }
}