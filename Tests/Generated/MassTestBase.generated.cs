// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Mass.
    /// </summary>
    public abstract partial class MassTestsBase
    {
        protected abstract double Delta { get; }

        protected abstract double OneKilogramInCentigrams { get; }
        protected abstract double OneKilogramInDecagrams { get; }
        protected abstract double OneKilogramInDecigrams { get; }
        protected abstract double OneKilogramInGrams { get; }
        protected abstract double OneKilogramInHectograms { get; }
        protected abstract double OneKilogramInKilograms { get; }
        protected abstract double OneKilogramInKilotonnes { get; }
        protected abstract double OneKilogramInLongTons { get; }
        protected abstract double OneKilogramInMegatonnes { get; }
        protected abstract double OneKilogramInMilligrams { get; }
        protected abstract double OneKilogramInShortTons { get; }
        protected abstract double OneKilogramInTonnes { get; }

        [Test]
        public void KilogramToMassUnits()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(OneKilogramInCentigrams, kilogram.Centigrams, Delta);
            Assert.AreEqual(OneKilogramInDecagrams, kilogram.Decagrams, Delta);
            Assert.AreEqual(OneKilogramInDecigrams, kilogram.Decigrams, Delta);
            Assert.AreEqual(OneKilogramInGrams, kilogram.Grams, Delta);
            Assert.AreEqual(OneKilogramInHectograms, kilogram.Hectograms, Delta);
            Assert.AreEqual(OneKilogramInKilograms, kilogram.Kilograms, Delta);
            Assert.AreEqual(OneKilogramInKilotonnes, kilogram.Kilotonnes, Delta);
            Assert.AreEqual(OneKilogramInLongTons, kilogram.LongTons, Delta);
            Assert.AreEqual(OneKilogramInMegatonnes, kilogram.Megatonnes, Delta);
            Assert.AreEqual(OneKilogramInMilligrams, kilogram.Milligrams, Delta);
            Assert.AreEqual(OneKilogramInShortTons, kilogram.ShortTons, Delta);
            Assert.AreEqual(OneKilogramInTonnes, kilogram.Tonnes, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Mass kilogram = Mass.FromKilograms(1); 
            Assert.AreEqual(1, Mass.FromCentigrams(kilogram.Centigrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromDecagrams(kilogram.Decagrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromDecigrams(kilogram.Decigrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromGrams(kilogram.Grams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromHectograms(kilogram.Hectograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilograms(kilogram.Kilograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilotonnes(kilogram.Kilotonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromLongTons(kilogram.LongTons).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromMegatonnes(kilogram.Megatonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromMilligrams(kilogram.Milligrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromShortTons(kilogram.ShortTons).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromTonnes(kilogram.Tonnes).Kilograms, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Mass v = Mass.FromKilograms(1);
            Assert.AreEqual(-1, -v.Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(3)-v).Kilograms, Delta);
            Assert.AreEqual(2, (v + v).Kilograms, Delta);
            Assert.AreEqual(10, (v*10).Kilograms, Delta);
            Assert.AreEqual(10, (10*v).Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(10)/5).Kilograms, Delta);
            Assert.AreEqual(2, Mass.FromKilograms(10)/Mass.FromKilograms(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Mass oneKilogram = Mass.FromKilograms(1);
            Mass twoKilograms = Mass.FromKilograms(2);

            Assert.True(oneKilogram < twoKilograms);
            Assert.True(oneKilogram <= twoKilograms);
            Assert.True(twoKilograms > oneKilogram);
            Assert.True(twoKilograms >= oneKilogram);

            Assert.False(oneKilogram > twoKilograms);
            Assert.False(oneKilogram >= twoKilograms);
            Assert.False(twoKilograms < oneKilogram);
            Assert.False(twoKilograms <= oneKilogram);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(0, kilogram.CompareTo(kilogram));
            Assert.Greater(kilogram.CompareTo(Mass.Zero), 0);
            Assert.Less(Mass.Zero.CompareTo(kilogram), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Mass kilogram = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogram.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Mass kilogram = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogram.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Mass a = Mass.FromKilograms(1);
            Mass b = Mass.FromKilograms(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a); 
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            Mass v = Mass.FromKilograms(1);
            Assert.IsTrue(v.Equals(Mass.FromKilograms(1)));
            Assert.IsFalse(v.Equals(Mass.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.IsFalse(kilogram.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.IsFalse(kilogram.Equals(null));
        }
    }
}
