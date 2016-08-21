module SignalGenerator

let generateSamples milliseconds frequency =
    let sampleRate = 44100.
    let sixteenBitSampleLimit = 32767.
    let volume = 0.8
    let ToAmplitude x vol = 
        x
        |> (*) (2. * System.Math.PI * frequency/sampleRate)
        |> sin
        |> (*) sixteenBitSampleLimit
        |> (*) vol
        |> int16

    let numOfSamples = (milliseconds / 1000.) * sampleRate
    let requiredSamples = seq { 1.0..numOfSamples }


    Seq.map ToAmplitude requiredSamples