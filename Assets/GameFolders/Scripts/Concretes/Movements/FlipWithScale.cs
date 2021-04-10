using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Movements
{
    public class FlipWithScale : IFlip
    {
        private IEntityController _entityController;
        private bool _isLookingLeft;
        public bool IsLookingLeft { get => _isLookingLeft; set => _isLookingLeft = value; }

        public FlipWithScale(IEntityController entityController)
        {
            _entityController = entityController;
        }
        void IFlip.Flip(float hor, float scaleValue)
        {
            if (hor == 0) return;
            hor = Mathf.Sign(hor);

            if (hor < 0)
            {
                _entityController.transform.localScale = new Vector2(hor - scaleValue, _entityController.transform.localScale.y);
                _isLookingLeft = true;
            }
            if (hor > 0)
            {
                _entityController.transform.localScale = new Vector2(hor + scaleValue, _entityController.transform.localScale.y);
                _isLookingLeft = false;
            }
        }
    }
}