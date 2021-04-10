namespace AtomGameJamProject.Abstracts.Animations
{
    public interface IAnimation
    {
        void WalkAnimation(float hor);
        void InteractAnimation();
        void DeadAnimation();
    }
}