using AtomGameJamProject.Abstracts.Inputs;
using UnityEngine;

public class PcInput : IInput
{
    public float Horizontal => Input.GetAxisRaw("Horizontal");
    public bool Jump => Input.GetKeyDown(KeyCode.Space);
    public bool IsInteractButtonDown => Input.GetKeyDown(KeyCode.F);
    public bool IsEButton => Input.GetKey(KeyCode.E);
    public bool IsFireButtonDown => Input.GetMouseButtonDown(0);
    public bool IsQuitButtonDown => Input.GetKeyDown(KeyCode.Escape);
}