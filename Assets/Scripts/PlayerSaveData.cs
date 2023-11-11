using System;

[Serializable]
public class PlayerSaveData
{
    private int _crystal;
    private int _score;

    public int Crystal => _crystal;
    public int Score => _score;

    public PlayerSaveData(PlayerStats player)
    {
        _crystal = player.Crystals;
        _score = player.MaxScore;
    }
}
