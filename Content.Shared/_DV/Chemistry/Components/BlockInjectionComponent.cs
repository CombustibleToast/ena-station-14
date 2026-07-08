using Robust.Shared.GameStates;

namespace Content.Shared._DV.Chemistry.BlockInjection; //TODO: move to imp after overhaul

/// <summary>
/// Prevents syringes being used on this entity.
/// Hyposprays are unaffected.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class BlockInjectionComponent : Component
{
    /// <summary>
    /// Whether this component is blocking injections.
    /// Prefer to use <see cref="BlockInjectionSystem.IsInjectionBlocked"/> for popups.
    /// </summary>
    [DataField]
    public bool BlockInjection = true;

    /// <summary>
    /// Whether this component is blocking drawing.
    /// Prefer to use <see cref="BlockInjectionSystem.IsDrawingBlocked"/> for popups.
    /// </summary>
    [DataField]
    public bool BlockDraw = true;

    /// <summary>
    /// Displayed loc string in popup when injecting is blocked.
    /// Set to null for no popup.
    /// </summary>
    [DataField]
    public string? InjectionBlockedPopupString = "injector-component-deny-user";

    /// <summary>
    /// Displayed loc string in popup when drawing is blocked.
    /// Set to null for no popup.
    /// </summary>
    [DataField]
    public string? DrawingBlockedPopupString = "injector-component-deny-user";
}
