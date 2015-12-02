module CommandLineOptions

open System.IO
open FSharp.Markdown

type OutputType =
    | Website       = 1
    | DocumentPDF   = 2

type DocumentationConversionOptions = {
    rootDocument    : string;
    outputType      : OutputType;
    }

type MarkdownToHTMLConversionOptions = {
    input           : string;
    output          : string;
    }

let ConvertMarkdownToHTML inputPathToMarkdownFile outputHtmlPath =
    let markdownStream = File.OpenText(inputPathToMarkdownFile)
    let markdownString = markdownStream.ReadToEnd()
    let parsedMarkdown = Markdown.Parse(markdownString) 
    let html = Markdown.WriteHtml(parsedMarkdown)  
    File.WriteAllText(outputHtmlPath,html)
    0 //no error



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

