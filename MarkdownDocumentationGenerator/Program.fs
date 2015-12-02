module Program

open CommandLineOptions 
open System 


[<EntryPoint>]
let main argv = 
    let filteredArgs = argv.Length  
    let inputPath = argv.[0]
    let outputPath = argv.[1] 
    printfn "input : %A \n" inputPath
    printfn "output : %A \n" outputPath
    let result = CommandLineOptions.ConvertMarkdownToHTML inputPath outputPath
    Console.ReadKey() |> ignore
    
    0 // return an integer exit code




