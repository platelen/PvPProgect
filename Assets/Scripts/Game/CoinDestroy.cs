using Events;
using UnityEngine;

namespace Game
{
    public class CoinDestroy : MonoBehaviour
    {
        [SerializeField] private int _addScore;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GlobalEventsManager.SendAddingScore(_addScore);
                Destroy(gameObject);
            }
        }
    }
}