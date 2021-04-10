using AtomGameJamProject.Abstracts.Inputs;
using AtomGameJamProject.Concretes.Controllers;
using AtomGameJamProject.Concretes.Enums;
using AtomGameJamProject.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AtomGameJamProject.Concretes.Triggers
{
    public class RoomTrigger : MonoBehaviour
    {
        [SerializeField] private RoomEnum roomType;
        [SerializeField] private GameObject player;

        private IInput _input;

        private void Awake()
        {
            _input = new PcInput();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && this.roomType == RoomEnum.DownRoom && _input.IsEButton)
            {
                GameManager.Instance.ChangeScene(1);
            }
            if (collision.gameObject.tag == "Player" && this.roomType == RoomEnum.UpRoom && _input.IsEButton)
            {
                GameManager.Instance.ChangeScene(0);
            }
        }
    }
}