//
//  Position.cs
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
    /// A position (line,column) in the TextBuffer
    /// </summary>
    public readonly struct Position : IEquatable<Position>, IComparable<Position>
    {
        /// <summary>
        /// Instantiates a new Immutable Position
        /// </summary>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        public Position(int line, int column)
        {
            if (line < 1)
                throw new ArgumentOutOfRangeException(nameof(line));
            if (column < 1)
                throw new ArgumentOutOfRangeException(nameof(column));
            Line = line;
            Column = column;
        }

        /// <summary>
        /// Column
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Line
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left isn't equal to right</returns>
        public static bool operator !=(Position left, Position right) => !(left == right);

        /// <summary>
        /// Less than comparison operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left is before right</returns>
        public static bool operator <(Position left, Position right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Less than or equal comparison operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left is before or the same as right</returns>
        public static bool operator <=(Position left, Position right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left equals right</returns>
        public static bool operator ==(Position left, Position right) => left.Equals(right);

        /// <summary>
        /// Greater than comparison operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left is after right</returns>
        public static bool operator >(Position left, Position right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Greater than or equal comparison operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if left is after or the same as right</returns>
        public static bool operator >=(Position left, Position right) => left.CompareTo(right) >= 0;

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings:
        ///   Value
        ///   Meaning
        ///   Less than zero
        ///   This instance precedes <paramref name="other" /> in the sort order.
        ///   Zero
        ///   This instance occurs in the same position in the sort order as <paramref name="other" />.
        ///   Greater than zero
        ///   This instance follows <paramref name="other" /> in the sort order.</returns>
        public int CompareTo(Position other) => throw new NotImplementedException();

        /// <summary>
        /// Compares for equality
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if obj is a Position that has the same values for Line and Column</returns>
        public override bool Equals(object obj) => obj is Position other && Equals(other);

        /// <summary>
        /// Compares for equality
        /// </summary>
        /// <param name="other">Position to compare</param>
        /// <returns>True if other has the same values for Line and Column</returns>
        public bool Equals(Position other) => Line == other.Line && Column == other.Column;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => HashCode.Combine(Line, Column);
    }
}
