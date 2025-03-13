using Robust.Shared.Serialization;

namespace Content.Client._Impstation.Toys.FakePuddle.UI;
public sealed class FakePuddleBoundUserInterface : BoundUserInterface
{
    public FakePuddleBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
        // IoCManager.InjectDependencies(this);
    }

    protected override void Open()
    {
        base.Open();
    }
}

[NetSerializable, Serializable]
public enum FakePuddleUiKey : byte
{
    Key,
};