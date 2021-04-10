using UnityEngine;

namespace AtomGameJamProject.Concretes.Observers
{
    public class AudioObserver : MonoBehaviour
    {
        private AudioSource _audioSource;

        private float _currentAudioTime;
        private float _audioPlayTime = 0.4f;
        private bool _isSoundPlaying;

        public float CurrentAudioTime { get => _currentAudioTime; set => _currentAudioTime = value; }
        public float AudioPlayTime { get => _audioPlayTime; set => _audioPlayTime = value; }
        public bool IsSoundPlaying { get => _isSoundPlaying; set => _isSoundPlaying = value; }
        public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }

        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            _currentAudioTime += Time.deltaTime;
            if (_currentAudioTime >= _audioPlayTime) _currentAudioTime = _audioPlayTime;
        }

        public void PlayOneShot(params AudioClip[] clips)
        {
            if (_isSoundPlaying)
                foreach (var clip in clips)
                    AudioSource.PlayOneShot(clip);
        }
        public void PlayOneShotErzurum(AudioClip clip)
        {
            AudioSource.PlayOneShot(clip);

        }
    }
}