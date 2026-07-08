

using Content.Shared.Popups;

namespace Content.Shared._DV.Chemistry.BlockInjection;

public sealed class BlockInjectionSystem : EntitySystem
{
    [Dependency] private readonly SharedPopupSystem _popup = default!;

    /// <summary>
    /// Gets the blocking state of either injection or drawing being blocked.
    /// Displays a popup of the blocked state. If both are blocked, will display the injection string.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="predicted"></param>
    /// <returns>True if this component exists and is blocking <i>either</i> injection or drawing. False otherwise.</returns>
    public bool IsBlocked(Entity<BlockInjectionComponent?> ent, EntityUid? user = null, bool predicted = false)
    {
        return IsBlocked(ent, BlockType.Inject, user, predicted) || IsBlocked(ent, BlockType.Draw, user, predicted);
    }

    /// <summary>
    /// Gets whether injecting is blocked.
    /// Displays a popup if blocked.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="predicted"></param>
    /// <returns>True if this component exists and is blocking injections. False otherwise.</returns>
    public bool IsInjectionBlocked(Entity<BlockInjectionComponent?> ent, EntityUid? user = null, bool predicted = false)
    {
        return IsBlocked(ent, BlockType.Inject, user, predicted);
    }

    /// <summary>
    /// Gets whether drawing is blocked.
    /// Displays a popup if blocked.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="predicted"></param>
    /// <returns>True if this component exists and is blocking drawing. False otherwise.</returns>

    public bool IsDrawingBlocked(Entity<BlockInjectionComponent?> ent, EntityUid? user = null, bool predicted = false)
    {
        return IsBlocked(ent, BlockType.Draw, user, predicted);
    }

    private bool IsBlocked(Entity<BlockInjectionComponent?> ent, BlockType direction, EntityUid? user = null, bool predicted = false)
    {
        // Find component. Don't block injection if the component doesn't exist.
        if (!Resolve(ent, ref ent.Comp))
            return false;

        // If not blocked, simply return that. Check for both cases simultaneously using the enum as a flag for the one we want.
        if (!ent.Comp.BlockInjection && direction == BlockType.Inject || !ent.Comp.BlockDraw && direction == BlockType.Draw)
            return false;

        // Component is blocking. First show a popup, then return the value.
        // Get the correct loc string.
        string? locString = direction == BlockType.Inject ? ent.Comp.InjectionBlockedPopupString : ent.Comp.DrawingBlockedPopupString;
        // Show popup
        ShowPopup(ent, locString, user, predicted);
        // Return that this component is blocking the action.
        return true;
    }

    private void ShowPopup(Entity<BlockInjectionComponent?> ent, string? locString, EntityUid? user = null, bool predicted = false)
    {
        if (user != null && locString != null) //TODO: Popup might already handle null strings?
        {
            if (predicted)
                _popup.PopupClient(Loc.GetString(locString, ("owner", ent)), user.Value, user.Value);
            else
                _popup.PopupEntity(Loc.GetString(locString, ("owner", ent)), user.Value, user.Value);
        }
    }

    private enum BlockType
    {
        Inject,
        Draw
    }
}
