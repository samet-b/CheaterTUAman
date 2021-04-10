using AtomGameJamProject.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.UIs
{
    public class GameCanvasUI : MonoBehaviour
    {
        public void PlayButtonPressed()
        {
            GameManager.Instance.StartGame(4);
        }
        public void QuitButtonPressed()
        {
            GameManager.Instance.QuitGame(2);
        }
    }
}