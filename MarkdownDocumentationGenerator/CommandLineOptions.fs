module CommandLineOptions

type LudoOperation =  
    | ConvertMarkdownFileToHTMLFile of 
        inputPath       : string *
        outputPath      : string
    | GenerateLudoHTMLDocumentation of 
        inputPath       : string * 
        outputPath      : string
    | NoOperation of 
        errorMessage    : string

type LudoCommand = {
    operation   : LudoOperation;
    verbose     : bool
    }


let ParseCommandLine args ludoOperation =

    let defaultCommand = { 
        operation = NoOperation(errorMessage = "default")
        verbose = false 
        }

    let rec ParseCommandLineRecursive args ludoCommandSoFar =
        match args with

        | [] -> 
            ludoCommandSoFar

        | "--convert_markdown_to_html"::xs -> 
            let ludoConvertCommand = { ludoCommandSoFar with operation = ConvertMarkdownFileToHTMLFile("default","default") }
            match xs with
            | "--input"::xss ->
                match xss with 
                | xss::xsss ->
                   // let ludoConvertCommandWithInput = { ludoConvertCommand with ConvertMarkdownFileToHTMLFile(operation)  }
                    ParseCommandLineRecursive xsss ludoConvertCommand

                | _ ->
                    ParseCommandLineRecursive xss ludoConvertCommand

            | "--output"::xss ->
                match xss with 
                | xss::xsss ->
                    ParseCommandLineRecursive xsss ludoConvertCommand

                | _ ->
                    ParseCommandLineRecursive xss ludoConvertCommand
            
            | _ ->
                ParseCommandLineRecursive xs ludoConvertCommand
        
        | x::xs ->
            eprintfn "Option %s is not recognized." x
            ParseCommandLineRecursive xs ludoCommandSoFar


    0






//Reference code

//let testDocument = """
//# F# Hello world
//Hello world in [F#](http://fsharp.net) looks like this:
//
//    printfn "Hello world!"
//
//For more see [fsharp.org][fsorg].
//
//  [fsorg]: http://fsharp.org "The F# organization." """
//
//let parsed = Markdown.Parse(testDocument) 
//let html = Markdown.WriteHtml(parsed)  

