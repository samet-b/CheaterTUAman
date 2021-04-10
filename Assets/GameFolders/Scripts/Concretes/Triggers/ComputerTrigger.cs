using AtomGameJamProject.Abstracts.Inputs;
using AtomGameJamProject.Concretes.Enums;
using AtomGameJamProject.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AtomGameJamProject.Concretes.Triggers
{
    public class ComputerTrigger : MonoBehaviour
    {

        [SerializeField] private ComputerEnum _computerEnum;
        private IInput _input;

        private void Awake()
        {
            _input = new PcInput();
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player" && _input.IsEButton && this._computerEnum == ComputerEnum.First)
            {
                GameManager.Instance.ChangeScene(2);
            }
            if (collision.gameObject.tag == "Player" && _input.IsEButton && this._computerEnum == ComputerEnum.Second)
            {
                GameManager.Instance.ChangeScene(8);
            }
        }
    }
}