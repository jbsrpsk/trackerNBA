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
    { Wins = 7; Losses = 7 };
    { Wins = 12; Losses = 3 };
    { Wins = 6; Losses = 8 };
    { Wins = 5; Losses = 9 };
    { Wins = 5; Losses = 11}
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

let scsPercent =
    List.map (fun team ->
        let totalGames = float (team.Stats.Wins + team.Stats.Losses)
        let scsPercent1 = (float team.Stats.Wins) / totalGames * 100.0
        (team, scsPercent1)
    ) teams

scsPercent |> List.iter (fun (team, percentage) ->
    printfn "%s's Win Rate: %.2f%%" team.Name percentage
)