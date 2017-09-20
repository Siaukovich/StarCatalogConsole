using System;

namespace StarCatalog1
{
    public class Angle
    {
        #region Private Fields

        private int _degrees;
        private int _minutes;
        private float _seconds;

        #endregion

        #region Public Properties

        public int Degrees
        {
            get => this._degrees;
            set => this._degrees = value % 360;
        }

        public int Minutes
        {
            get => this._minutes;
            set
            {
                var valueIsValid = 0 <= value && value < 60;
                if (!valueIsValid)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value should be more or equal 0, but less than 60");

                _minutes = value;

            }
        }

        public float Seconds
        {
            get => this._seconds;
            set
            {
                var valueIsValid = 0 <= value && value < 60;
                if (!valueIsValid)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value should be more or equal 0, but less than 60");

                _seconds = value;
            }
        }


        #endregion

        #region Constructor

        public Angle(int degrees = 0, int minutes = 0, float seconds = 0)
        {
            this.Degrees = degrees;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        #endregion

        #region Unequility Operators

        public static bool operator <=(Angle angle1, float angle2) => 
            angle1.GetValue() <= angle2;

        public static bool operator >=(Angle angle1, float angle2) => 
            angle1.GetValue() >= angle2;
            

        #endregion

        #region Helpers

        public double GetValue() => 
            this.Degrees + this.Minutes / 60 + this.Seconds / 3600;

        public override string ToString() => 
            $"{_degrees}°{_minutes}′{_seconds}″";
            
        #endregion
    }
}