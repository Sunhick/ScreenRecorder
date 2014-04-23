#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : Avi.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion
#region Using directives
using System;
using System.Runtime.InteropServices;
#endregion

namespace ScreenRecorder.Codecs
{
    /// <summary>
    /// Avi
    /// </summary>
    public class Avi
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RGBQUAD
        {
            /// <summary>
            /// Rgb blue
            /// </summary>
            public byte rgbBlue;
            /// <summary>
            /// Rgb green
            /// </summary>
            public byte rgbGreen;
            /// <summary>
            /// Rgb red
            /// </summary>
            public byte rgbRed;
            /// <summary>
            /// Rgb reserved
            /// </summary>
            public byte rgbReserved;
        } // struct RGBQUAD

        /// <summary>
        /// RGB QUAD_SIZE
        /// </summary>
        public static int RGBQUAD_SIZE = 4;
        /// <summary>
        /// PAL ETTE_SIZE
        /// </summary>
        public static int PALETTE_SIZE = 4 * 256; //RGBQUAD * 256 colours

        /// <summary>
        /// Streamtype VIDEO
        /// </summary>
        public static readonly int streamtypeVIDEO = mmioFOURCC('v', 'i', 'd', 's');
        /// <summary>
        /// Streamtype AUDIO
        /// </summary>
        public static readonly int streamtypeAUDIO = mmioFOURCC('a', 'u', 'd', 's');
        /// <summary>
        /// Streamtype MIDI
        /// </summary>
        public static readonly int streamtypeMIDI = mmioFOURCC('m', 'i', 'd', 's');
        /// <summary>
        /// Streamtype TEXT
        /// </summary>
        public static readonly int streamtypeTEXT = mmioFOURCC('t', 'x', 't', 's');

        public const int OF_SHARE_DENY_WRITE = 32;
        public const int OF_WRITE = 1;
        public const int OF_READWRITE = 2;
        public const int OF_CREATE = 4096;

        public const int BMP_MAGIC_COOKIE = 19778; //ascii string "BM"

        public const int AVICOMPRESSF_INTERLEAVE = 0x00000001;    // interleave
        public const int AVICOMPRESSF_DATARATE = 0x00000002;    // use a data rate
        public const int AVICOMPRESSF_KEYFRAMES = 0x00000004;    // use keyframes
        public const int AVICOMPRESSF_VALID = 0x00000008;    // has valid data
        public const int AVIIF_KEYFRAME = 0x00000010;

        public const UInt32 ICMF_CHOOSE_KEYFRAME = 0x0001;	// show KeyFrame Every box
        public const UInt32 ICMF_CHOOSE_DATARATE = 0x0002;	// show DataRate box
        public const UInt32 ICMF_CHOOSE_PREVIEW = 0x0004;	// allow expanded preview dialog

        //macro mmioFOURCC
        /// <summary>
        /// Mmio FOURCC
        /// </summary>
        /// <param name="ch0">Character 0</param>
        /// <param name="ch1">Character 1</param>
        /// <param name="ch2">Character 2</param>
        /// <param name="ch3">Character 3</param>
        public static Int32 mmioFOURCC(char ch0, char ch1, char ch2, char ch3)
        {
            return ((Int32)(byte)(ch0) | ((byte)(ch1) << 8) |
                ((byte)(ch2) << 16) | ((byte)(ch3) << 24));
        }

        #region structure declarations

        /// <summary>
        /// REC t
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RECT
        {
            /// <summary>
            /// Left
            /// </summary>
            public UInt32 left;
            /// <summary>
            /// Top
            /// </summary>
            public UInt32 top;
            /// <summary>
            /// Right
            /// </summary>
            public UInt32 right;
            /// <summary>
            /// Bottom
            /// </summary>
            public UInt32 bottom;
        } // struct RECT

        /// <summary>
        /// BIT MAPINFOHEADER
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BITMAPINFOHEADER
        {
            /// <summary>
            /// Bi size
            /// </summary>
            public Int32 biSize;
            /// <summary>
            /// Bi width
            /// </summary>
            public Int32 biWidth;
            /// <summary>
            /// Bi height
            /// </summary>
            public Int32 biHeight;
            /// <summary>
            /// Bi planes
            /// </summary>
            public Int16 biPlanes;
            /// <summary>
            /// Bi bit count
            /// </summary>
            public Int16 biBitCount;
            /// <summary>
            /// Bi compression
            /// </summary>
            public Int32 biCompression;
            /// <summary>
            /// Bi size image
            /// </summary>
            public Int32 biSizeImage;
            /// <summary>
            /// Bi x pels per meter
            /// </summary>
            public Int32 biXPelsPerMeter;
            /// <summary>
            /// Bi y pels per meter
            /// </summary>
            public Int32 biYPelsPerMeter;
            /// <summary>
            /// Bi clr used
            /// </summary>
            public Int32 biClrUsed;
            /// <summary>
            /// Bi clr important
            /// </summary>
            public Int32 biClrImportant;
        } // struct BITMAPINFOHEADER

        /// <summary>
        /// BIT MAPINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BITMAPINFO
        {
            /// <summary>
            /// Bmi header
            /// </summary>
            /// <param name="MarshalAs">Marshal as</param>
            public BITMAPINFOHEADER bmiHeader;
            /// <summary>
            /// Bmi colors
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public RGBQUAD[] bmiColors;
        } // struct BITMAPINFO

        /// <summary>
        /// PCM WAVEFORMAT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PCMWAVEFORMAT
        {
            /// <summary>
            /// W format tag
            /// </summary>
            public short wFormatTag;
            /// <summary>
            /// N channels
            /// </summary>
            public short nChannels;
            /// <summary>
            /// N samples per sec
            /// </summary>
            public int nSamplesPerSec;
            /// <summary>
            /// N avg bytes per sec
            /// </summary>
            public int nAvgBytesPerSec;
            /// <summary>
            /// N block align
            /// </summary>
            public short nBlockAlign;
            /// <summary>
            /// W bits per sample
            /// </summary>
            public short wBitsPerSample;
            /// <summary>
            /// Collection base size
            /// </summary>
            public short cbSize;
        } // struct PCMWAVEFORMAT

        /// <summary>
        /// AVI STREAMINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AVISTREAMINFO
        {
            /// <summary>
            /// Fcc type
            /// </summary>
            public Int32 fccType;
            /// <summary>
            /// Fcc handler
            /// </summary>
            public Int32 fccHandler;
            /// <summary>
            /// Dw flags
            /// </summary>
            public Int32 dwFlags;
            /// <summary>
            /// Dw caps
            /// </summary>
            public Int32 dwCaps;
            /// <summary>
            /// W priority
            /// </summary>
            public Int16 wPriority;
            /// <summary>
            /// W language
            /// </summary>
            public Int16 wLanguage;
            /// <summary>
            /// Dw scale
            /// </summary>
            public Int32 dwScale;
            /// <summary>
            /// Dw rate
            /// </summary>
            public Int32 dwRate;
            /// <summary>
            /// Dw start
            /// </summary>
            public Int32 dwStart;
            /// <summary>
            /// Dw length
            /// </summary>
            public Int32 dwLength;
            /// <summary>
            /// Dw initial frames
            /// </summary>
            public Int32 dwInitialFrames;
            /// <summary>
            /// Dw suggested buffer size
            /// </summary>
            public Int32 dwSuggestedBufferSize;
            /// <summary>
            /// Dw quality
            /// </summary>
            public Int32 dwQuality;
            /// <summary>
            /// Dw sample size
            /// </summary>
            public Int32 dwSampleSize;
            /// <summary>
            /// Rc frame
            /// </summary>
            public RECT rcFrame;
            /// <summary>
            /// Dw edit count
            /// </summary>
            public Int32 dwEditCount;
            /// <summary>
            /// Dw format change count
            /// </summary>
            /// <param name="MarshalAs">Marshal as</param>
            public Int32 dwFormatChangeCount;
            /// <summary>
            /// Sz name
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public UInt16[] szName;
        } // struct AVISTREAMINFO
        /// <summary>
        /// BIT MAPFILEHEADER
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BITMAPFILEHEADER
        {
            /// <summary>
            /// Bf type
            /// </summary>
            public Int16 bfType; //"magic cookie" - must be "BM"
            public Int32 bfSize;
            /// <summary>
            /// Bf reserved 1
            /// </summary>
            public Int16 bfReserved1;
            /// <summary>
            /// Bf reserved 2
            /// </summary>
            public Int16 bfReserved2;
            /// <summary>
            /// Bf off bits
            /// </summary>
            public Int32 bfOffBits;
        } // struct BITMAPFILEHEADER


        /// <summary>
        /// AVI FILEINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AVIFILEINFO
        {
            /// <summary>
            /// Dw maximum bytes per second
            /// </summary>
            public Int32 dwMaxBytesPerSecond;
            /// <summary>
            /// Dw flags
            /// </summary>
            public Int32 dwFlags;
            /// <summary>
            /// Dw caps
            /// </summary>
            public Int32 dwCaps;
            /// <summary>
            /// Dw streams
            /// </summary>
            public Int32 dwStreams;
            /// <summary>
            /// Dw suggested buffer size
            /// </summary>
            public Int32 dwSuggestedBufferSize;
            /// <summary>
            /// Dw width
            /// </summary>
            public Int32 dwWidth;
            /// <summary>
            /// Dw height
            /// </summary>
            public Int32 dwHeight;
            /// <summary>
            /// Dw scale
            /// </summary>
            public Int32 dwScale;
            /// <summary>
            /// Dw rate
            /// </summary>
            public Int32 dwRate;
            /// <summary>
            /// Dw length
            /// </summary>
            public Int32 dwLength;
            /// <summary>
            /// Dw edit count
            /// </summary>
            /// <param name="MarshalAs">Marshal as</param>
            public Int32 dwEditCount;
            /// <summary>
            /// Sz file type
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public char[] szFileType;
        } // struct AVIFILEINFO

        /// <summary>
        /// AVI COMPRESSOPTIONS
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AVICOMPRESSOPTIONS
        {
            /// <summary>
            /// Fcc type
            /// </summary>
            public UInt32 fccType;
            /// <summary>
            /// Fcc handler
            /// </summary>
            public UInt32 fccHandler;
            /// <summary>
            /// Dw key frame every
            /// </summary>
            public UInt32 dwKeyFrameEvery;  // only used with AVICOMRPESSF_KEYFRAMES
            public UInt32 dwQuality;
            /// <summary>
            /// Dw bytes per second
            /// </summary>
            public UInt32 dwBytesPerSecond; // only used with AVICOMPRESSF_DATARATE
            public UInt32 dwFlags;
            /// <summary>
            /// Lp format
            /// </summary>
            public IntPtr lpFormat;
            /// <summary>
            /// Collection base format
            /// </summary>
            public UInt32 cbFormat;
            /// <summary>
            /// Lp parms
            /// </summary>
            public IntPtr lpParms;
            /// <summary>
            /// Collection base parms
            /// </summary>
            public UInt32 cbParms;
            /// <summary>
            /// Dw interleave every
            /// </summary>
            public UInt32 dwInterleaveEvery;
        } // struct AVICOMPRESSOPTIONS

        /// <summary>AviSaveV needs a pointer to a pointer to an AVICOMPRESSOPTIONS structure</summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class AVICOMPRESSOPTIONS_CLASS
        {
            /// <summary>
            /// Fcc type
            /// </summary>
            public UInt32 fccType;
            /// <summary>
            /// Fcc handler
            /// </summary>
            public UInt32 fccHandler;
            /// <summary>
            /// Dw key frame every
            /// </summary>
            public UInt32 dwKeyFrameEvery;  // only used with AVICOMRPESSF_KEYFRAMES
            /// <summary>
            /// Dw quality
            /// </summary>
            public UInt32 dwQuality;
            /// <summary>
            /// Dw bytes per second
            /// </summary>
            public UInt32 dwBytesPerSecond; // only used with AVICOMPRESSF_DATARATE
            /// <summary>
            /// Dw flags
            /// </summary>
            public UInt32 dwFlags;
            /// <summary>
            /// Lp format
            /// </summary>
            public IntPtr lpFormat;
            /// <summary>
            /// Collection base format
            /// </summary>
            public UInt32 cbFormat;
            /// <summary>
            /// Lp parms
            /// </summary>
            public IntPtr lpParms;
            /// <summary>
            /// Collection base parms
            /// </summary>
            public UInt32 cbParms;
            /// <summary>
            /// Dw interleave every
            /// </summary>
            public UInt32 dwInterleaveEvery;

            /// <summary>
            /// To struct
            /// </summary>
            public AVICOMPRESSOPTIONS ToStruct()
            {
                AVICOMPRESSOPTIONS returnVar = new AVICOMPRESSOPTIONS();
                returnVar.fccType = this.fccType;
                returnVar.fccHandler = this.fccHandler;
                returnVar.dwKeyFrameEvery = this.dwKeyFrameEvery;
                /// <summary>
                /// Dw quality
                /// </summary>
                returnVar.dwQuality = this.dwQuality;
                returnVar.dwBytesPerSecond = this.dwBytesPerSecond;
                /// <summary>
                /// Dw flags
                /// </summary>
                returnVar.dwFlags = this.dwFlags;
                returnVar.lpFormat = this.lpFormat;
                returnVar.cbFormat = this.cbFormat;
                returnVar.lpParms = this.lpParms;
                returnVar.cbParms = this.cbParms;
                returnVar.dwInterleaveEvery = this.dwInterleaveEvery;
                return returnVar;
            }
        } // class AVICOMPRESSOPTIONS_CLASS
        #endregion structure declarations

        #region method declarations

        //Initialize the AVI library
        /// <summary>
        /// AVI file init
        /// </summary>
        [DllImport("avifil32.dll")]
        public static extern void AVIFileInit();

        //Open an AVI file
        /// <summary>
        /// AVI file open
        /// </summary>
        /// <param name="ppfile">Ppfile</param>
        /// <param name="szFile">Sz file</param>
        /// <param name="uMode">U texture coordinate mode</param>
        /// <param name="pclsidHandler">Pclsid handler</param>
        [DllImport("avifil32.dll", PreserveSig = true)]
        public static extern int AVIFileOpen(
            ref int ppfile,
            String szFile,
            int uMode,
            int pclsidHandler);

        //Get a stream from an open AVI file
        /// <summary>
        /// AVI file get stream
        /// </summary>
        /// <param name="pfile">Pfile</param>
        /// <param name="ppavi">Ppavi</param>
        /// <param name="fccType">Fcc type</param>
        /// <param name="lParam">L param</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIFileGetStream(
            int pfile,
            out IntPtr ppavi,
            int fccType,
            int lParam);

        //Get the start position of a stream
        /// <summary>
        /// AVI stream start
        /// </summary>
        /// <param name="pavi">Pavi</param>
        [DllImport("avifil32.dll", PreserveSig = true)]
        public static extern int AVIStreamStart(int pavi);

        //Get the length of a stream in frames
        /// <summary>
        /// AVI stream length
        /// </summary>
        /// <param name="pavi">Pavi</param>
        [DllImport("avifil32.dll", PreserveSig = true)]
        public static extern int AVIStreamLength(int pavi);

        //Get information about an open stream
        /// <summary>
        /// AVI stream info
        /// </summary>
        /// <param name="pAVIStream">P AVI stream</param>
        /// <param name="psi">Psi</param>
        /// <param name="lSize">L size</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamInfo(
            IntPtr pAVIStream,
            ref AVISTREAMINFO psi,
            int lSize);

        //Get a pointer to a GETFRAME object (returns 0 on error)
        /// <summary>
        /// AVI stream get frame open
        /// </summary>
        /// <param name="pAVIStream">P AVI stream</param>
        /// <param name="bih">Bih</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamGetFrameOpen(
            IntPtr pAVIStream,
            ref BITMAPINFOHEADER bih);

        //Get a pointer to a packed DIB (returns 0 on error)
        /// <summary>
        /// AVI stream get frame
        /// </summary>
        /// <param name="pGetFrameObj">P get frame object</param>
        /// <param name="lPos">L position</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamGetFrame(
            int pGetFrameObj,
            int lPos);

        //Create a new stream in an open AVI file
        /// <summary>
        /// AVI file create stream
        /// </summary>
        /// <param name="pfile">Pfile</param>
        /// <param name="ppavi">Ppavi</param>
        /// <param name="ptr_streaminfo">Ptr _streaminfo</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIFileCreateStream(
            int pfile,
            out IntPtr ppavi,
            ref AVISTREAMINFO ptr_streaminfo);

        //Create an editable stream
        /// <summary>
        /// Create editable stream
        /// </summary>
        /// <param name="ppsEditable">Pps editable</param>
        /// <param name="psSource">Ps source</param>
        [DllImport("avifil32.dll")]
        public static extern int CreateEditableStream(
            ref IntPtr ppsEditable,
            IntPtr psSource
        );

        //Cut samples from an editable stream
        /// <summary>
        /// Edit stream cut
        /// </summary>
        /// <param name="pStream">P stream</param>
        /// <param name="plStart">Pl start</param>
        /// <param name="plLength">Pl length</param>
        /// <param name="ppResult">Pp result</param>
        [DllImport("avifil32.dll")]
        public static extern int EditStreamCut(
            IntPtr pStream,
            ref Int32 plStart,
            ref Int32 plLength,
            ref IntPtr ppResult
        );

        //Copy a part of an editable stream
        /// <summary>
        /// Edit stream copy
        /// </summary>
        /// <param name="pStream">P stream</param>
        /// <param name="plStart">Pl start</param>
        /// <param name="plLength">Pl length</param>
        /// <param name="ppResult">Pp result</param>
        [DllImport("avifil32.dll")]
        public static extern int EditStreamCopy(
            IntPtr pStream,
            ref Int32 plStart,
            ref Int32 plLength,
            ref IntPtr ppResult
        );

        //Paste an editable stream into another editable stream
        /// <summary>
        /// Edit stream paste
        /// </summary>
        /// <param name="pStream">P stream</param>
        /// <param name="plPos">Pl position</param>
        /// <param name="plLength">Pl length</param>
        /// <param name="pstream">Pstream</param>
        /// <param name="lStart">L start</param>
        /// <param name="lLength">L length</param>
        [DllImport("avifil32.dll")]
        public static extern int EditStreamPaste(
            IntPtr pStream,
            ref Int32 plPos,
            ref Int32 plLength,
            IntPtr pstream,
            Int32 lStart,
            Int32 lLength
        );

        //Change a stream's header values
        /// <summary>
        /// Edit stream set info
        /// </summary>
        /// <param name="pStream">P stream</param>
        /// <param name="lpInfo">Lp info</param>
        /// <param name="cbInfo">Collection base info</param>
        [DllImport("avifil32.dll")]
        public static extern int EditStreamSetInfo(
            IntPtr pStream,
            ref AVISTREAMINFO lpInfo,
            Int32 cbInfo
        );

        /// <summary>
        /// AVI make file from streams
        /// </summary>
        /// <param name="ppfile">Ppfile</param>
        /// <param name="nStreams">N streams</param>
        /// <param name="papStreams">Pap streams</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIMakeFileFromStreams(
            ref IntPtr ppfile,
            int nStreams,
            ref IntPtr papStreams
        );

        //Set the format for a new stream
        /// <summary>
        /// AVI stream set format
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lPos">L position</param>
        /// <param name="ref BITMAPINFOHEADER lpFormat,">Ref B ITMAPINFOHEADER lp format,</param>
        /// <param name="lpFormat">Lp format</param>
        /// <param name="cbFormat">Collection base format</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamSetFormat(
            IntPtr aviStream, Int32 lPos,
            //ref BITMAPINFOHEADER lpFormat,
            ref BITMAPINFO lpFormat,
            Int32 cbFormat);

        //Set the format for a new stream
        /// <summary>
        /// AVI stream set format
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lPos">L position</param>
        /// <param name="lpFormat">Lp format</param>
        /// <param name="cbFormat">Collection base format</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamSetFormat(
            IntPtr aviStream, Int32 lPos,
            ref PCMWAVEFORMAT lpFormat, Int32 cbFormat);

        //Read the format for a stream
        /// <summary>
        /// AVI stream read format
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lPos">L position</param>
        /// <param name="lpFormat">Lp format</param>
        /// <param name="cbFormat">Collection base format</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamReadFormat(
            IntPtr aviStream, Int32 lPos,
            ref BITMAPINFO lpFormat, ref Int32 cbFormat
            );

        //Read the size of the format for a stream
        /// <summary>
        /// AVI stream read format
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lPos">L position</param>
        /// <param name="empty">Empty</param>
        /// <param name="cbFormat">Collection base format</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamReadFormat(
            IntPtr aviStream, Int32 lPos,
            int empty, ref Int32 cbFormat
            );

        //Read the format for a stream
        /// <summary>
        /// AVI stream read format
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lPos">L position</param>
        /// <param name="lpFormat">Lp format</param>
        /// <param name="cbFormat">Collection base format</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamReadFormat(
            IntPtr aviStream, Int32 lPos,
            ref PCMWAVEFORMAT lpFormat, ref Int32 cbFormat
            );

        //Write a sample to a stream
        /// <summary>
        /// AVI stream write
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="lStart">L start</param>
        /// <param name="lSamples">L samples</param>
        /// <param name="lpBuffer">Lp buffer</param>
        /// <param name="cbBuffer">Collection base buffer</param>
        /// <param name="dwFlags">Dw flags</param>
        /// <param name="dummy1">Dummy 1</param>
        /// <param name="dummy2">Dummy 2</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamWrite(
            IntPtr aviStream, Int32 lStart, Int32 lSamples,
            IntPtr lpBuffer, Int32 cbBuffer, Int32 dwFlags,
            Int32 dummy1, Int32 dummy2);

        //Release the GETFRAME object
        /// <summary>
        /// AVI stream get frame close
        /// </summary>
        /// <param name="pGetFrameObj">P get frame object</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamGetFrameClose(
            int pGetFrameObj);

        //Release an open AVI stream
        /// <summary>
        /// AVI stream release
        /// </summary>
        /// <param name="aviStream">Avi stream</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamRelease(IntPtr aviStream);

        //Release an open AVI file
        /// <summary>
        /// AVI file release
        /// </summary>
        /// <param name="pfile">Pfile</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIFileRelease(int pfile);

        //Close the AVI library
        /// <summary>
        /// AVI file exit
        /// </summary>
        [DllImport("avifil32.dll")]
        public static extern void AVIFileExit();

        /// <summary>
        /// AVI make compressed stream
        /// </summary>
        /// <param name="ppsCompressed">Pps compressed</param>
        /// <param name="aviStream">Avi stream</param>
        /// <param name="ao">Ao</param>
        /// <param name="dummy">Dummy</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIMakeCompressedStream(
            out IntPtr ppsCompressed, IntPtr aviStream,
            ref AVICOMPRESSOPTIONS ao, int dummy);

        /// <summary>
        /// AVI save options
        /// </summary>
        /// <param name="hwnd">Hwnd</param>
        /// <param name="uiFlags">User interface flags</param>
        /// <param name="nStreams">N streams</param>
        /// <param name="ppavi">Ppavi</param>
        /// <param name="plpOptions">Plp options</param>
        [DllImport("avifil32.dll")]
        public static extern bool AVISaveOptions(
            IntPtr hwnd,
            UInt32 uiFlags,
            Int32 nStreams,
            ref IntPtr ppavi,
            ref AVICOMPRESSOPTIONS_CLASS plpOptions
            );

        /// <summary>
        /// AVI save options free
        /// </summary>
        /// <param name="nStreams">N streams</param>
        /// <param name="plpOptions">Plp options</param>
        [DllImport("avifil32.dll")]
        public static extern long AVISaveOptionsFree(
            int nStreams,
            ref AVICOMPRESSOPTIONS_CLASS plpOptions
            );

        /// <summary>
        /// AVI file info
        /// </summary>
        /// <param name="pfile">Pfile</param>
        /// <param name="pfi">Pfi</param>
        /// <param name="lSize">L size</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIFileInfo(
            int pfile,
            ref AVIFILEINFO pfi,
            int lSize);

        /// <summary>
        /// Mmio string to FOURCC
        /// </summary>
        /// <param name="sz">Sz</param>
        /// <param name="uFlags">U texture coordinate flags</param>
        [DllImport("winmm.dll", EntryPoint = "mmioStringToFOURCCA")]
        public static extern int mmioStringToFOURCC(String sz, int uFlags);

        /// <summary>
        /// AVI stream read
        /// </summary>
        /// <param name="pavi">Pavi</param>
        /// <param name="lStart">L start</param>
        /// <param name="lSamples">L samples</param>
        /// <param name="lpBuffer">Lp buffer</param>
        /// <param name="cbBuffer">Collection base buffer</param>
        /// <param name="plBytes">Pl bytes</param>
        /// <param name="plSamples">Pl samples</param>
        [DllImport("avifil32.dll")]
        public static extern int AVIStreamRead(
            IntPtr pavi,
            Int32 lStart,
            Int32 lSamples,
            IntPtr lpBuffer,
            Int32 cbBuffer,
            Int32 plBytes,
            Int32 plSamples
            );

        /// <summary>
        /// AVI sav texture coordinatee v texture coordinate
        /// </summary>
        /// <param name="szFile">Sz file</param>
        /// <param name="empty">Empty</param>
        /// <param name="lpfnCallback">Lpfn callback</param>
        /// <param name="nStreams">N streams</param>
        /// <param name="ppavi">Ppavi</param>
        /// <param name="plpOptions">Plp options</param>
        [DllImport("avifil32.dll")]
        public static extern int AVISaveV(
            String szFile,
            Int16 empty,
            Int16 lpfnCallback,
            Int16 nStreams,
            ref IntPtr ppavi,
            ref AVICOMPRESSOPTIONS_CLASS plpOptions
            );

        #endregion method declarations

    } // class Avi
} // namespace AviFile
