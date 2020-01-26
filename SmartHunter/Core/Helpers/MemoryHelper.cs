using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SmartHunter.Core.Helpers
{    
    public static class MemoryHelper
    {
        static List<PointerTrace> s_UniquePointerTraces = new List<PointerTrace>();

        static WindowsApi.RegionPageProtection[] ProtectionExclusions
        {
            get
            {
                return new WindowsApi.RegionPageProtection[]
                {
                    WindowsApi.RegionPageProtection.PAGE_GUARD,
                    WindowsApi.RegionPageProtection.PAGE_NOACCESS
                };
            }
        }

        static bool CheckProtection(BytePattern pattern, uint flags)
        {
            var protectionFlags = (WindowsApi.RegionPageProtection)flags;

            foreach (var protectionExclusion in ProtectionExclusions)
            {
                if (protectionFlags.HasFlag(protectionExclusion))
                {
                    return false;
                }
            }

            return true; // we need to check only READ?
            /*
            foreach (var protectionOrInclusive in pattern.Config.PageProtections)
            {
                if (protectionFlags.HasFlag(protectionOrInclusive))
                {
                    return true;
                }
            }

            return false;
            */
        }

        public static List<ulong> FindPatternAddresses(Process process, AddressRange addressRange, BytePattern pattern, bool stopAfterFirst)
        {
            List<ulong> matchAddresses = new List<ulong>();

            ulong currentAddress = addressRange.Start;

            while (currentAddress < addressRange.End && !process.HasExited)
            {
                WindowsApi.MEMORY_BASIC_INFORMATION64 memoryRegion;
                if (WindowsApi.VirtualQueryEx(process.Handle, (IntPtr)currentAddress, out memoryRegion, (uint)Marshal.SizeOf(typeof(WindowsApi.MEMORY_BASIC_INFORMATION64))) > 0
                    && memoryRegion.RegionSize > 0
                    && memoryRegion.State == (uint)WindowsApi.RegionPageState.MEM_COMMIT
                    && CheckProtection(pattern, memoryRegion.Protect))
                {
                    var regionStartAddress = memoryRegion.BaseAddress;
                    if (addressRange.Start > regionStartAddress)
                    {
                        regionStartAddress = addressRange.Start;
                    }

                    var regionEndAddress = memoryRegion.BaseAddress + memoryRegion.RegionSize;
                    if (addressRange.End < regionEndAddress)
                    {
                        regionEndAddress = addressRange.End;
                    }

                    ulong regionBytesToRead = regionEndAddress - regionStartAddress;
                    byte[] regionBytes = new byte[regionBytesToRead];

                    if (process.HasExited)
                    {
                        break;
                    }

                    int lpNumberOfBytesRead = 0;
                    WindowsApi.ReadProcessMemory(process.Handle, (IntPtr)regionStartAddress, regionBytes, regionBytes.Length, ref lpNumberOfBytesRead);

                    var matchIndices = FindPatternMatchIndices(regionBytes, pattern, stopAfterFirst);

                    foreach (var matchIndex in matchIndices)
                    {
                        var matchAddress = regionStartAddress + (ulong)matchIndex;
                        matchAddresses.Add(matchAddress);

                        Log.WriteLine($"Found '{pattern.Config.Name}' at address 0x{matchAddress.ToString("X8")}"); //'{pattern.Config.String}'");

                        if (stopAfterFirst)
                        {
                            break;
                        }
                    }

                    /*
                    if (matchIndices.Any() && stopAfterFirst)
                    {
                        var matchAddress = regionStartAddress + (ulong)matchIndices.First();
                        matchAddresses.Add(matchAddress);

                        break;
                    }
                    else
                    {
                        foreach (var matchIndex in matchIndices)
                        {
                            var matchAddress = regionStartAddress + (ulong)matchIndex;
                            matchAddresses.Add(matchAddress);
                        }
                    }
                    */
                }

                if (matchAddresses.Any() && stopAfterFirst)
                {
                    break;
                }

                currentAddress = memoryRegion.BaseAddress + memoryRegion.RegionSize;
            }

            return matchAddresses;
        }

        // KMP algorithm modified to search bytes with a nullable/wildcard search
        static List<int> FindPatternMatchIndices(byte[] bytes, BytePattern pattern, bool stopAfterFirst)
        {
            List<int> matchedIndices = new List<int>();

            int textLength = bytes.Length;
            int patternLength = pattern.Bytes.Length;

            if (textLength == 0 || patternLength == 0 || textLength < patternLength)
            {
                return matchedIndices;
            }

            int[] longestPrefixSuffices = new int[patternLength];

            GetLongestPrefixSuffices(pattern, ref longestPrefixSuffices);

            int textIndex = 0;
            int patternIndex = 0;

            while (textIndex < textLength)
            {
                if (!pattern.Bytes[patternIndex].HasValue // Ignore compare if the pattern index is nullable - this treats it like a * wildcard
                    || bytes[textIndex] == pattern.Bytes[patternIndex])
                {
                    textIndex++;
                    patternIndex++;
                }

                if (patternIndex == patternLength)
                {
                    matchedIndices.Add(textIndex - patternIndex);
                    patternIndex = longestPrefixSuffices[patternIndex - 1];

                    if (stopAfterFirst)
                    {
                        break;
                    }
                }
                else if (textIndex < textLength
                    && (pattern.Bytes[patternIndex].HasValue // Only compare disparity if the pattern byte isn't a null wildcard
                    && bytes[textIndex] != pattern.Bytes[patternIndex]))
                {
                    if (patternIndex != 0)
                    {
                        patternIndex = longestPrefixSuffices[patternIndex - 1];
                    }
                    else
                    {
                        textIndex++;
                    }
                }
            }

            return matchedIndices;
        }

        static void GetLongestPrefixSuffices(BytePattern pattern, ref int[] longestPrefixSuffices)
        {
            int patternLength = pattern.Bytes.Length;
            int length = 0;
            int patternIndex = 1;

            longestPrefixSuffices[0] = 0;

            while (patternIndex < patternLength)
            {
                if (pattern.Bytes[patternIndex] == pattern.Bytes[length])
                {
                    length++;
                    longestPrefixSuffices[patternIndex] = length;
                    patternIndex++;
                }
                else
                {
                    if (length == 0)
                    {
                        longestPrefixSuffices[patternIndex] = 0;
                        patternIndex++;
                    }
                    else
                    {
                        length = longestPrefixSuffices[length - 1];
                    }
                }
            }
        }

        public static List<AddressRange> DivideAddressRange(AddressRange addressRange, int divisionCount)
        {
            List<AddressRange> addressRangeDivisions = new List<AddressRange>();

            ulong start = addressRange.Start;
            ulong end = addressRange.End;

            ulong range = end - start;
            float rangePerDivision = range / (float)divisionCount;

            end = start + (ulong)Math.Ceiling(rangePerDivision);
            for (int index = 0; index < divisionCount; ++index)
            {
                ulong startAddress = start;
                ulong endAddress = end;

                if (index + 1 == divisionCount)
                {
                    endAddress = addressRange.End;
                }

                addressRangeDivisions.Add(new AddressRange(startAddress, endAddress));

                start = end;
                end += (ulong)Math.Floor(rangePerDivision);
            }

            return addressRangeDivisions;
        }

        public static T Read<T>(Process process, ulong address) where T : struct
        {
            byte[] bytes = new byte[Marshal.SizeOf(typeof(T))];

            int lpNumberOfBytesRead = 0;
            WindowsApi.ReadProcessMemory(process.Handle, (IntPtr)address, bytes, bytes.Length, ref lpNumberOfBytesRead);

            T result;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

            try
            {
                result = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }

            return result;
        }

        public static string ReadString(Process process, ulong address, uint length)
        {
            byte[] bytes = new byte[length];

            int lpNumberOfBytesRead = 0;
            WindowsApi.ReadProcessMemory(process.Handle, (IntPtr)address, bytes, bytes.Length, ref lpNumberOfBytesRead);

            int nullTerminatorIndex = Array.FindIndex(bytes, (byte b) => b == 0);
            if (nullTerminatorIndex >= 0)
            {
                Array.Resize(ref bytes, nullTerminatorIndex);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }

            return null;
        }

        public static ulong ReadMultiLevelPointer(bool traceUniquePointers, Process process, ulong address, params long[] offsets)
        {
            PointerTrace trace = new PointerTrace();

            ulong result = address;
            foreach (var offset in offsets)
            {
                var readResult = Read<ulong>(process, address);
                result = (ulong)((long)readResult + offset);

                trace.Levels.Add(new PointerTraceLevel(address, readResult, offset, result));

                address = result;
            }

            if (traceUniquePointers && !s_UniquePointerTraces.Contains(trace))
            {
                s_UniquePointerTraces.Add(trace);
                Log.WriteLine($"Unique Pointer Trace:\r\n{trace}");
            }

            return result;
        }

        public static ulong LoadEffectiveAddressRelative(Process process, ulong address)
        {
            const uint opcodeLength = 3;
            const uint paramLength = 4;
            const uint instructionLength = opcodeLength + paramLength;

            uint operand = Read<uint>(process, address + opcodeLength);
            ulong operand64 = operand;

            // 64 bit relative addressing 
            if (operand64 > Int32.MaxValue)
            {
                operand64 = 0xffffffff00000000 | operand64;
            }

            return address + operand64 + instructionLength;
        }

        public static uint ReadStaticOffset(Process process, ulong address)
        {
            const uint opcodeLength = 3;
            return Read<uint>(process, address + opcodeLength);
        }
    }
}