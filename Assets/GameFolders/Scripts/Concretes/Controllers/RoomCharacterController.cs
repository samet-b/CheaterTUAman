using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AtomGameJamProject.Abstracts.Controllers;

namespace AtomGameJamProject.Concretes.Controllers
{
    public sealed class RoomCharacterController : AtomGameJamProject.Abstracts.Controllers.CharacterController, IEntityController
    {
        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Update()
        {
            base.Update();
            InteractAction();
        }
        protected override void MoveAction(float hor)
        {
            base.MoveAction(hor);
        }
        protected override void InteractAction()
        {
            base.InteractAction();
        }
        protected override void FlipAction(float hor, float scaleValue)
        {
            base.FlipAction(hor, scaleValue);
        }
    }
}