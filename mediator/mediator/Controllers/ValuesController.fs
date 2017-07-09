namespace mediator.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http


[<Route("api/[controller]")>]
type ValuesController() =
    inherit Controller()
    
    // GET api/values
    [<HttpGet>]
    member this.Get() = [| "value1"; "value2" |]

    // GET api/values/5
    [<HttpGet("{id}")>]
    member this.Get(id:int) = "value"

    [<HttpPost("post-audio")>]
    member this.PostAudio([<FromBody>]file:IFormFile) =
      let fileSize = file.Length

      use stream = new FileStream("", FileMode.Create)

      let copyToLocationAsync = file.CopyToAsync stream

      this.Ok fileSize


    // POST api/values
    [<HttpPost>]
    member this.Post([<FromBody>]value:string) = ()

    // PUT api/values/5
    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>]value:string) = ()

    // DELETE api/values/5
    [<HttpDelete("{id}")>]
    member this.Delete(id:int) = ()
