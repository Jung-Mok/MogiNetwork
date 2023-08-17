using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MogiNetwork
{
    public class Buffer
    {
        IMemoryOwner<byte> _buffer;

        public Buffer(int size)
        {
            MemoryPool<byte> memoryPool = MemoryPool<byte>.Shared;
            _buffer = memoryPool.Rent(size);
        }

        public byte[] GetBuffer()
        {
            if(_buffer == null)
            {
                return null;
            }
            return _buffer.Memory.ToArray();
        }
    }
}
