type Coach = { Name: string; FormerPlayer: bool }

type Stats = { Wins: int; Losses: int }

type Team = { Name: string; Coach: Coach; Stats: Stats }

let coaches = [
    { Name = "Quin Snyder"; FormerPlayer = true };
    { Name = "Joe Mazzulla"; FormerPlayer = false };
    { Name = "Jacque Vaughn"; FormerPlayer = false };
    { Name = "Steve Clifford"; FormerPlayer = true };
    { Name = "Billy Donovan"; FormerPlayer = true }
]

let teamNames = ["Atlanta Hawks"; "Boston Celtics"; "Brooklyn Nets"; "Charlotte Hornets"; "Chicago Bulls"]

let stats = [
    { Wins = 8; Losses = 7 };
    { Wins = 0; Losses = 12 };
    { Wins = 0; Losses = 6 };
    { Wins = 7; Losses = 5 };
    { Wins = 7; Losses = 5 }
]

let teams =
    List.map3
        (fun coach teamName stat -> { Name = teamName; Coach = coach; Stats = stat })
        coaches teamNames stats


let successfulTeams =
    teams
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)


successfulTeams |> List.iter (fun team ->
    printfn "%s\t%d-%d\t%s"
        team.Coach.Name team.Stats.Wins team.Stats.Losses team.Name
)
