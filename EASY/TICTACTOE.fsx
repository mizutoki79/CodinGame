let dim = 3
let tiles = Seq.init (dim * dim) id
let combinations = Seq.concat [
    yield tiles |> Seq.groupBy (fun i -> i / dim) |> Seq.map snd
    yield tiles |> Seq.groupBy (fun i -> i % dim) |> Seq.map snd
    yield seq {seq {for i in 0 .. dim - 1 do yield dim * i  + i}; seq {for i in 1 .. dim do yield dim * i - i}}
]

let board = [| yield! Seq.init dim (fun _ -> stdin.ReadLine() |> Seq.toArray) |] |> Array.concat

combinations
    |> Seq.tryFind (fun c -> c |> Seq.sumBy (fun i -> if board.[i] = 'O' then 1 elif board.[i] = 'X' then -1 else 0) = dim - 1)
    |> function
        | Some c ->
            let move = c |> Seq.find (fun i -> board.[i] = '.')
            board.[move] <- 'O'
            for i = 0 to dim - 1 do printfn "%s" (board |> Seq.skip (i * dim) |> Seq.take dim |> Seq.toArray |> System.String)
        | None -> printfn "false"
