using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Times
{
    public class RealTime : MonoBehaviour
    {
        public int dateTime1;  

        private void Awake()
        {
            dateTime1 = System.DateTime.Now.Hour;
            PlayerPrefs.SetInt("oldTime", dateTime1);
        }
    }
}