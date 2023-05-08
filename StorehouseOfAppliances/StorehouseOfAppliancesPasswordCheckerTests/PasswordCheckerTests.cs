using StorehouseOfAppliancesPasswordCheckerPasswordChecker;

namespace StorehouseOfAppliancesPasswordCheckerTests.Tests
{
    [TestClass]
    public class PasswordCheckerTests
    {
        private readonly PasswordChecker _passwordChecker;

        public PasswordCheckerTests()
        {
            _passwordChecker = new PasswordChecker();
        }

        [TestMethod]
        public void PasswordChecker_5LowerSymbols_1Point()
        {
            // Исходные данные
            string password = "qweas";
            PasswordComplexityLevel expected = PasswordComplexityLevel.UNRELIABLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithUpperSymbol_2Point()
        {
            // Исходные данные
            string password = "qweaS";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithDigits_2Point()
        {
            // Исходные данные
            string password = "qw342";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithSigns_2Point()
        {
            // Исходные данные
            string password = "qw@#!";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5UpperSymbolsWithDigits_2Point()
        {
            // Исходные данные
            string password = "QW342";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5UpperSymbolsWithSigns_2Point()
        {
            // Исходные данные
            string password = "QW@#!";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5DigitsWithSigns_2Point()
        {
            // Исходные данные
            string password = "13@#!";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }



        [TestMethod]
        public void PasswordChecker_5SymbolsWithUpperSymbolAndWithDigit_3Point()
        {
            // Исходные данные
            string password = "qwe5S";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithUpperSymbolAndWithSign_3Point()
        {
            // Исходные данные
            string password = "qwe@X";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithDigitAndWithSign_3Point()
        {
            // Исходные данные
            string password = "qwe@9";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5UpperSymbolsWithDigitAndWithSign_3Point()
        {
            // Исходные данные
            string password = "WQQ@9";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_5SymbolsWithUpperSymbolAndWithDigitAndSign_4Point()
        {
            // Исходные данные
            string password = "qw!5S";
            PasswordComplexityLevel expected = PasswordComplexityLevel.GOOD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithUpperSymbolAndWithDigitAndSign_5Point()
        {
            // Исходные данные
            string password = "aaaqw!5S";
            PasswordComplexityLevel expected = PasswordComplexityLevel.HARD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_OneSign_1Point()
        {
            // Исходные данные
            string password = "!";
            PasswordComplexityLevel expected = PasswordComplexityLevel.UNRELIABLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_OneDigit_1Point()
        {
            // Исходные данные
            string password = "1";
            PasswordComplexityLevel expected = PasswordComplexityLevel.UNRELIABLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_OneUpperSymbol_1Point()
        {
            // Исходные данные
            string password = "Ц";
            PasswordComplexityLevel expected = PasswordComplexityLevel.UNRELIABLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_OneLowerSymbol_1Point()
        {
            // Исходные данные
            string password = "г";
            PasswordComplexityLevel expected = PasswordComplexityLevel.UNRELIABLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8LowerSymbols_2Point()
        {
            // Исходные данные
            string password = "qweasdzx";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8UpperSymbols_2Point()
        {
            // Исходные данные
            string password = "QWEASDZX";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8Signs_2Point()
        {
            // Исходные данные
            string password = "!@#$%^&*";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8Digits_2Point()
        {
            // Исходные данные
            string password = "12345678";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithUpperSymbols_3Point()
        {
            // Исходные данные
            string password = "йцуQWEqк";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithDigits_3Point()
        {
            // Исходные данные
            string password = "qwea1234";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithSigns_3Point()
        {
            // Исходные данные
            string password = "qwea!@#$";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8UpperSymbolsWithDigits_3Point()
        {
            // Исходные данные
            string password = "QWER1234";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8UpperSymbolsWithSigns_3Point()
        {
            // Исходные данные
            string password = "QWER!@#$";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8DigitsWithSigns_3Point()
        {
            // Исходные данные
            string password = "1234!@#$";
            PasswordComplexityLevel expected = PasswordComplexityLevel.SIMPLE;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithUpperSymbolsAndDigits_4Point()
        {
            // Исходные данные
            string password = "asqSDФ13";
            PasswordComplexityLevel expected = PasswordComplexityLevel.GOOD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithUpperSymbolsAndSigns_4Point()
        {
            // Исходные данные
            string password = "фыSDA!@#";
            PasswordComplexityLevel expected = PasswordComplexityLevel.GOOD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8SymbolsWithDigitsAndSigns_4Point()
        {
            // Исходные данные
            string password = "aqw123!@";
            PasswordComplexityLevel expected = PasswordComplexityLevel.GOOD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PasswordChecker_8UpperSymbolsWithDigitsAndSigns_4Point()
        {
            // Исходные данные
            string password = "ASD321$%";
            PasswordComplexityLevel expected = PasswordComplexityLevel.GOOD;

            // Фактический результат
            PasswordComplexityLevel result = _passwordChecker.Check(password);

            // Проверяем
            Assert.AreEqual(expected, result);
        }
    }
}