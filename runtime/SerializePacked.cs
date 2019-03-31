// Copyright (c) 2013-2014 Sandstorm Development Group, Inc. and contributors
// Licensed under the MIT License:
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Capnproto
{
	public static class SerializePacked
	{
		/// <exception cref="System.IO.IOException"/>
		public static Capnproto.MessageReader Read(Capnproto.BufferedInputStream input)
		{
			return Read(input, Capnproto.ReaderOptions.DEFAULT_READER_OPTIONS);
		}
		
		/// <exception cref="System.IO.IOException"/>
		public static Capnproto.MessageReader Read(Capnproto.BufferedInputStream input, Capnproto.ReaderOptions options)
		{
			Capnproto.PackedInputStream packedInput = new Capnproto.PackedInputStream(input);
			return Capnproto.Serialize.Read(packedInput, options);
		}
		
		/// <exception cref="System.IO.IOException"/>
		public static Capnproto.MessageReader ReadFromUnbuffered(java.nio.channels.ReadableByteChannel input)
		{
			return ReadFromUnbuffered(input, Capnproto.ReaderOptions.DEFAULT_READER_OPTIONS);
		}
		
		/// <exception cref="System.IO.IOException"/>
		public static Capnproto.MessageReader ReadFromUnbuffered(java.nio.channels.ReadableByteChannel input, Capnproto.ReaderOptions options)
		{
			Capnproto.PackedInputStream packedInput = new Capnproto.PackedInputStream(new Capnproto.BufferedInputStreamWrapper(input));
			return Capnproto.Serialize.Read(packedInput, options);
		}
		
		/// <exception cref="System.IO.IOException"/>
		public static void Write(Capnproto.BufferedOutputStream output, Capnproto.MessageBuilder message)
		{
			Capnproto.PackedOutputStream packedOutputStream = new Capnproto.PackedOutputStream(output);
			Capnproto.Serialize.Write(packedOutputStream, message);
		}
		
		/// <exception cref="System.IO.IOException"/>
		public static void WriteToUnbuffered(java.nio.channels.WritableByteChannel output, Capnproto.MessageBuilder message)
		{
			Capnproto.BufferedOutputStreamWrapper buffered = new Capnproto.BufferedOutputStreamWrapper(output);
			Write(buffered, message);
			buffered.Flush();
		}
	}
}
