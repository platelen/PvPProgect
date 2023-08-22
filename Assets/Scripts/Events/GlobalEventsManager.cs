using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEventsManager : MonoBehaviour
    {
        public static readonly UnityEvent<int> OnAddingScore = new UnityEvent<int>();
        public static readonly UnityEvent OnStartBullet = new UnityEvent();

        public static void SendAddingScore(int addScore)
        {
            OnAddingScore.Invoke(addScore);
        }

        public static void SendStartBullet()
        {
            OnStartBullet.Invoke();
        }
    }
}