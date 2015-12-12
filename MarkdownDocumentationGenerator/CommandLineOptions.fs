module CommandLineOptions

type LudoOperation =  
    | ConvertMarkdownFileToHTMLFile of 
        inputPath       : string *
        outputPath      : string
    | GenerateLudoHTMLDocumentation of 
        inputPath       : string * 
        outputPath      : string
    | NoOperation 
    | ErrorOperation of
        errorMessage    : string

type LudoCommand = {
        operation   : LudoOperation;
        verbose     : bool
    }

let ParseCommandLine args =

    let defaultCommand = { 
        operation = NoOperation
        verbose = false 
        }
    
    let rec ParseMarkdownToHTMLOp args ludoOpSoFar = 
        match args with
        | xs::xss ->
            let ludoConvertOp       = ludoOpSoFar.operation

            match ludoConvertOp with 
            | ConvertMarkdownFileToHTMLFile ("default","default") ->
                let ludoConvertOpWithInput  = ConvertMarkdownFileToHTMLFile(xs,"default")
                let newLudoConvertCommand   = { ludoOpSoFar with operation = ludoConvertOpWithInput }
                ParseMarkdownToHTMLOp xss newLudoConvertCommand
            
            | ConvertMarkdownFileToHTMLFile (inputPath,"default") ->
                let ludoConvertOpWithOutput = ConvertMarkdownFileToHTMLFile(inputPath,xs)
                let newLudoConvertCommand   = { ludoOpSoFar with operation = ludoConvertOpWithOutput }
                newLudoConvertCommand
            
            | _ ->
                let logicErrorMsg           = "Malformed ConvertMarkdownFileToHTMLFile structure. Program logic error."
                let errorOperation          = { defaultCommand with operation = ErrorOperation(logicErrorMsg) }
                errorOperation
        | _ ->
            let userInputErrorMsg   = "Error no inputpath specified"
            let errorOperation      = { defaultCommand with operation = ErrorOperation(userInputErrorMsg) }
            errorOperation

    let rec GenerateLudoHTMLDocumentationOp args ludoOpSoFar = 
        match args with
        | xs::xss ->
            let ludoConvertOp       = ludoOpSoFar.operation

            match ludoConvertOp with 
            | GenerateLudoHTMLDocumentation ("default","default") ->
                let ludoConvertOpWithInput  = GenerateLudoHTMLDocumentation(xs,"default")
                let newLudoConvertCommand   = { ludoOpSoFar with operation = ludoConvertOpWithInput }
                GenerateLudoHTMLDocumentationOp xss newLudoConvertCommand
            
            | GenerateLudoHTMLDocumentation (inputPath,"default") ->
                let ludoConvertOpWithOutput = GenerateLudoHTMLDocumentation(inputPath,xs)
                let newLudoConvertCommand   = { ludoOpSoFar with operation = ludoConvertOpWithOutput }
                newLudoConvertCommand
            
            | _ ->
                let logicErrorMsg           = "Malformed GenerateLudoHTMLDocumentationOp structure. Program logic error."
                let errorOperation          = { defaultCommand with operation = ErrorOperation(logicErrorMsg) }
                errorOperation
        | _ ->
            let userInputErrorMsg   = "Error no inputpath specified"
            let errorOperation      = { defaultCommand with operation = ErrorOperation(userInputErrorMsg) }
            errorOperation

    let rec ParseCommandLineRecursive args ludoOpSoFar =
        match args with

        | [] -> 
            ludoOpSoFar

        | "--convert_markdown_to_html"::x -> 
            let ludoConvertCommand = { ludoOpSoFar with operation = ConvertMarkdownFileToHTMLFile("default","default") }
            ParseMarkdownToHTMLOp x ludoConvertCommand

        | "--generate_ludo_documentation_html"::x -> 
            let ludoConvertCommand = { ludoOpSoFar with operation = GenerateLudoHTMLDocumentation("default","default") }
            GenerateLudoHTMLDocumentationOp x ludoConvertCommand

        | x::xs ->
            eprintfn "Option %s is not recognized." x
            ParseCommandLineRecursive xs ludoOpSoFar

        | _ ->
            let userInputErrorMsg   = "Error incomplete command"
            let errorOperation      = { defaultCommand with operation = ErrorOperation(userInputErrorMsg) }
            errorOperation

    let parsedCommand = ParseCommandLineRecursive args defaultCommand
    parsedCommand


    //usages
    //--convert_markdown_to_html docin.md docout.html
    //--generate_ludo_documentation_html mdpath outputpath