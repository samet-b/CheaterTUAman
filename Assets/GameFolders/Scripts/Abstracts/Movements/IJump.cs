namespace AtomGameJamProject.Abstracts.Movements
{
    public interface IJump
    {
        bool IsJump { get; set; }
        void Jump();
    }
}