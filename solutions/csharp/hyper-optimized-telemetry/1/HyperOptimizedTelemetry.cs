using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte prefix;
        byte[] payload;

        if (reading > uint.MaxValue)
        {
            prefix = 248;
            payload = BitConverter.GetBytes(reading);
        }
        else if (reading < int.MinValue)
        {
            prefix = 256 - 8;
            payload = BitConverter.GetBytes(reading);
        }
        else if (reading > int.MaxValue)
        {
            prefix = 4;
            payload = BitConverter.GetBytes((uint)reading);
        }
        else if (reading > ushort.MaxValue)
        {
            prefix = 256 - 4;
            payload = BitConverter.GetBytes((int)reading);
        }
        else if (reading >= 0)
        {
            prefix = 2;
            payload = BitConverter.GetBytes((ushort)reading);
        }
        else if (reading >= short.MinValue)
        {
            prefix = 256 - 2;
            payload = BitConverter.GetBytes((short)reading);
        }
        else
        {
            prefix = 256 - 4;
            payload = BitConverter.GetBytes((int)reading);
        }

        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch (buffer[0])
        {
            case 8:
                return BitConverter.ToInt64(buffer, 1);
            case 256 - 8:
                return BitConverter.ToInt64(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 256 - 4:
                return BitConverter.ToInt32(buffer, 1);
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 256 - 2:
                return BitConverter.ToInt16(buffer, 1);
            default:
                return 0;
        }
    }
}