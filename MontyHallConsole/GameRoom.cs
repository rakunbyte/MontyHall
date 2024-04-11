namespace MontyHallConsole;

public record Contestant(int SelectedDoor);
public record Door(bool IsWinner);

public class GameRoom
{
    private readonly Random _random = new();

    public readonly Dictionary<int, Door> DoorDict = new()
    {
        {0, new Door(false)},
        {1, new Door(false)},
        {2, new Door(false)}
    };

    private GameRoom()
    {
        var winner = _random.Next(0, 3);
        DoorDict[winner] = new Door(true);
    }

    public static GameRoom WithLoserDoorRemoved(int selectedDoor)
    {
        var newGameRoom = new GameRoom();
        var loserDoor = newGameRoom.DoorDict.First(x => x.Key != selectedDoor && !x.Value.IsWinner);
        newGameRoom.DoorDict.Remove(loserDoor.Key);
        return newGameRoom;
    }
}

public static class GameShow {
    public static List<Contestant> GetContestants(int numberOfContestants)
    {
        var random = new Random();

        var contestants = new List<Contestant>();
        for (var i = 0; i < numberOfContestants; i++)
        {
            var selectedNumber = random.Next(0, 3);
            contestants.Add(new Contestant(selectedNumber));
        }

        return contestants;
    }
}