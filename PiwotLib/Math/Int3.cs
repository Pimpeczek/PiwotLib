using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotLib.Math
{
    class Int3: IComparable
    {
        protected int x, y, z;
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Z { get; protected set; }

        #region Static values
        public static Int3 Zero { get; } = new Int3(0, 0, 0);
        public static Int3 One { get; } = new Int3(1, 1, 1);
        public static Int3 Up { get; } = new Int3(0, 1, 0);
        public static Int3 Right { get; } = new Int3(1, 0, 0);
        public static Int3 Down { get; } = new Int3(0, -1, 0);
        public static Int3 Left { get; } = new Int3(-1, 0, 0);
        public static Int3 Forward { get; } = new Int3(0, 0, 1);
        public static Int3 Back { get; } = new Int3(0, 0, -1);
        #endregion

        #region Constructors
        public Int3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Int3(int xyz)
        {
            x = xyz;
            y = xyz;
            z = xyz;
        }
        public Int3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Int3(Int3 i2)
        {
            x = i2.x;
            y = i2.y;
            z = i2.z;
        }
        #endregion

        #region Manipulators
        ///<summary>Swaps values in a clockwise manner (x -> y, y -> z, z -> x) in this instance of the object.
        ///</summary>
        public void Flip()
        {
            int t = z;
            z = y;
            y = x;
            x = t;
        }

        ///<summary>Swaps values in a counterclockwise manner (x -> z, z -> y, y -> x) in this instance of the object.
        ///</summary>
        public void FlipRev()
        {
            int t = y;
            z = x;
            y = z;
            x = t;
        }

        ///<summary>Returns a new instance of Int3 with values swapped in a clockwise manner (x -> y, y -> z, z -> x).
        ///</summary>
        public Int3 Flipped()
        {
            Int3 i3 = new Int3(this);
            i3.Flip();
            return i3;
        }

        ///<summary>Returns a new instance of Int3 with values swapped in a counterclockwise manner (x -> z, z -> y, y -> x).
        ///</summary>
        public Int3 FlippedRev()
        {
            Int3 i3 = new Int3(this);
            i3.FlipRev();
            return i3;
        }

        ///<summary>Returns a new instance of Int3 with values swapped in a clockwise manner (x -> y, y -> z, z -> x).
        ///</summary>
        ///<param name="i">The instance of Int3 class to flip.</param>
        public static Int3 Flip(Int3 i)
        {
            return i.Flipped();
        }

        ///<summary>Returns a new instance of Int3 with values swapped in a counterclockwise manner (x -> z, z -> y, y -> x).
        ///</summary>
        ///<param name="i">The instance of Int3 class to flip.</param>
        public static Int3 FlipRev(Int3 i)
        {
            return i.FlippedRev();
        }



        ///<summary>Returns a new instance of Int3 with values of x, y and z clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of Int3 class to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int3 Clamp(Int3 i, int inclusiveMax)
        {
            return new Int3(Arit.Clamp(i.x, inclusiveMax), 
                            Arit.Clamp(i.y, inclusiveMax), 
                            Arit.Clamp(i.z, inclusiveMax));
        }

        ///<summary>Returns a new instance of Int3 with values of x, y and z clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of Int3 class to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int3 Clamp(Int3 i, int inclusiveMin, int inclusiveMax)
        {
            return new Int3(Arit.Clamp(i.x, inclusiveMin, inclusiveMax), 
                            Arit.Clamp(i.y, inclusiveMin, inclusiveMax), 
                            Arit.Clamp(i.z, inclusiveMin, inclusiveMax));
        }

        ///<summary>Returns a new instance of Int3 with values of x, y and z clamped between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of Int3 class to be clamped.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int3 Clamp(Int3 i, Int3 inclusiveMax)
        {
            return new Int3(Arit.Clamp(i.x, inclusiveMax.x),
                            Arit.Clamp(i.y, inclusiveMax.y),
                            Arit.Clamp(i.z, inclusiveMax.z));
        }

        ///<summary>Returns a new instance of Int3 with values of x, y and z clamped between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of Int3 class to be clamped.</param>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int3 Clamp(Int3 i, Int3 inclusiveMin, Int3 inclusiveMax)
        {
            return new Int3(Arit.Clamp(i.x, inclusiveMin.x, inclusiveMax.x),
                            Arit.Clamp(i.y, inclusiveMin.y, inclusiveMax.y),
                            Arit.Clamp(i.z, inclusiveMin.z, inclusiveMax.z));
        }

        ///<summary>Clamps this instance x, y and z values between 0 and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax);
            Arit.Clamp(y, inclusiveMax);
            Arit.Clamp(z, inclusiveMax);
        }

        ///<summary>Clamps this instance x, y and z values between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMin, int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin, inclusiveMax);
            Arit.Clamp(y, inclusiveMin, inclusiveMax);
            Arit.Clamp(z, inclusiveMin, inclusiveMax);
        }

        ///<summary>Clamps this instance x, y and z values between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int3 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMax.y);
            Arit.Clamp(z, inclusiveMax.z);
        }

        ///<summary>Clamps this instance x, y and z values between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int3 inclusiveMin, Int3 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin.x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMin.y, inclusiveMax.y);
            Arit.Clamp(z, inclusiveMin.z, inclusiveMax.z);
        }
        #endregion

        #region Random
        ///<summary>Returns new instance of Int3 with random values of x, y and z.
        ///</summary>
        public static Int3 Random()
        {
            return new Int3(Rand.Int(), Rand.Int(), Rand.Int());
        }

        ///<summary> Returns new instance of Int3 with random values of x, y and z.
        ///<para>Both x, y and z will be winthin range from 0 to exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int3 Random(int exclusiveMax)
        {
            return new Int3(Rand.Int(exclusiveMax), 
                            Rand.Int(exclusiveMax), 
                            Rand.Int(exclusiveMax));
        }

        ///<summary> Returns new instance of Int3 with random values of x, y and z.
        ///<para>Both x, y and z will be winthin range from 0 to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int3 Random(Int3 exclusiveMax)
        {
            return new Int3(Rand.Int(exclusiveMax.x), 
                            Rand.Int(exclusiveMax.y), 
                            Rand.Int(exclusiveMax.z));
        }

        ///<summary> Returns new instance of Int3 with random values of x, y and z.
        ///<para>Both x, y and z will be winthin range from inclusiveMin to exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower bound of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int3 Random(int inclusiveMin, int exclusiveMax)
        {
            return new Int3(Rand.Int(inclusiveMin, exclusiveMax), 
                            Rand.Int(inclusiveMin, exclusiveMax), 
                            Rand.Int(inclusiveMin, exclusiveMax));
        }

        ///<summary> Returns new instance of Int3 with random values of x, y and z.
        ///<para>Both x, y and z will be winthin range from respective inclusiveMin to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower respective bounds of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int3 Random(Int3 inclusiveMin, Int3 exclusiveMax)
        {
            return new Int3(Rand.Int(inclusiveMin.x, exclusiveMax.y),
                            Rand.Int(inclusiveMin.y, exclusiveMax.y),
                            Rand.Int(inclusiveMin.z, exclusiveMax.z));
        }
        #endregion

        #region Box checks

        ///<summary>
        ///Checks if a given point is inside a given box (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int3 boxSize, Int3 point)
        {
            return point <= boxSize && point >= Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int3 boxSize, Int3 point)
        {
            return point < boxSize && point > Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int3 boxSize, Int3 boxPosition, Int3 point)
        {
            return InBox(boxSize, point - boxPosition);
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int3 boxSize, Int3 boxPosition, Int3 point)
        {
            return InBoxEx(boxSize, point - boxPosition);
        }

        ///<summary>
        ///Checks if a given box is inside another given box(inclusve version).
        ///</summary>
        ///<param name="outsideBoxSize">The size of the outside box.</param>
        ///<param name="outsideBoxPosition">The position of the outside box.</param>
        ///<param name="insideBoxSize">The size of the inside box.</param>
        ///<param name="insideBoxPosition">The position of the inside box.</param>
        public static bool InBox(Int3 outsideBoxSize, Int3 outsideBoxPosition, Int3 insideBoxSize, Int3 insideBoxPosition)
        {
            return insideBoxPosition + insideBoxSize <= outsideBoxPosition + outsideBoxSize && insideBoxPosition >= outsideBoxPosition;
        }

        ///<summary>
        ///Checks if a given box is inside another given box(exclusive version).
        ///</summary>
        ///<param name="outsideBoxSize">The size of the outside box.</param>
        ///<param name="outsideBoxPosition">The position of the outside box.</param>
        ///<param name="insideBoxSize">The size of the inside box.</param>
        ///<param name="insideBoxPosition">The position of the inside box.</param>
        public static bool InBoxEx(Int3 outsideBoxSize, Int3 outsideBoxPosition, Int3 insideBoxSize, Int3 insideBoxPosition)
        {
            return insideBoxPosition + insideBoxSize < outsideBoxPosition + outsideBoxSize && insideBoxPosition > outsideBoxPosition;
        }
        #endregion

        #region Operators
        public static Int3 operator +(Int3 i1, Int3 i2) { return new Int3(i1.x + i2.x, i1.y + i2.y, i1.z + i2.z); }
        public static Int3 operator +(Int3 i1, int x) { return new Int3(i1.x + x, i1.y + x, i1.z + x); }

        public static Int3 operator -(Int3 i1, Int3 i2) { return new Int3(i1.x - i2.x, i1.y - i2.y, i1.z - i2.z); }
        public static Int3 operator -(Int3 i1, int x) { return new Int3(i1.x - x, i1.y - x, i1.z - x); }

        public static Int3 operator *(Int3 i1, Int3 i2) { return new Int3(i1.x * i2.x, i1.y * i2.y, i1.z * i2.z); }
        public static Int3 operator *(Int3 i1, int x) { return new Int3(i1.x * x, i1.y * x, i1.z * x); }

        public static Int3 operator /(Int3 i1, Int3 i2) { return new Int3(i1.x / i2.x, i1.y / i2.y, i1.z / i2.z); }
        public static Int3 operator /(Int3 i1, int x) { return new Int3(i1.x / x, i1.y / x, i1.z / x); }

        public static bool operator ==(Int3 i1, Int3 i2)
        {
            if ((object)i2 == null) return (object)i1 == null; if ((object)i1 == null) return (object)i2 == null;
            if (i1.x == i2.x && i1.y == i2.y && i1.z == i2.z) return true; return false;
        }
        public static bool operator !=(Int3 i1, Int3 i2)
        {
            if ((object)i2 == null) return (object)i1 != null; if ((object)i1 == null) return (object)i2 != null;
            if (i1.x == i2.x && i1.y == i2.y && i1.z == i2.z) return false; return true;
        }
        public static bool operator >=(Int3 i1, Int3 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x >= i2.x && i1.y >= i2.y && i1.z >= i2.z) return true; return false;
        }
        public static bool operator <=(Int3 i1, Int3 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x <= i2.x && i1.y <= i2.y && i1.z <= i2.z) return true; return false;
        }
        public static bool operator >(Int3 i1, Int3 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x > i2.x && i1.y > i2.y && i1.z > i2.z) return true; return false;
        }
        public static bool operator <(Int3 i1, Int3 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x < i2.x && i1.y < i2.y && i1.z < i2.z) return true; return false;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Int3 p = (Int3)obj;
            return this == p;
        }
        #endregion

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ x;
                result = (result * 397) ^ y;
                result = (result * 397) ^ z;
                return result;
            }
        }
        override public string ToString()
        {
            return $"{x}, {y}, {z}";
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Int3 other = obj as Int3;
            if (other != null)
            {
                if (this == other)
                    return 0;
                return this > other ? 1 : -1;
            }
            else
                throw new ArgumentException("Object is not an Int3");
        }
    }
}
