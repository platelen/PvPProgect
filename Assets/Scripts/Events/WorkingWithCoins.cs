using TMPro;
using UnityEngine;

namespace Events
{
    public class WorkingWithCoins : MonoBehaviour
    {
        private int _intScore;

        private void Awake()
        {
            GlobalEventsManager.OnAddingScore.AddListener(AddingScore);
        }

        private void AddingScore(int addingScore)
        {
            _intScore += addingScore;
            GetComponent<TextMeshProUGUI>().text = "Coins: " + _intScore;
        }
    }
}