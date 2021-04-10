using UnityEngine;
using System.Collections;
using AtomGameJamProject.Concretes.Enums;
using UnityEngine.SceneManagement;

namespace AtomGameJamProject.Concretes.Controllers
{
    public class EyeController : MonoBehaviour
    {
        [SerializeField] private EyeEnum eyeEnum;

        private Animator _animator;
        private const int PLAY_TIME = 1;
        private int _currentPlayedTime = 0;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            if (this.eyeEnum == EyeEnum.TopEye)
                _animator.SetTrigger("top");
            if (this.eyeEnum == EyeEnum.BottomEye)
                _animator.SetTrigger("bottom");

            if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
            {
                _currentPlayedTime++;
            }
            Debug.Log(_currentPlayedTime);
        }
        /*private IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
        }*/
    }
}