using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Interacts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Interacts
{
    public class InteractWithFlash : MonoBehaviour, IInteract
    {
        private bool _isInteracted;
        public bool IsInteracted { get => _isInteracted; set => _isInteracted = value; }

        private void OnEnable()
        {
            _isInteracted = false;
        }
        public void Interact()
        {
            _isInteracted = true;
            Destroy(this.gameObject);
        }
    }
}