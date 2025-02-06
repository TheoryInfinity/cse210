


public class Fraction {
    private int _numerator;
    private int _denominator;

        public Fraction() {
            _numerator = -1;
            _denominator = -1;
        }

        public Fraction(int wholeNumber) {
            _numerator = wholeNumber;
            _denominator = 1;
        }

        public Fraction(int top, int bottom) {
            _numerator = top;
            _denominator = bottom;
        }

        public void SetNumerator(int top) {
            _numerator = top;
        }

        public void SetDenominator(int bottom) {
            _denominator = bottom;
        }

        public int GetDenominator() {
            return _denominator;
        } 
        public int GetNumerator() {
            return _numerator;
        } 

        public string GetFractionString() {
            string FractionString = $"{_numerator}/{_denominator}";
            return FractionString;
        }

        public double GetDecimalValue() {
            double DecimalValue = (double)_numerator / (double)_denominator;
            return DecimalValue;
        }

}