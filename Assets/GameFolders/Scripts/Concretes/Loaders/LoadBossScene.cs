using AtomGameJamProject.Concretes.Managers;
using AtomGameJamProject.Concretes.Times;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBossScene : MonoBehaviour
{

    public void OnCedSpeysClicked()
    {
        GameManager.Instance.ChangeScene(8);
        Cursor.visible = true;
    }
}