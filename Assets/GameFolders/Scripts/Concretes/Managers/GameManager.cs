using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using AtomGameJamProject.Concretes.Controllers;
using AtomGameJamProject.Concretes.Times;

namespace AtomGameJamProject.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private BossController _boss;
        [SerializeField] private RealTime _oldTime;

        public int sceneValue = 0;

        private void Awake()
        {
            SingletonMethod();
            PlayerPrefs.SetInt("scene", sceneValue);
        }
        public void StartGame(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        public void ChangeScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        public void QuitGame(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        public void RoomChange(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        public void UnloadRoomScene(int buildIndex)
        {
            StartCoroutine(UnloadRoomSceneAsync(buildIndex));
        }
        private IEnumerator UnloadRoomSceneAsync(int buildIndex)
        {
            yield return SceneManager.UnloadSceneAsync(buildIndex);
        }
        public void ReduceBossHealth()
        {
            _boss.GetComponent<BossController>().MaxHealth = 5;
            _boss.GetComponent<BossController>().Health = 5;
        }
        public int GetOldTime()
        {
            Debug.Log("OLD TIME PREFS:" + PlayerPrefs.GetInt("oldTime", _oldTime.dateTime1));
            Debug.Log("OLD TIME");
            return _oldTime.dateTime1;
        }
        private void SingletonMethod()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}