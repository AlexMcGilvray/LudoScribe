module LudoProcessor

open System.IO
open FSharp.Markdown
open CommandLineOptions

let ExecuteOperation ludoParams =
    0

let ConvertMarkdownToHTML inputPathToMarkdownFile outputHtmlPath =
    let markdownStream = File.OpenText(inputPathToMarkdownFile)
    let markdownString = markdownStream.ReadToEnd()
    let parsedMarkdown = Markdown.Parse(markdownString) 
    let html = Markdown.WriteHtml(parsedMarkdown)  
    File.WriteAllText(outputHtmlPath,html)
    0 //no error