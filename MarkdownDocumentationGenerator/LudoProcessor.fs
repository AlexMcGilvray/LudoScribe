module LudoProcessor

open System.IO
open FSharp.Markdown
open CommandLineOptions

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
        1
    | NoOperation                                           ->
        1
    | ErrorOperation (errorMessage)                         ->
        1
    | _                                                     ->
        printf "Error"
        1

  

