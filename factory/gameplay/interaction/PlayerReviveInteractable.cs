using Godot;
using GameFactory.Gameplay.Gas;
using GameFactory.Networking.Netfox.Player3D;

namespace GameFactory.Gameplay.Interaction;

/// <summary>Starter/reference instant revive; the reusable interactor owns requests/range.</summary>
public partial class PlayerReviveInteractable : Node, IInteractable
{
    private NetworkPlayer3D Player => GetParent<NetworkPlayer3D>();

    public override void _Ready() => Player.AddToGroup("interactable");

    public bool CanInteract(InteractionContext context) =>
        context.Player != context.Target &&
        context.Player.OwnerPeerId == context.RequestingPeerId &&
        context.Player.Host is NetworkPlayer3D { IsIncapacitated: false } &&
        Player.GasIsDowned && !Player.GasIsDead;

    public void Interact(InteractionContext context)
    {
        if (Multiplayer.IsServer() && CanInteract(context))
            Player.GetNode<NetworkGasComponent>("NetworkGasComponent").TryRevive(context.RequestingPeerId);
    }
}
