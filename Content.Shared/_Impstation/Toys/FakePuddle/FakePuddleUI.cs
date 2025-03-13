using Robust.Shared.Serialization;
using Robust.Shared.Utility;

namespace Content.Client._Impstation.Toys.FakePuddle.UI;

// [Serializable, NetSerializable]
// public sealed class ChaplainGearMenuBoundUserInterfaceState : BoundUserInterfaceState
// {
//     public readonly Dictionary<int, ChaplainGearMenuSetInfo> Sets;
//     public int MaxSelectedSets;

//     public ChaplainGearMenuBoundUserInterfaceState(Dictionary<int, ChaplainGearMenuSetInfo> sets, int max)
//     {
//         Sets = sets;
//         MaxSelectedSets = max;
//     }
// }

[NetSerializable, Serializable]
public enum FakePuddleUIKey : byte
{
    Key
};