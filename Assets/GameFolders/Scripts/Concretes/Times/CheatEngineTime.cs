using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Times
{
    public class CheatEngineTime : MonoBehaviour
    {
        public int dateTime2;
        public int GetNewTime()
        {
            dateTime2 = System.DateTime.Now.Hour;
            PlayerPrefs.SetInt("newTime", dateTime2);
            return dateTime2;
        }
    }
}