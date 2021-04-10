namespace AtomGameJamProject.Abstracts.Movements
{
    public interface IFlip
    {
        void Flip(float hor, float scaleValue);
        bool IsLookingLeft { get; set; }
    }
}