using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    class RepelSystem : IRepelable
    {
        private enum Side
        {
            Left, Right, Top, Bottom,
        }

        private Side closestHorizontalSide;
        private Side closestVerticalSide;

        private float horizontalDistance;
        private float verticalDistance;

        public void InputDirection(Character2D my, Gameobject other)
        {
            float xDistanceLeft = Vector2.Distance(new Vector2(my.HitBox.Left, my.Position.Y), new Vector2(other.HitBox.Right, my.Position.Y));
            float xDistanceRight = Vector2.Distance(new Vector2(my.HitBox.Right, my.Position.Y), new Vector2(other.HitBox.Left, my.Position.Y));

            float yDistanceTop = Vector2.Distance(new Vector2(my.Position.X, my.HitBox.Top), new Vector2(my.Position.X, other.HitBox.Bottom));
            float yDistanceBottom = Vector2.Distance(new Vector2(my.Position.X, my.HitBox.Bottom), new Vector2(my.Position.X, other.HitBox.Top));

            var HorizontalFields = GetHorizontalFields(xDistanceLeft, xDistanceRight);

            closestHorizontalSide = HorizontalFields.closestHorizontalSide;
            horizontalDistance = HorizontalFields.xDistance;

            var VerticalFields = GetVerticalFields(yDistanceTop, yDistanceBottom);

            closestVerticalSide = VerticalFields.closestVerticalSide;
            verticalDistance = VerticalFields.yDistance;


            Side myCollidingSide = GetMyCollidingSide();
            my.Direction = GetVelocity(myCollidingSide, my);

            if (other is Character2D)
            {
                Side otherCollidingSide = GetOppositeCollidingSide(myCollidingSide);
                (other as Character2D).Direction = GetVelocity(otherCollidingSide, other as Character2D);
            }
        }

        /// <summary>
        /// Returns the closest horizontal side, and the smalles distance of horizontal distances.
        /// </summary>
        /// <param name="yDistanceTop"></param>
        /// <param name="yDistanceBottom"></param>
        /// <returns></returns>
        private (Side closestVerticalSide, float yDistance) GetVerticalFields(float yDistanceTop, float yDistanceBottom)
        {
            if (yDistanceTop < yDistanceBottom) { return (Side.Top, yDistanceTop); }
            else { return (Side.Bottom, yDistanceBottom); }
        }

        /// <summary>
        /// Returns the closest vertical side, and the smalles distance of vertical distances.
        /// </summary>
        /// <param name="yDistanceTop"></param>
        /// <param name="yDistanceBottom"></param>
        /// <returns></returns>
        private (Side closestHorizontalSide, float xDistance) GetHorizontalFields(float xDistanceLeft, float xDistanceRight)
        {
            if (xDistanceLeft < xDistanceRight) { return (Side.Left, xDistanceLeft); }
            else { return (Side.Right, xDistanceRight); }
        }

        private Side GetMyCollidingSide()
        {
            if (horizontalDistance < verticalDistance) { return closestHorizontalSide; }
            else { return closestVerticalSide; }
        }

        private Side GetOppositeCollidingSide(Side collidingSide)
        {
            switch (collidingSide)
            {
                case Side.Left: return Side.Right;
                case Side.Right: return Side.Left;
                case Side.Top: return Side.Bottom;
                case Side.Bottom: return Side.Top;
                default: return Side.Bottom;
            }
        }

        private Vector2 GetVelocity(Side collidingSide, Character2D character)
        {
            if (collidingSide == Side.Right && character.Direction.X > 0 || collidingSide == Side.Left && character.Direction.X < 0)
            {
                return new Vector2(0, character.Direction.Y);
            }

            if (collidingSide == Side.Bottom && character.Direction.Y > 0 || collidingSide == Side.Top && character.Direction.Y < 0)
            {
                return new Vector2(character.Direction.X, 0);
            }

            return character.Direction;
        }
    }


}
