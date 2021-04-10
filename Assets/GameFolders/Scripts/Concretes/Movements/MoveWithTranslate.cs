using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Movements;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Movements
{
    public class MoveWithTranslate : IMover
    {
        private IEntityController _entityController;
        private float _moveSpeed;

        public MoveWithTranslate(IEntityController entityController, float moveSpeed)
        {
            _entityController = entityController;
            _moveSpeed = moveSpeed;
        }

        public void Move(float dir)
        {
            _entityController.transform.Translate(Vector2.right * dir * Time.deltaTime * _moveSpeed);
        }
    }
}