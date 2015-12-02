// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharp.Markdown
open System

module CommandLineParser = 
    
    type OutputType = 
        | Website       = 1 
        | DocumentPDF   = 2 

    type ProgramParameters = {
        rootDocument    : string;
        outputType      : OutputType;
        }

[<EntryPoint>]
let main argv = 
    let filteredArgs = argv.Length 
    Console.ReadKey() |> ignore
    0 // return an integer exit code




