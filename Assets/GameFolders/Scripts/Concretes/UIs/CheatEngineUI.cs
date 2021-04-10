using AtomGameJamProject.Concretes.Controllers;
using AtomGameJamProject.Concretes.Managers;
using AtomGameJamProject.Concretes.Times;
using UnityEngine;
using UnityEngine.UI;

namespace AtomGameJamProject.Concretes.UIs
{
    public class CheatEngineUI : MonoBehaviour
    {
        [SerializeField] private GameObject indirButton;
        [SerializeField] private GameObject firstTalkText;
        [SerializeField] private GameObject syncText;
        [SerializeField] private GameObject secondTalkText;
        [SerializeField] private GameObject gameIcon;
        [SerializeField] private Slider bossHealthSlider;

        [SerializeField] private GameObject boss;

        [SerializeField] private CheatEngineTime time;

        public void OnTimeSync()
        {
            time.GetNewTime();
            syncText.SetActive(true);
        }
        public void BossHealthSlider()
        {
            if (bossHealthSlider.value <= 0.5) 
            {  
                bossHealthSlider.value = 0.5f;
            }
            if (bossHealthSlider.value < 1)
            {
                GameManager.Instance.ReduceBossHealth();
            }
        }
        public void OnTamamButtonDown()
        {
            gameIcon.SetActive(true); this.gameObject.SetActive(false);
            firstTalkText.SetActive(false);
            secondTalkText.SetActive(true);
            indirButton.SetActive(false);
        }
    }
}