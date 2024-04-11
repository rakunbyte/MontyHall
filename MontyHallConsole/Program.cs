using MontyHallConsole;

//https://en.wikipedia.org/wiki/Monty_Hall_problem
/*
 * Suppose you're on a game show, and you're given the choice of three doors: Behind one door is a car; behind the others, goats.
 * You pick a door, say No. 1, and the host, who knows what's behind the doors, opens another door, say No. 3, which has a goat.
 * He then says to you, "Do you want to pick door No. 2?" Is it to your advantage to switch your choice?
 */

//The Contestants are on a GameShow where they have to choose one of three doors.  If they choose the winning door they win a prize.
var contestants = GameShow.GetContestants(10000);

//Scenario 1: Contestants keep their original door choice
var stayWinners = new List<Contestant>();
var stayLosers = new List<Contestant>();

foreach (var contestant in contestants)
{
    //Each Contestant has a selected door.
    //The host shows you a different door that is a loser, removing it from possible doors
    var gameRoom = GameRoom.WithLoserDoorRemoved(contestant.SelectedDoor);
    
    //The Contestant keeps their original door choice
    var selectedDoor = gameRoom.DoorDict[contestant.SelectedDoor];
    if (selectedDoor.IsWinner)
    {
        stayWinners.Add(contestant);
    }
    else stayLosers.Add(contestant);
}

Console.WriteLine("StayWinners: " + stayWinners.Count);     //1/3
Console.WriteLine("StayLosers: " + stayLosers.Count);       //2/3

///////////////////////

//Scenario 2: Contestants switch their door choice
var switchWinners = new List<Contestant>();
var switchLosers = new List<Contestant>();
 
foreach (var contestant in contestants)
{
    //Each Contestant has a selected door.
    //The host shows you a different door that is a loser, removing it from possible doors
    var gameRoom = GameRoom.WithLoserDoorRemoved(contestant.SelectedDoor);
    
    //The Contestant switches their door choice
    var doorToSwitchTo = gameRoom.DoorDict.First(x => x.Key != contestant.SelectedDoor).Key;
    var contestantSwitched = new Contestant(doorToSwitchTo);
    
    var selectedDoor = gameRoom.DoorDict[contestantSwitched.SelectedDoor];
    if (selectedDoor.IsWinner)
    {
        switchWinners.Add(contestantSwitched);
    }
    else switchLosers.Add(contestantSwitched);
}

Console.WriteLine();
Console.WriteLine("SwitchWinners: " + switchWinners.Count);   //2/3
Console.WriteLine("SwitchLosers: " + switchLosers.Count);     //1/3

///////////////////////
