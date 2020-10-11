using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.PMath
{
    /// <summary>Class storing two integers. All operations are pointwise.</summary>
    public class Int2: IComparable
    {
        #region Fields
        /// <summary>
        /// The x value;
        /// </summary>
        protected int x;
        /// <summary>
        /// The y value;
        /// </summary>
        protected int y;

        /// <summary>
        /// The x value.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        /// <summary>
        /// The y value.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        #endregion

        #region Static values
        /// <summary>
        /// (0,0)
        /// </summary>
        public static Int2 Zero { get { return new Int2(0); } }
        /// <summary>
        /// (1,1)
        /// </summary>
        public static Int2 One { get { return new Int2(1); } }
        /// <summary>
        /// (2147483647,2147483647)
        /// </summary>
        public static Int2 MaxValue { get { return new Int2(int.MaxValue); } }
        /// <summary>
        /// (-2147483648,-2147483648)
        /// </summary>
        public static Int2 MinValue { get { return new Int2(int.MinValue); } }
        /// <summary>
        /// (0,1)
        /// </summary>
        public static Int2 Up { get { return new Int2(0, 1); } }
        /// <summary>
        /// (1,0)
        /// </summary>
        public static Int2 Right { get { return new Int2(1, 0); } }
        /// <summary>
        /// (0,-1)
        /// </summary>
        public static Int2 Down { get { return new Int2(0, -1); } }
        /// <summary>
        /// (-1,0)
        /// </summary>
        public static Int2 Left { get { return new Int2(-1, 0); } }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Int2()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xy"></param>
        public Int2(int xy)
        {
            x = xy;
            y = xy;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Int2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i2"></param>
        public Int2(Int2 i2)
        {
            x = i2.x;
            y = i2.y;
        }
        #endregion

        #region Manipulators
        ///<summary>Swaps values of x and y in this instance of the object.
        ///</summary>
        public void Flip()
        {
            int t = x;
            x = y;
            y = t;
        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with swapped x and y values.
        ///</summary>
        ///<param name="i">The instance of <see cref="Int2"/> class to flip.</param>
        public static Int2 Flip(Int2 i)
        {
            return i.Flipped();
        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with swapped x and y values.
        ///</summary>
        public Int2 Flipped()
        {
            return new Int2(y, x);
        }

        ///<summary>Rotates values of x and y in clockwise direction in this instance of the object.
        ///</summary>
        public void RotateRight()
        {
            int t = x;
            x = y;
            y = -t;
        }

        ///<summary>Rotates values of x and y in anti-clockwise direction in this instance of the object.
        ///</summary>
        public void RotateLeft()
        {
            int t = x;
            x = -y;
            y = t;
        }


        /// <summary>
        /// Rotates values of x and y a given amount of times in a given direction.
        /// </summary>
        /// <param name="direction">The direction of rotation, positive numbers being clockwise.</param>
        public void Rotate(int direction)
        {
            bool leftFlag = false;
            if (direction < 0)
            {
                direction *= -1;
                leftFlag = true;
            }
            direction %= 4;
            if (direction == 0)
                return;
            if (leftFlag)
            {
                for (int i = 0; i < direction; i++)
                {
                    RotateLeft();
                }
            }
            else
            {
                for (int i = 0; i < direction; i++)
                {
                    RotateRight();
                }
            }
        }

        ///<summary>Rotates values of x and y in clockwise direction.
        ///</summary>
        static public void RotateRight(Int2 i)
        {
            i.RotateRight();
        }

        ///<summary>Rotates values of x and y in anti-clockwise direction.
        ///</summary>
        static public void RotateLeft(Int2 i)
        {
            i.RotateLeft();
        }


        /// <summary>
        /// Rotates values of x and y a given amount of times in a given direction.
        /// </summary>
        /// <param name="direction">The direction of rotation, positive numbers being clockwise.</param>
        static public void Rotate(Int2 i, int direction)
        {
            i.Rotate(direction);
        }


        ///<summary>Return a new instance of <see cref="Int2"/> with values of x and y rotated in clockwise direction.
        ///</summary>
        public Int2 RotatedRight()
        {
            Int2 i = new Int2(this);
            i.RotateRight();
            return i;
        }

        ///<summary>Return a new instance of <see cref="Int2"/> with values of x and y rotated in anti-clockwise direction.
        ///</summary>
        public Int2 RotatedLeft()
        {
            Int2 i = new Int2(this);
            i.RotatedLeft();
            return i;
        }


        /// <summary>
        /// Return a new instance of <see cref="Int2"/> with values of x and y rotated in a given direction.
        /// </summary>
        /// <param name="direction">The direction of rotation, positive numbers being clockwise.</param>
        public Int2 Rotated(int direction)
        {
            Int2 i = new Int2(this);
            i.Rotate(direction);
            return i;
        }

        /// <summary>
        /// Returns a direction closest to a given vector where "Up"(0, 1) is 0, "Right"(1, 0) is 1, "Down"(0, -1) is 2, "Left"(-1, 0) is 3. Will return 0 if vector==<see cref="Int2"/>.Zero
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static int Compass(Int2 vector)
        {
            int lenX = Math.Abs(vector.X);
            int lenY = Math.Abs(vector.Y);
            if (lenX > lenY)
            {
                return (vector.X >= 0 ? 1 : 3);
            }
            else
            {
                return (vector.y >= 0 ? 0 : 2);
            }

        }
        /// <summary>
        /// Returns a <see cref="Int2"/> instance pointing in a given drection. Works for all values, as they are mapped to one of four(0,1,2,3) possible directions in a looping manner.
        /// </summary>
        /// <param name="direction">Any number</param>
        /// <returns></returns>
        public static Int2 Compass(int direction)
        {
            if(direction >= 0)
            {
                direction %= 4;
            }
            else
            {
                direction = 3 + (direction + 1) % 4;
            }
            switch(direction)
            {
                case 0:  return Up;
                case 1:  return Right;
                case 2:  return Down;
                default: return Left;
            }

        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with values of x and y clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of <see cref="Int2"/> class to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int2 Clamp(Int2 i, int inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMax), Arit.Clamp(i.y, inclusiveMax));
        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with values of x and y clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of <see cref="Int2"/> class to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int2 Clamp(Int2 i, int inclusiveMin, int inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMin, inclusiveMax), Arit.Clamp(i.y, inclusiveMin, inclusiveMax));
        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with values of x and y clamped between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of <see cref="Int2"/> class to be clamped.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int2 Clamp(Int2 i, Int2 inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMax.x), Arit.Clamp(i.y, inclusiveMax.y));
        }

        ///<summary>Returns a new instance of <see cref="Int2"/> with values of x and y clamped between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of <see cref="Int2"/> class to be clamped.</param>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int2 Clamp(Int2 i, Int2 inclusiveMin, Int2 inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMin.x, inclusiveMax.x), Arit.Clamp(i.y, inclusiveMin.y, inclusiveMax.y));
        }

        ///<summary>Clamps this instance x and y values between 0 and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax);
            Arit.Clamp(y, inclusiveMax);
        }

        ///<summary>Clamps this instance x and y values between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMin, int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin, inclusiveMax);
            Arit.Clamp(y, inclusiveMin, inclusiveMax);
        }

        ///<summary>Clamps this instance x and y values between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int2 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMax.y);
        }

        ///<summary>Clamps this instance x and y values between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int2 inclusiveMin, Int2 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin.x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMin.y, inclusiveMax.y);
        }

        /// <summary>
        /// Function designed for grid based systems, that require chunking or similar scale-step operations.
        /// Divides a given <see cref="Int2"/> by a given divisor while taking into account negative coordinates.
        /// <para>
        /// 
        /// </para>
        /// </summary>
        /// <param name="int2"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static Int2 DivideOnGrid(Int2 int2, int divisor)
        {
            Int2 pos = int2 / divisor;
            if (int2.X < 0 && int2.X % divisor != 0)
            {
                pos.X -= 1;
            }
            if (int2.Y < 0 && int2.Y % divisor != 0)
            {
                pos.Y -= 1;
            }
            return pos;
        }
        /// <summary>
        /// Returns a list of grid positions that are at most maxDistance units from the middle point.
        /// </summary>
        /// <param name="position">Position of the middle of the virtual circle</param>
        /// <param name="maxDistance">Maximal distance.</param>
        /// <param name="minDistance">TODO</param>
        /// <returns></returns>
        public static List<Int2> GetGridPositions(Int2 position, float maxDistance, float minDistance = 0)
        {
            List<Int2> positions = new List<Int2>();
            float tempDistance = maxDistance / (float)Constants.Root2;
            int R = (int)Math.Floor(maxDistance);
            int r = (int)Math.Floor(tempDistance);
            int p = (int)Math.Floor(maxDistance - tempDistance);
            int n = R - r;
            int P = R - p;
            float powDist = maxDistance * maxDistance;
            int X = position.X;
            int Y = position.Y;
            Data.Loops.ForLoop(r, r, 
                (x, y) => {
                    positions.Add(new Int2(X + x, Y + y));
                    if(x != 0)
                    {
                        positions.Add(new Int2(X - x, Y + y));
                        if (y != 0)
                        {
                            positions.Add(new Int2(X + x, Y - y));
                            positions.Add(new Int2(X - x, Y - y));
                        }
                    }
                    else
                    {
                        if (y != 0)
                        {
                            positions.Add(new Int2(X + x, Y - y));
                        }
                    }
                }
                );
            for (int x = 0; x < r; x++)
            {
                for (int y = r; y <= R; y++)
                {
                    if (powDist >= x * x + y * y)
                    {
                        positions.Add(new Int2(X + x, Y + y));
                        if (x != 0)
                        {
                            positions.Add(new Int2(X - x, Y + y));
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                                positions.Add(new Int2(X - x, Y - y));
                            }
                        }
                        else
                        {
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                            }
                        }
                    }
                }
            }

            for (int x = r; x <= R; x++)
            {
                for (int y = 0; y < P; y++)
                {
                    if (powDist >= x * x + y * y)
                    {
                        positions.Add(new Int2(X + x, Y + y));
                        if (x != 0)
                        {
                            positions.Add(new Int2(X - x, Y + y));
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                                positions.Add(new Int2(X - x, Y - y));
                            }
                        }
                        else
                        {
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                            }
                        }
                    }
                }
            }

            for (int x = r; x < P; x++)
            {
                for (int y = P; y <= R; y++)
                {
                    if (powDist >= x * x + y * y)
                    {
                        positions.Add(new Int2(X + x, Y + y));
                        if (x != 0)
                        {
                            positions.Add(new Int2(X - x, Y + y));
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                                positions.Add(new Int2(X - x, Y - y));
                            }
                        }
                        else
                        {
                            if (y != 0)
                            {
                                positions.Add(new Int2(X + x, Y - y));
                            }
                        }
                    }
                }
            }

            return positions;
        }

        #endregion

        #region Random
        ///<summary>Returns new instance of <see cref="Int2"/> with random values of x and y.
        ///</summary>
        public static Int2 Random()
        {
            return new Int2(Rand.Int(), Rand.Int());
        }

        ///<summary> Returns new instance of <see cref="Int2"/> with random values of x and y.
        ///<para>Both x and y will be winthin range from 0 to exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int2 Random(int exclusiveMax)
        {
            return new Int2(Rand.Int(exclusiveMax), Rand.Int(exclusiveMax));
        }

        ///<summary> Returns new instance of <see cref="Int2"/> with random values of x and y.
        ///<para>Both x and y will be winthin range from 0 to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int2 Random(Int2 exclusiveMax)
        {
            return new Int2(Rand.Int(exclusiveMax.x), Rand.Int(exclusiveMax.y));
        }

        ///<summary> Returns new instance of <see cref="Int2"/> with random values of x and y.
        ///<para>Both x and y will be winthin range from inclusiveMin to exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower bound of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int2 Random(int inclusiveMin, int exclusiveMax)
        {
            return new Int2(Rand.Int(inclusiveMin, exclusiveMax), Rand.Int(inclusiveMin, exclusiveMax));
        }

        ///<summary> Returns new instance of <see cref="Int2"/> with random values of x and y.
        ///<para>Both x and y will be winthin range from respective inclusiveMin to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower respective bounds of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int2 Random(Int2 inclusiveMin, Int2 exclusiveMax)
        {
            return new Int2(Rand.Int(inclusiveMin.x, exclusiveMax.y), Rand.Int(inclusiveMin.y, exclusiveMax.y));
        }
        #endregion

        #region Box checks

        ///<summary>
        ///Checks if a given point is inside a given box (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int2 boxSize, Int2 point)
        {
            return point <= boxSize && point >= Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int2 boxSize, Int2 point)
        {
            return point < boxSize && point > Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int2 boxSize, Int2 boxPosition, Int2 point)
        {
            return InBox(boxSize, point - boxPosition);
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int2 boxSize, Int2 boxPosition, Int2 point)
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
        public static bool InBox(Int2 outsideBoxSize, Int2 outsideBoxPosition, Int2 insideBoxSize, Int2 insideBoxPosition)
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
        public static bool InBoxEx(Int2 outsideBoxSize, Int2 outsideBoxPosition, Int2 insideBoxSize, Int2 insideBoxPosition)
        {
            return insideBoxPosition + insideBoxSize < outsideBoxPosition + outsideBoxSize && insideBoxPosition > outsideBoxPosition;
        }
        #endregion

        #region Operators
        /// <summary>
        /// The pointwise addition operation between two <see cref="Int2"/> objects.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static Int2 operator +(Int2 i1, Int2 i2) { return new Int2(i1.x + i2.x, i1.y + i2.y); }

        /// <summary>
        /// The addition operation between a <see cref="Int2"/> object and a integer. Both X and Y are incremented by a given value.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Int2 operator +(Int2 i1, int x) { return new Int2(i1.x + x, i1.y + x); }

        /// <summary>
        /// The pointwise subtraction operation between two <see cref="Int2"/> objects.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static Int2 operator -(Int2 i1, Int2 i2) { return new Int2(i1.x - i2.x, i1.y - i2.y); }

        /// <summary>
        /// The subtraction operation between a <see cref="Int2"/> object and a integer. Both X and Y are decremented by a given value.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Int2 operator -(Int2 i1, int x) { return new Int2(i1.x - x, i1.y - x); }

        /// <summary>
        /// The pointwise multiplication operation between two <see cref="Int2"/> objects.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static Int2 operator *(Int2 i1, Int2 i2) { return new Int2(i1.x * i2.x, i1.y * i2.y); }

        /// <summary>
        /// The multiplication operation between a <see cref="Int2"/> object and a integer. Both X and Y are multiplied by a given value.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Int2 operator *(Int2 i1, int x) { return new Int2(i1.x * x, i1.y * x); }

        /// <summary>
        /// The pointwise division operation between two <see cref="Int2"/> objects.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static Int2 operator /(Int2 i1, Int2 i2) { return new Int2(i1.x / i2.x, i1.y / i2.y); }
        /// <summary>
        /// The division operation between a <see cref="Int2"/> object and a integer. Both X and Y are divided by a given value.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Int2 operator /(Int2 i1, int x) { return new Int2(i1.x / x, i1.y / x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator ==(Int2 i1, Int2 i2)
        {
            if (i2 is null) return i1 is null; if (i1 is null) return i2 is null;
            if (i1.x == i2.x && i1.y == i2.y) return true; return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator !=(Int2 i1, Int2 i2)
        {
            if (i2 is null) return !(i1 is null); if (i1 is null) return !(i2 is null);
            if (i1.x == i2.x && i1.y == i2.y) return false; return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator >=(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x >= i2.x && i1.y >= i2.y) return true; return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator <=(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x <= i2.x && i1.y <= i2.y) return true; return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator >(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x > i2.x && i1.y > i2.y) return true; return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator <(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x < i2.x && i1.y < i2.y) return true; return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Int2 p = (Int2)obj;
            return this == p;
        }
        #endregion

        #region Misc
        /// <summary>
        /// Creates a hash code of this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ x;
                result += (result * 397) ^ y;
                return result;
            }
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this <see cref="Int2"/> object.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return x + ", " + y;
        }

        /// <summary>
        /// Copares two <see cref="Int2"/> objects.
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Int2 other = obj as Int2;
            if (other != null)
            {
                if(this == other)
                    return 0;
                return this > other ? 1 : -1;
            }
            else
                throw new ArgumentException("Object is not an Int2");
        }
        #endregion
    }
}
