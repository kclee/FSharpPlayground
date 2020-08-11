///
/// Ch17 // run in F# interactive
///

let folderNameToDaysCreation = 
    System.IO.Directory.EnumerateDirectories("C:\\") 
    |> Seq.map (fun x -> new System.IO.DirectoryInfo(x))
    |> Seq.map (fun x -> (x.Name, x.CreationTimeUtc))
    |> Map.ofSeq
    |> Map.map (fun name creationUtc -> (System.DateTime.UtcNow - creationUtc).Days)

let folderNameToFileExtensions = 
    System.IO.Directory.EnumerateFiles("C:\\") 
    |> Seq.map (fun x -> new System.IO.FileInfo(x))
    |> Seq.map (fun x -> x.Extension)
    |> Set.ofSeq