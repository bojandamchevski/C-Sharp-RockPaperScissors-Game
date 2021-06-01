namespace RockPaperScissorsGame.App.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public string PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int Id { get; set; }
        
        public virtual void Stats()
        {
            throw new System.NotImplementedException();
        }
    }
}
