namespace AtomGameJamProject.Abstracts.Interacts
{
    public interface IInteract
    {
        void Interact();
        bool IsInteracted { get; set; }
    }
}
