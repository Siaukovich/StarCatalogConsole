using System;

namespace StarCatalog1
{
    public class Angle
    {
        private float _value;

        public float Value
        {
            get => this._value;
            set => this._value = value % 360;
        }

        public Angle(float value = 0)
        {
            this.Value = value;
        }

        public static bool operator <=(Angle angle1, Angle angle2) => 
            angle1.Value <= angle2.Value;

        public static bool operator >=(Angle angle1, Angle angle2) => 
            angle1.Value >= angle2.Value;
            
        /// <summary>
        /// Tries to parse from string to Angle.
        /// Returns true if success, false otherwise.
        /// </summary>
        /// <param name="str">Must be in form "DD MM SS.SS"</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParse(string str, out Angle value)
        {
            value = new Angle();
            if (Single.TryParse(str, out float result))
            {
                value.Value = result;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parse from string to Angle.
        /// Returns new Angle object if parsing successfull, null otherwise.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static Angle Parse(string str)
        //{
        //    try
        //    {
        //        var floatValue = Convert.ToSingle(str);
        //        return new Angle(floatValue);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}

        public override string ToString() => _value.ToString();       
    }
}