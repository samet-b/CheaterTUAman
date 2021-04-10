using AtomGameJamProject.Abstracts.Inputs;
using AtomGameJamProject.Concretes.Enums;
using AtomGameJamProject.Concretes.Managers;
using AtomGameJamProject.Concretes.Observers;
using AtomGameJamProject.Concretes.Times;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.UIs
{
    public class ComputerUI : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioClip mouseEffectClip;
        [SerializeField] private AudioObserver _audioObserver;
        [SerializeField] private ComputerUIEnum _uiEnum;

        private IInput _input;

        private int _erzurumClickTime;

        private void Awake()
        {
            _input = new PcInput();
        }
        private void Update()
        {
            if (_input.IsQuitButtonDown && this._uiEnum == ComputerUIEnum.First)
            {
                GameManager.Instance.ChangeScene(0);
            }
            if (_input.IsQuitButtonDown && this._uiEnum == ComputerUIEnum.Second)
            {
                GameManager.Instance.ChangeScene(7);
            }

            if (_input.IsFireButtonDown)
            {
                _audioObserver.IsSoundPlaying = true;
                _audioObserver.PlayOneShot(mouseEffectClip);
            }
        }

        public void GameIconPressed()
        {
            GameManager.Instance.StartGame(3);
            Cursor.visible = true;
        }
        public void ErzurumGameButtonPressed()
        {
            _erzurumClickTime++;

            if (_erzurumClickTime == 1)
                _audioObserver.PlayOneShotErzurum(clip);
            if (_erzurumClickTime == 2)
                _audioObserver.AudioSource.Pause();
        }
    }
}