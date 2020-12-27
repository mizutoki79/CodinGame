open System

let dim = 3

let board = [|
    for i = 0 to dim - 1 do
        yield stdin.ReadLine() |> Seq.toArray
|]

let canWin line =
    let length = line |> Array.length
    let circleCount = line |> Seq.filter ((=)'O') |> Seq.length
    let emptyCount = line |> Seq.filter ((=)'.') |> Seq.length
    circleCount = length - 1 && emptyCount = 1

let rec resolve direction i =
    match direction with
        | 'h' ->
            let line = board.[i]
            if canWin line then
                board.[i] <- [|'O'; 'O'; 'O'|]
                true
            elif i < dim - 1 then
                resolve 'h' (i + 1)
            else
                resolve 'v' 0
        | 'v' ->
            let line = [|board.[0].[i]; board.[1].[i]; board.[2].[i]|]
            if canWin line then
                for j = 0 to dim - 1 do
                    board.[j].[i] <- 'O'
                true
            elif i < dim - 1 then
                resolve 'v' (i + 1)
            else
                resolve 'o' 0
        | 'o' ->
            let line = i |> function
                | 0 ->
                    [|
                        for j = 0 to dim - 1 do
                            yield board.[j].[j]
                    |]
                | 1 ->
                    [|
                        for j = 0 to dim - 1 do
                            yield board.[j].[dim - 1 - j]
                    |]
                |_ -> Array.create dim 'X'
            if canWin line then
                i |> function
                    | 0 ->
                        for j = 0 to dim - 1 do
                            board.[j].[j] <- 'O'
                        true
                    | 1 ->
                        for j = 0 to dim - 1 do
                            board.[j].[dim - 1 - j] <- 'O'
                        true
                    |_ -> false
            elif i = 0 then
                resolve 'o' 1
            else
                false
        |_ -> false


if resolve 'h' 0 then
    for i = 0 to dim - 1 do
        printfn "%s" (String board.[i])
else
    printfn "false"
