namespace AgileKatas.SnakesAndLadders.Domain
{
    public interface IGameSettings
    {
        int SquaresOnBoard { get; set; }
        int PlayerCount { get; set; }
        int LadderCount { get; set; }
        int SnakeCount { get; set; }
        int MaximumTransporterRange { get; set; }
        int AllTokensStartOn { get; set; }
    }
}