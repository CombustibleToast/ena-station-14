using Robust.Shared.Serialization;
using Robust.Client.UserInterface;

namespace Content.Client._Impstation.Toys.FakePuddle.UI;
public sealed class FakePuddleBoundUserInterface : BoundUserInterface
{
    private FakePuddleMenu? _window;
    public FakePuddleBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey) { }

    protected override void Open()
    {
        base.Open();
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        // if (state is not ChaplainGearMenuBoundUserInterfaceState current)
        //     return;

        _window?.UpdateState();
        // _window?.UpdateState(current);
    }
}

