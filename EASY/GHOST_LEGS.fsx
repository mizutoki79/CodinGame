open System
#nowarn "25"

let token = (stdin.ReadLine()).Split ' '
let W = int token.[0]
let H = int token.[1]

let diagram = [for i in 0 .. H - 1 do stdin.ReadLine()]

let top = [
    for i in 0 .. W - 1 do
        if diagram.[0].[i] <> ' ' then
            (diagram.[0].[i], i)
        else ()
]

let bottom = [
    for i in 0 .. W - 1 do
        if diagram.[H - 1].[i] <> ' ' then
            (diagram.[H - 1].[i], i)
        else ()
]

let move = Seq.init H (fun _ -> Array.zeroCreate<Char> W) |> Array.ofSeq
for (T, c) in top do
    for i in 1 .. H - 2 do
        if c > 0 && diagram.[i].[c - 1] = '-' then
            move.[i].[c] <- 'l'
        if c < W - 1 && diagram.[i].[c + 1] = '-' then
            move.[i].[c] <- 'r'

let rec down i n =
    let j = top.[n] |> snd
    if i >= H - 1 then bottom.[n] |> fst
    elif move.[i].[j] = 'r' then
        down (i + 1) (n + 1)
    elif move.[i].[j] = 'l' then
        down (i + 1) (n - 1)
    else
        down (i + 1) n

let num = top |> List.length
let mutable result = Array.zeroCreate<String> num
for n = 0 to num - 1 do
    let (T, c) = top.[n]
    let B = down 0 n
    printfn "%c%c" T B
