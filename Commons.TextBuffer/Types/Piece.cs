//
//  Piece.cs
//  managed-commons-textbuffer
//
//  Created by Rafael Teixeira on 2020-03-28.
//  Copyright 2020 Rafael Teixeira, Managed Commons
//
//  Permission is hereby granted, free of charge, to any person obtaining
//  a copy of this software and associated documentation files (the
//  "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish,
//  distribute, sublicense, and/or sell copies of the Software, and to
//  permit persons to whom the Software is furnished to do so, subject to
//  the following conditions:
//
//  The above copyright notice and this permission notice shall be
//  included in all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//  MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//  LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//  WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Commons.TextBuffer
{
    /// <summary>
    /// Piece of unchanged or added text in the buffers
    /// </summary>
    public readonly struct Piece
    {
        /// <summary>
        /// Buffer this piece points into
        /// </summary>
        public readonly int BufferIndex;

        /// <summary>
        /// Cursor end position
        /// </summary>
        public readonly Position CursorEnd;

        /// <summary>
        /// Cursor start position
        /// </summary>
        public readonly Position CursorStart;

        /// <summary>
        /// Length of this piece in bytes
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// LineFeed count
        /// </summary>
        public readonly int LineFeedCount;

        /// <summary>
        /// Initializes a new piece
        /// </summary>
        /// <param name="bufferIndex">Buffer this piece points into</param>
        /// <param name="cursorStart">Cursor start position</param>
        /// <param name="cursorEnd">Cursor end position</param>
        /// <param name="length">Length of this piece in bytes</param>
        /// <param name="lineFeedCount">LineFeed count</param>
        public Piece(int bufferIndex, Position cursorStart, Position cursorEnd, int length, int lineFeedCount) {
            BufferIndex = bufferIndex;
            CursorStart = cursorStart;
            CursorEnd = cursorEnd;
            Length = length;
            LineFeedCount = lineFeedCount;
        }
    }
}
