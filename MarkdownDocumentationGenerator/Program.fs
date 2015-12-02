// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharp.Markdown
open System


let alexTest = 4
let alexTest2 = alexTest + 4


[<EntryPoint>]
let main argv = 
    let filteredArgs = argv.Length
    printfn "%A %A" alexTest2 filteredArgs
    Console.ReadKey() |> ignore
    0 // return an integer exit code




