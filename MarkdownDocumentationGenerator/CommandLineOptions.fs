module CommandLineOptions
    
    type OutputType = 
        | Website       = 1 
        | DocumentPDF   = 2 

    type ProgramParameters = {
        rootDocument    : string;
        outputType      : OutputType;
        }