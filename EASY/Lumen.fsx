open System
let readInt = stdin.ReadLine>>int

let N, L = readInt(), readInt()
let candleIndexes =
    Seq.init N (fun h ->
        stdin.ReadLine()
        |> Seq.filter ((<>)' ')
        |> Seq.indexed
        |> Seq.filter (snd>>(=)'C')
        |> Seq.map (fun (w, _) -> (h, w)))
    |> Seq.concat
    |> Seq.toList

Seq.init (N * N) (fun n ->
    candleIndexes
    |> Seq.forall (fun (ci, cj) ->
        let (i, j) = (n / N, n % N) in L - max (abs(i - ci)) (abs(j - cj)) <= 0))
    |> Seq.filter id
    |> Seq.length
    |> printfn "%d"
