module Program

open System 
open LudoProcessor

[<EntryPoint>]
let main argv = 
    printfn "Arguments passed to function : %A \n \n" argv
    let argvList        = argv |> Array.toList
    let command         = CommandLineOptions.ParseCommandLine argvList
    let commandResult   = ExecuteOperation command
    match commandResult with 
    | 0 ->
        printf("Command executred successfully")
    | 1 ->
        printf("Command failed")
    | _ ->
        printf("Unrecognized command result")
    Console.ReadKey() |> ignore
    
    0 // return an integer exit code




