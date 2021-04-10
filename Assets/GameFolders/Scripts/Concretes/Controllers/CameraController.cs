using AtomGameJamProject.Abstracts.CameraServices;
using AtomGameJamProject.Abstracts.Controllers;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Controllers
{
    public class CameraController : MonoBehaviour, ICameraShake
    {
        [Header("------CameraLook------")]
        [SerializeField] private float smoothCameraLook = default;

        [Header("------CameraShake------")]
        [SerializeField] private float slowCameraShake = default;
        [SerializeField] private float startDuration = default;


        private IEntityController _entityController;

        private bool _isCameraShake = false;
        private float _duration = default;

        public bool IsCameraShake { get => _isCameraShake; set => _isCameraShake = value; }

        private void Start()
        {
            _entityController = FindObjectOfType<AtomGameJamProject.Abstracts.Controllers.CharacterController>();
        }
        private void Update()
        {
            if (_entityController == null) return;
            SetCameraLook();
        }
        private void SetCameraLook()
        {
            Vector3 playerVec = new Vector3(_entityController.transform.position.x, _entityController.transform.position.y + 2, -10);
            Vector3 smoothVec = Vector3.Lerp(transform.position, playerVec, smoothCameraLook);
            transform.rotation = _entityController.transform.rotation;
            transform.position = smoothVec;
        }
        public void ShakeCamera()
        {
            if (IsCameraShake)
            {
                if (_duration > 0)
                {
                    transform.localPosition = transform.localPosition + Random.insideUnitSphere * 0.09f;
                    _duration -= Time.deltaTime * slowCameraShake;
                }
                else
                {
                    IsCameraShake = false;
                    _duration = startDuration;
                    transform.localPosition = transform.localPosition;
                }
            }
            if(!IsCameraShake) transform.localPosition = new Vector3(0, 0, -10);
        }
    }
}
