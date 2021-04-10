namespace AtomGameJamProject.Abstracts.CameraServices
{
    public interface ICameraShake
    {
        void ShakeCamera();
        bool IsCameraShake { get; set; }
    }
}