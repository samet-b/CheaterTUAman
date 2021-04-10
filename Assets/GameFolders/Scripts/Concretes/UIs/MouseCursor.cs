using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.UIs
{
    public class MouseCursor : MonoBehaviour
    {
        private void Start()
        {
            Cursor.visible = false;
        }
        void Update()
        {
            Vector2 cursorPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPostion + new Vector2(0, -0.75f);
        }
    }
}