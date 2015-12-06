module Program

open System 
open LudoProcessor


[<EntryPoint>]
let main argv = 
    //let filteredArgs = argv.Length  
    //let inputPath = argv.[0]
    //let outputPath = argv.[1] 
    //printfn "input : %A \n" inputPath
    //printfn "output : %A \n" outputPath
    //let result = LudoProcessor.ConvertMarkdownToHTML inputPath outputPath
    printfn "Arguments passed to function : %A" argv
    let argvList = argv |> Array.toList
    let result = CommandLineOptions.ParseCommandLine argvList
    Console.ReadKey() |> ignore
    
    0 // return an integer exit code




