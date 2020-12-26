open System
open System.Text
#nowarn "25"

let token = (stdin.ReadLine()).Split ' '
let W = int token.[0]
let H = int token.[1]

let topi =
    stdin.ReadLine()
    |> Seq.mapi (fun i v -> if v <> ' ' then Some(i, v) else None)
    |> Seq.choose id
    |> Seq.toList
let lineIndexes = topi |> List.toSeq |> Seq.map fst |> Seq.toList

let lineCount = Seq.length lineIndexes
let moveTable = Seq.init H (fun _ -> Array.zeroCreate<Char> lineCount) |> Seq.toArray
for h in 1 .. H - 2 do
    let line = stdin.ReadLine()
    for lineNumber in 0 .. lineCount - 1 do
        let originColumnNum = lineIndexes.[lineNumber]
        if lineNumber > 0 && line.[originColumnNum - 1] = '-' then
            moveTable.[h].[lineNumber] <- 'l'
        if lineNumber < lineCount - 1 && line.[originColumnNum + 1] = '-' then
            moveTable.[h].[lineNumber] <- 'r'

let bottom =
    stdin.ReadLine()
    |> Seq.mapi (fun i v -> (i, v))
    |> Seq.filter (fun (i, v) -> Seq.contains i lineIndexes)
    |> Seq.map snd
    |> Seq.toList

let rec down h w =
    if h >= H - 1 then bottom.[w]
    elif moveTable.[h].[w] = 'r' then
        down (h + 1) (w + 1)
    elif moveTable.[h].[w] = 'l' then
        down (h + 1) (w - 1)
    else
        down (h + 1) w

for n = 0 to lineCount - 1 do
    let T = topi.[n] |> snd
    let B = down 0 n
    printfn "%c%c" T B
