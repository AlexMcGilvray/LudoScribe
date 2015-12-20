module LudoUtil

open System.IO

let rec GetAllFiles dir pattern =
        seq { yield! Directory.EnumerateFiles(dir, pattern)
              for d in Directory.EnumerateDirectories(dir) do
                  yield! GetAllFiles d pattern }

