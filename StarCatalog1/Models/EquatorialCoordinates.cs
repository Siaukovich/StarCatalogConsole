using System;

namespace StarCatalog1
{
    public class EquatorialCoordinates
    {
        #region Private Fields

        private Angle _declination;
        private Angle _rightAscension;

        #endregion

        #region Public Fields

        public Angle Declination
        {
            get => this._declination;
            set
            {
                var minValue = new Angle(-90);
                var maxValue = new Angle(90);
                var valueIsValid = value >= minValue && value <= maxValue;
                if (!valueIsValid)
                    throw new ArgumentOutOfRangeException(nameof(value));

                this._declination = value;
            }
        }

        public Angle RightAscension
        {
            get => this._rightAscension;
            set
            {
                var minValue = new Angle(0);
                var maxValue = new Angle(360);
                var valueIsValid = value >= minValue && value <= maxValue;
                if (!valueIsValid)
                    throw new ArgumentOutOfRangeException(nameof(value));

                this._rightAscension = value;
            }
        }


        #endregion

        #region Constructors

        public EquatorialCoordinates(Angle declination, Angle rightAscension)
        { 
            this.Declination = declination;
            this.RightAscension = rightAscension;
        }

        public EquatorialCoordinates()
        {
            this.Declination = new Angle();
            this.RightAscension = new Angle();
        }

        #endregion

        #region Helpers

        public override string ToString()
        {
            return $"Declination: {this._declination}\n" +
                   $"Right ascension: {this._rightAscension}";
        }

        #endregion
    }
}