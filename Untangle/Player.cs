namespace Untangle
{
    public class Player
    {
        public string name;
        public int level;
        public int countAllMove;
        public int autoSolves;
        public int time;
        public Player(string name, int level, int countAllMove,int autoSolves,int time)
        {
            this.name = name;
            this.level = level;
            this.countAllMove = countAllMove;
            this.autoSolves = autoSolves;
            this.time = time;
        }
        public Player(Player player)
        {
            this.name = player.name;
            this.level = player.level;
            this.countAllMove = player.countAllMove;
            this.autoSolves = player.autoSolves;
            this.time = player.time;
        }
    }
}
