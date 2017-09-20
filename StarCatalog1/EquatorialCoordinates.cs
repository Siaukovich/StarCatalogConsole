using System;

namespace StarCatalog1
{
    public partial class EquatorialCoordinates
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
                var valueIsValid = value >= -90 && value <= 90;
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
                var valueIsValid = value >= 0 && value <= 360;
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