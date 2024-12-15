# SolidImage

High Performance Image Formatting, Encoding, Compression and Drawing Library for .Net Core.

Still in development. The purpose of this libray, is to help my one industrial software, which need high performance
image processing.

List of standard formats will be supported:

- tiff
- png
- jpeg
- bmp
- gif
- ...

For tiff format, with this library, user can create their own tiff-based format with extensions.

...

## TODO LIST

- Compression Scheme Implementation
    - 2: CCITT Group 3 1D
    - 3: CCITT T.4
    - 4: CCITT T.6
    - 5: LZW
    - 6: JPEG
    - 32773: PackBits

## Development Notes

### Grouping Tags

- Basic

    - NewSubfileType

    - SubfileType

    - BitsPerSample

    - SamplesPerPixel

    - Photometric

    - Compression

    - ImageWidth

    - ImageLength

    - XResolution

    - YResolution

    - ResolutionUnit

    - ColorMap

    - ExtraSamples

- Data Storage Layout

    - FillOrder
    - PlanarConfiguration
    - StripOffsets

    - RowsPerStrip

    - StripByteCounts

    - TileWidth

    - TileLength

    - TileOffsets

    - TileByteCounts

- Metadata

    - ImageDescription

    - Make

    - Model

    - Software

    - DateTime

    - Artist

    - HostComputer

    - Copyright

- Document

    - DocumentName

    - PageName

    - PageNumber

    - XPosition

    - YPosition

- Uncommon

    - FreeOffsets

    - FreeByteCounts
    - MinSampleValue
    - MaxSampleValue
    - SampleFormat
    - SMinSampleValue
    - SMaxSampleValue

- Visiual / Printing Related

    - Orientation

    - Printing / Dithering / Halftone

        - InkSet
        - InkNames
        - NumberOfInks
        - DotRange
        - TargetPrinter
        - Threshholding

        - CellWidth

        - CellLength
        - HalftoneHints

    - Especially for Grayscale

        - GrayResponseUnit

        - GrayResponseCurve

    - RGB

        - WhitePoint
        - PrimaryChromaticities
        - TransferFunction
        - TransferRange
        - ReferenceBlackWhite

    - YCbCr

        - YCbCrCoefficients
        - YCbCrSubSampling
        - YCbCrPositioning

- Compression Related

    - CCITT
        - T4Options
        - T6Options
    - LZW
        - Predictor
    - JPEG
        - JPEGProc
        - JPEGInterchangeFormat
        - JPEGInterchangeFormatLngth
        - JPEGRestartInterval
        - JPEGLosslessPredictors
        - JPEGPointTransforms
        - JPEGQTables
        - JPEGDCTables
        - JPEGACTables











