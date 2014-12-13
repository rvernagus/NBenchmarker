#r "lib/FAKE/FakeLib.dll"
open Fake
open MSTest

// Properties
let buildDir = "build"
let testDir = "build/tests"

// Targets
Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir])

Target "BuildApp" (fun _ ->
  !! "src/NBenchmarker/**/NBenchmarker.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: ")
 
Target "BuildTest" (fun _ ->
  !! "src/NBenchmarker/**/*.Tests.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "TestBuild-Output: ")

Target "Test" (fun _ ->
  !! (testDir + "/*.Tests.dll") 
  |> MSTest (fun p -> p))

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"

// start build
RunTargetOrDefault "Test"