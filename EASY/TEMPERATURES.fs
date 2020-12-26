ignore (stdin.ReadLine())
(stdin.ReadLine()).Split ' ' |> Array.filter ((<>)"") |> function
| a when (Array.length a) > 0 -> a |> Array.map int |> Seq.sortBy (fun x -> abs x, -x) |> Seq.head
|_ -> 0
|> stdout.WriteLine
