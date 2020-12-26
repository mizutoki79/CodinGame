open System
open System.Text
#nowarn "25"

let (lightX, lightY, initialTX, initialTY) =
    stdin.ReadLine().Split ' ' |> Array.map int |> function
    | [| a; b; c; d |] -> (a, b, c, d)
    |_ -> failwith "invalid input"

let mutable (thorX, thorY) = (initialTX, initialTY)

let rec gameLoop () =
    eprintfn "lignt %A" (lightX, lightY)
    eprintfn "thor %A" (thorX, thorY)
    stdin.ReadLine() |> ignore
    let mutable direction = String.Empty
    if lightY > thorY then
        direction <- "N"
        thorY <- thorY - 1
    elif lightY < thorY then
        direction <- "S"
        thorY <- thorY + 1
    if lightX > thorX then
        direction <- direction + "E"
        thorX <- thorX + 1
    elif lightX < thorX then
        direction <- direction + "W"
        thorX <- thorX - 1
    printfn "%s" direction
    gameLoop()

gameLoop() |> ignore
