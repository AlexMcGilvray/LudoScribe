module LudoProcessor

open System.IO
open FSharp.Markdown
open CommandLineOptions
open LudoUtil

type LudoDoc = {
    relativePath    : System.IO.Path;
    name            : string;
    body            : string
    }

type LudoProject = {
    documents       : LudoDoc list
    verbose         : bool
    }

let ConvertMarkdownToHTML inputPathToMarkdownFile outputHtmlPath =
    let markdownStream = File.OpenText(inputPathToMarkdownFile)
    let markdownString = markdownStream.ReadToEnd()
    let parsedMarkdown = Markdown.Parse(markdownString) 
    let html = Markdown.WriteHtml(parsedMarkdown)  
    File.WriteAllText(outputHtmlPath,html)
    0 //no error

let ConvertMarkdownToHTMLX inputPathToMarkdownFile outputHtmlPath =
    let markdownStream = File.OpenText(inputPathToMarkdownFile)
    let markdownString = markdownStream.ReadToEnd()
    let parsedMarkdown = Markdown.Parse(markdownString) 
    let html = Markdown.WriteHtml(parsedMarkdown)  
    File.WriteAllText(outputHtmlPath,html)

let GenerateLudoDocumentationHTML inputPathToMarkdownProjectRoot outputPath =  
    
    let documentsEmptyList = []
    let project = { documents = List.empty<LudoDoc>; verbose = false }


    let CreateLudoProject rootPath projectSoFar =
         
        
        0      

  

    LudoUtil.GetAllFiles inputPathToMarkdownProjectRoot "*.md"
        |> Seq.iter (fun item -> ConvertMarkdownToHTMLX item outputPath) |> ignore

    LudoUtil.GetAllFiles inputPathToMarkdownProjectRoot "*.md"
        |> Seq.iter (printfn "%s")

    0



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

  

