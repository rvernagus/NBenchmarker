#r "lib/FAKE/FakeLib.dll"
open Fake
open MSTest
open System

// Properties
let buildDir = "build"
let testDir = "build/tests"
let programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
let fxCopRoot = programFiles + "/Microsoft Visual Studio 12.0/Team Tools/Static Analysis Tools/FxCop/FxCopCmd.exe"

// Targets
Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir])

Target "BuildApp" (fun _ ->
  let props =
    [
      "Optimize", "true"
      "DebugSymbols", "false"
      "Configuration", "Release"
    ]
  MSBuild buildDir "Build" props ["src/NBenchmarker/NBenchmarker/NBenchmarker.csproj"]
  |> Log "Built:")
//  let buildMode = getBuildParamOrDefault "buildMode" "Release"
//  let properties p =
//    { p with
//        Verbosity = Some(Quiet)
//        Targets = ["Build"]
//        Properties =
//        [
//          "Optimize", "True"
//          "DebugSymbols", "False"
//          "Configuration", buildMode
//          "OutputPath", buildDir
//        ]
//    }
//  build properties "src/NBenchmarker/NBenchmarker/NBenchmarker.csproj")
 
Target "BuildTest" (fun _ ->
  let buildMode = getBuildParamOrDefault "buildMode" "Debug"
  let properties p =
    { p with
        Verbosity = Some(Quiet)
        Targets = ["Build"]
        Properties =
        [
          "Optimize", "True"
          "DebugSymbols", "True"
          "Configuration", buildMode
        ]
    }
  build properties "src/NBenchmarker/NBenchmarker.Tests/NBenchmarker.Tests.csproj")

Target "Test" (fun _ ->
  !! (testDir + "/*.Tests.dll") 
  |> MSTest (fun p -> p))

Target "FxCop" (fun _ ->
  !! (buildDir + "/**/NBenchmarker.dll") 
  |> FxCop (fun p -> 
    {p with                     
      ReportFileName = testDir + "FXCopResults.xml"
      DirectOutputToConsole = true
      IncludeSummaryReport = true
      Verbose = false
      ToolPath = fxCopRoot }))

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
  ==> "FxCop"

// Run Targets
RunTargetOrDefault "FxCop"