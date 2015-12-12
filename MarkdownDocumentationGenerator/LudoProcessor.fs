module LudoProcessor

open System.IO
open FSharp.Markdown
open CommandLineOptions

type LudoDoc = {
    relativePath    : System.IO.Path;
    filename        : string
    }

type LudoProject = {
    documents       : LudoDoc list
    verbose         : bool
    }

let GenerateLudoDocumentationHTML inputPathToMarkdownProjectRoot outputPath =  
    
    let documentsEmptyList = []
    let project = { documents = List.empty<LudoDoc>; verbose = false }

    let rec getAllFiles dir pattern =
        seq { yield! Directory.EnumerateFiles(dir, pattern)
              for d in Directory.EnumerateDirectories(dir) do
                  yield! getAllFiles d pattern }

    let CreateLudoProject rootPath projectSoFar =
        
        
        0      

    getAllFiles inputPathToMarkdownProjectRoot "*.md"
        |> Seq.iter (printfn "%s")
    0

let ConvertMarkdownToHTML inputPathToMarkdownFile outputHtmlPath =
    let markdownStream = File.OpenText(inputPathToMarkdownFile)
    let markdownString = markdownStream.ReadToEnd()
    let parsedMarkdown = Markdown.Parse(markdownString) 
    let html = Markdown.WriteHtml(parsedMarkdown)  
    File.WriteAllText(outputHtmlPath,html)
    0 //no error

let ExecuteOperation ludoCommand =
    let operation = ludoCommand.operation
    match operation with
    | ConvertMarkdownFileToHTMLFile (inputPath,outputPath)  ->
        ConvertMarkdownToHTML inputPath outputPath
    | GenerateLudoHTMLDocumentation (inputPath,outputPath)  ->
        printf "generating html documentation"
        GenerateLudoDocumentationHTML inputPath outputPath
    | NoOperation                                           ->
        1
    | ErrorOperation (errorMessage)                         ->
        1
    | _                                                     ->
        printf "Error"
        1

  

