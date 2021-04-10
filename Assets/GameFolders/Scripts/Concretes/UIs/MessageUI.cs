using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.UIs
{
    public class MessageUI : MonoBehaviour
    {
        [SerializeField] private GameObject cheatEngine;
        public void ButtonClick()
        {

            cheatEngine.SetActive(true);
        }
    }
}