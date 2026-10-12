using Godot;
using GameFactory.Gameplay.Gas;
using GameFactory.Networking.Netfox.Player3D;
using GameFactory.Networking.Objects;

namespace GameFactory.Gameplay.Carry;

/// <summary>Reference-player GAS policy, outside reusable carry.</summary>
public partial class StarterPlayerCarryPermission : Node, ICarryPermission
{
    public bool CanPickup(NetworkObject actor) => Allowed(actor, "pickup");
    public bool CanDrop(NetworkObject actor) => Allowed(actor, "drop");
    private bool Allowed(NetworkObject actor, string action)
    {
        NetworkPlayer3D player = GetParent<NetworkPlayer3D>();
        return Multiplayer.IsServer()
            ? !player.GetNode<NetworkGasComponent>("NetworkGasComponent").RejectIncapacitated(actor.OwnerPeerId, action)
            : !player.IsIncapacitated;
    }
}
