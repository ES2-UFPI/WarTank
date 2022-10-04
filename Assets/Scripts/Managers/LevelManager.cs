using Fusion;
using TMPro;
using UnityEngine;

public class LevelManager : NetworkBehaviour {
    public TMP_Text ResultText;
    public PlayerRef Winner;

    public void CheckWinner()
    {
        if (!Object.HasStateAuthority) return;
        var players = FindObjectsOfType<PlayerBehavirour>();

        if (players.Length <= 1)
        {
            if (players.Length <= 0)
            {
                RPC_ShowWinner("Empate");
                return;
            }
            
            Winner = players[0].Object.InputAuthority;
            RPC_ShowWinner(GameManager.Instance.GetPlayerNick(Winner));
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void RPC_ShowWinner(string nick)
    {
        ResultText.text = $"Vencedor: {nick}";
    }
}
