module Program

open CommandLineOptions
open FSharp.Markdown
open System
open System.IO

let testDocument = """
# F# Hello world
Hello world in [F#](http://fsharp.net) looks like this:

    printfn "Hello world!"

For more see [fsharp.org][fsorg].

  [fsorg]: http://fsharp.org "The F# organization." """

let parsed = Markdown.Parse(testDocument) 
let html = Markdown.WriteHtml(parsed)  

[<EntryPoint>]
let main argv = 
    let filteredArgs = argv.Length 
    File.WriteAllText("output.txt",html)
    Console.ReadKey() |> ignore
    
    0 // return an integer exit code




