using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    static class ConvertDirection
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }

        static private Dictionary<Direction, Vector2> toVector = new Dictionary<Direction, Vector2>()
        {
            { Direction.Up, new Vector2(0, -1) },       // up
            { Direction.Down, new Vector2(0, 1) },      // down
            { Direction.Right, new Vector2(1, 0) },     // right
            { Direction.Left, new Vector2(-1, 0) },     // left
            { Direction.DownRight, new Vector2(1, 1) }, // down right
            { Direction.DownLeft, new Vector2(-1, 1) }, // down left
            { Direction.UpRight, new Vector2(1, -1) },  // up right
            { Direction.UpLeft, new Vector2(-1, -1) },  // up left
        };

        static private Dictionary<Direction, float> rotations = new Dictionary<Direction, float>()
        {
            { Direction.Up, 1.6f },         // up
            { Direction.Down, 4.7f },       // down
            { Direction.Right, 3.15f },     // right
            { Direction.Left, 0f },         // left
            { Direction.DownRight, 3.9f },  // down right
            { Direction.DownLeft, 5.5f },   // down left
            { Direction.UpRight, 2.3f },    // up right
            { Direction.UpLeft, 0.8f },     // up left
        };

        /// <summary>
        /// Converts a Vector2 to a Direction enum
        /// </summary>
        /// <param name="direction">Vector2 direction</param>
        /// <returns>Direction enum</returns>
        public static Direction ConvertToEnum(Vector2 direction)
        {
            if (direction.X > 0 && direction.Y == 0)
            {
                return Direction.Right;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                return Direction.Left;
            }
            else if (direction.X == 0 && direction.Y > 0)
            {
                return Direction.Down;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                return Direction.Up;
            }
            else if (direction.X > 0 && direction.Y > 0)
            {
                return Direction.DownRight;
            }
            else if (direction.X > 0 && direction.Y < 0)
            {
                return Direction.UpRight;
            }
            else if (direction.X < 0 && direction.Y > 0)
            {
                return Direction.DownLeft;
            }
            else if (direction.X < 0 && direction.Y < 0)
            {
                return Direction.UpLeft;
            }

            // Default direction
            return Direction.Up;
        }

        /// <summary>
        /// Converts a Direction enum to a Vector2
        /// </summary>
        /// <param name="direction">Direction enum direction</param>
        /// <returns>Vector2</returns>
        public static Vector2 ConvertToVector(Direction direction)
        {
            Vector2 directionVector = toVector[direction];

            return Vector2.Normalize(directionVector);
        }

        /// <summary>
        /// Converts a Direction enum to a float representing the rotation of a sprite based on the parameter
        /// </summary>
        /// <param name="direction">Direction enum direction</param>
        /// <returns>Float representing the rotation of a sprite</returns>
        public static float ConvertToRotation(Direction direction)
        {
            return rotations[direction];
        }

        /// <summary>
        /// Converts a Vector2 to a float representing the rotation of a sprite based on the parameter
        /// </summary>
        /// <param name="direction">Vector2 direction</param>
        /// <returns>Float representing the rotation of a sprite</returns>
        public static float ConvertToRotation(Vector2 direction)
        {
            Direction tempDirection = ConvertToEnum(direction);

            return rotations[tempDirection];
        }

    }
}
