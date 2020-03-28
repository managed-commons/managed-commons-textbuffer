//
//  TextRange.cs
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
using System;

namespace Commons.TextBuffer
{
    /// <summary>
    /// A range in the editor. (StartLineNumber,StartColumn) is &lt;= (EndLineNumber,EndColumn)
    /// </summary>
    public readonly struct TextRange : IEquatable<TextRange>
    {
        /// <summary>
        /// Build a new immutable TextRange
        /// (startLineNumber,startColumn) is &lt;= (endLineNumber,endColumn)
        /// </summary>
        /// <param name="startLineNumber">Line number on which the range starts (starts at 1)</param>
        /// <param name="startColumn">Column on which the range starts in line `StartLineNumber` (starts at 1)</param>
        /// <param name="endLineNumber">Line number on which the range ends</param>
        /// <param name="endColumn">Column on which the range ends in line `EndLineNumber`</param>
        public TextRange(int startLineNumber, int startColumn, int endLineNumber, int endColumn)
        {
            if (startLineNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(startLineNumber));
            if (startColumn < 1)
                throw new ArgumentOutOfRangeException(nameof(startColumn));
            if (endLineNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(endLineNumber));
            if (endColumn < 1)
                throw new ArgumentOutOfRangeException(nameof(endColumn));
            StartLineNumber = startLineNumber;
            StartColumn = startColumn;
            EndLineNumber = endLineNumber;
            EndColumn = endColumn;
            if (EndPosition < StartPosition)
                throw new ArgumentException("(startLineNumber,startColumn) should be &lt;= (endLineNumber,endColumn)");
        }

        /// <summary>
        /// Column on which the range ends in line `EndLineNumber`.
        /// </summary>
        public int EndColumn { get; }

        /// <summary>
        /// Line number on which the range ends.
        /// </summary>
        public int EndLineNumber { get; }

        /// <summary>
        /// End position of this range
        /// </summary>
        public Position EndPosition => new Position(line: EndLineNumber, column: EndColumn);

        /// <summary>
        /// Is this range empty?
        /// </summary>
        public bool IsEmpty => StartLineNumber == EndLineNumber && StartColumn == EndColumn;

        /// <summary>
        /// Column on which the range starts in line `StartLineNumber` (starts at 1).
        /// </summary>
        public int StartColumn { get; }

        /// <summary>
        /// Line number on which the range starts (starts at 1).
        /// </summary>
        public int StartLineNumber { get; }

        /// <summary>
        /// Start position of the range
        /// </summary>
        /// <returns>Position for StartLineNumber, StartColumn</returns>
        public Position StartPosition => new Position(line: StartLineNumber, column: StartColumn);

        /// <summary>
        /// Compares two ranges
        /// </summary>
        /// <param name="a">First range</param>
        /// <param name="b">Second range</param>
        /// <returns>
        /// Negative if a &lt; b
        /// Zero if a == b
        /// Positive if a &gt; b
        /// </returns>
        public static int CompareUsingEnds(TextRange a, TextRange b)
        {
            return a.EndLineNumber == b.EndLineNumber
                ? a.EndColumn == b.EndColumn
                    ? a.StartLineNumber == b.StartLineNumber
                        ? a.StartColumn - b.StartColumn
                        : a.StartLineNumber - b.StartLineNumber
                    : a.EndColumn - b.EndColumn
                : a.EndLineNumber - b.EndLineNumber;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left isn't equal to right</returns>
        public static bool operator !=(TextRange left, TextRange right) => !(left == right);

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left equals right</returns>
        public static bool operator ==(TextRange left, TextRange right) => left.Equals(right);

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj) => obj is TextRange other && Equals(other);

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(TextRange other) => EndPosition == other.EndPosition && StartPosition == other.StartPosition;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => HashCode.Combine(EndLineNumber, EndColumn, StartLineNumber, StartColumn);
    }
}
