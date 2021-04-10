namespace AtomGameJamProject.Abstracts.Inputs
{
    public interface IInput
    {
        float Horizontal { get; }
        bool Jump { get; }
        bool IsInteractButtonDown { get; }
        bool IsFireButtonDown { get; }
        bool IsEButton { get; }
        bool IsQuitButtonDown { get; }
    }
}