open System
open System.Text
#nowarn "25"

let rec gameLoop lightX lightY thorX thorY =
    stdin.ReadLine() |> ignore
    let dy = compare lightY thorY
    let dx = compare lightX thorX
    printfn "%s" (["N"; ""; "S"].[dy + 1] + ["W"; ""; "E"].[dx + 1])
    gameLoop lightX lightY (thorX + dx) (thorY + dy)

let (lightX, lightY, initialTX, initialTY) =
    stdin.ReadLine().Split ' ' |> Array.map int |> function
    | [| a; b; c; d |] -> (a, b, c, d)
    |_ -> failwith "invalid input"

gameLoop lightX lightY initialTX initialTY |> ignore
