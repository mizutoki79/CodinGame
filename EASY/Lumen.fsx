open System

let N = stdin.ReadLine() |> int
let L = stdin.ReadLine() |> int
let placement = Seq.init N (fun _ -> stdin.ReadLine().Split ' ') |> Seq.toArray

let lightTable = Seq.init N (fun _ -> Array.zeroCreate<int> N) |> Seq.toArray

let rec lightUp i j l =
    if i < 0 || j < 0 || i >= N || j >= N then
        ()
    else
        lightTable.[i].[j] <- max lightTable.[i].[j]  l
        if l > 1 then
            lightUp (i - 1) j (l - 1)
            lightUp (i + 1) j (l - 1)
            lightUp (i - 1) (j - 1) (l - 1)
            lightUp (i + 1) (j - 1) (l - 1)
            lightUp (i - 1) (j + 1) (l - 1)
            lightUp (i + 1) (j + 1) (l - 1)
            lightUp i (j - 1) (l - 1)
            lightUp i (j + 1) (l - 1)
            lightUp (i - 1) (j - 1) (l - 1)
            lightUp (i - 1) (j + 1) (l - 1)
            lightUp (i + 1) (j - 1) (l - 1)
            lightUp (i + 1) (j + 1) (l - 1)

let printTable () =
    for i in 0 .. N - 1 do
       eprintfn "%A" lightTable.[i]


let rec check i j =
    let cell = placement.[i].[j]
    if cell = "C" then
        lightUp i j L
    if j < N - 1 then
        check i (j + 1)
    elif i < N - 1 then
        check (i + 1) 0

check 0 0
let mutable countDark = 0
for i in 0 .. N - 1 do
    for j in 0 .. N - 1 do
        if lightTable.[i].[j] = 0 then
            countDark <- countDark + 1
countDark |> printfn "%d"
