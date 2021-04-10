using AtomGameJamProject.Abstracts.Animations;
using AtomGameJamProject.Abstracts.Controllers;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Controllers
{
    public class AnimatorController : IAnimation
    {
        private IEntityController _entityController;

        public AnimatorController(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void WalkAnimation(float hor)
        {
            _entityController.transform.GetComponent<Animator>().SetFloat("speed", hor);
        }
        public void InteractAnimation()
        {

        }

        public void DeadAnimation()
        {
            _entityController.transform.GetComponent<Animator>().SetTrigger("isDead");
        }
    }
}