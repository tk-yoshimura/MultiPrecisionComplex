# MultiPrecisionComplex
 MultiPrecision Complex and Quaternion Implements 

## Requirement
.NET 8.0  
AVX2 suppoted CPU. (Intel:Haswell(2013)-, AMD:Excavator(2015)-)  
[MultiPrecision](https://github.com/tk-yoshimura/MultiPrecision)

## Install

[Download DLL](https://github.com/tk-yoshimura/MultiPrecisionComplex/releases)  
[Download Nuget](https://www.nuget.org/packages/tyoshimura.MultiPrecision.complex/)  

## Usage

```csharp
Complex<Pow2.N8> z = "1+16i"; // z = (1, 16), new Complex<Pow2.N8>(1, 16);
Complex<Pow2.N8> c = z * z;

Console.WriteLine(c);
```

## Licence
[MIT](https://github.com/tk-yoshimura/MultiPrecisionComplex/blob/main/LICENSE)

## Author

[T.Yoshimura](https://github.com/tk-yoshimura)
