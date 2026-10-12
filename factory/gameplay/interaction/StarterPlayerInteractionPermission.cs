using Godot;
using GameFactory.Gameplay.Gas;
using GameFactory.Networking.Netfox.Player3D;
using GameFactory.Networking.Objects;
using GameFactory.Networking.Peers;

namespace GameFactory.Gameplay.Interaction;

/// <summary>Reference-player policy: canonical server GAS, local vital projection.</summary>
public partial class StarterPlayerInteractionPermission : Node, IInteractionPermission
{
    public bool CanRequestInteraction(NetworkObject actor, PeerId requestingPeerId)
    {
        NetworkPlayer3D player = GetParent<NetworkPlayer3D>();
        return Multiplayer.IsServer()
            ? !player.GetNode<NetworkGasComponent>("NetworkGasComponent").RejectIncapacitated(requestingPeerId, "interact")
            : !player.IsIncapacitated;
    }
}
