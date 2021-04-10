using AtomGameJamProject.Concretes.Managers;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Triggers
{
    public class BossLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                GameManager.Instance.ChangeScene(5);
            }
        }
    }
}