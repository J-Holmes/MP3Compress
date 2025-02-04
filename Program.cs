using System;
using NAudio.Wave;
using NAudio.MediaFoundation;

namespace MP3CompressionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: MP3CompressionApp <input.mp3> <output.mp3> [bitrate]");
                return;
            }

            string inputFileName = args[0];
            string outputFileName = args[1];
            int bitrate = 128; // Default bitrate is 128 kbps

            if (args.Length >= 3 && !int.TryParse(args[2], out bitrate))
            {
                Console.WriteLine("Invalid bitrate argument. Using default bitrate (128 kbps).");
                bitrate = 128;
            }

            try
            {
                CompressMp3(inputFileName, outputFileName, bitrate);
                Console.WriteLine("MP3 compression complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void CompressMp3(string inputFileName, string outputFileName, int bitrate)
        {
            // Step 1: Read the input MP3 file using the MediaFoundationReader
            using (var reader = new MediaFoundationReader(inputFileName))
            {
                // Step 2: Compress the audio to MP3 format with the specified bitrate
                MediaFoundationEncoder.EncodeToMp3(reader, outputFileName, bitrate);
            }
        }
    }
}
