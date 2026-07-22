using System.Collections.Generic;
using Transloadit.Models;
using Transloadit.Models.Robots;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    public class AnyOfTests
    {
        [Fact]
        public void TwoArg_FirstType_ExposesValueAndType()
        {
            AnyOf<string, List<string>> anyOf = "hello";

            Assert.Equal("hello", anyOf.Value);
            Assert.Equal(typeof(string), anyOf.Type);

            string asString = anyOf;
            Assert.Equal("hello", asString);
        }

        [Fact]
        public void TwoArg_SecondType_ExposesValueAndType()
        {
            var list = new List<string> { "a", "b" };
            AnyOf<string, List<string>> anyOf = list;

            Assert.Same(list, anyOf.Value);
            Assert.Equal(typeof(List<string>), anyOf.Type);

            List<string> asList = anyOf;
            Assert.Same(list, asList);
        }

        [Fact]
        public void TwoArg_ConvertingToWrongType_ReturnsDefault()
        {
            AnyOf<string, List<string>> anyOf = "hello";

            // the outbound operator returns the backing field regardless of which case is set
            List<string> asList = anyOf;
            Assert.Null(asList);
        }

        [Fact]
        public void TwoArg_NullValue_ImplicitlyConvertsToNull()
        {
            AnyOf<string, List<string>> anyOf = (string)null;
            Assert.Null(anyOf);
        }

        [Fact]
        public void ThreeArg_SelectsCorrectCase()
        {
            AnyOf<string, List<string>, AdvancedUse> first = "s";
            AnyOf<string, List<string>, AdvancedUse> second = new List<string> { "x" };
            AnyOf<string, List<string>, AdvancedUse> third = new AdvancedUse();

            Assert.Equal(typeof(string), first.Type);
            Assert.Equal(typeof(List<string>), second.Type);
            Assert.Equal(typeof(AdvancedUse), third.Type);

            Assert.Equal("s", first.Value);
            Assert.IsType<List<string>>(second.Value);
            Assert.IsType<AdvancedUse>(third.Value);
        }

        [Fact]
        public void ThreeArg_NullValue_ImplicitlyConvertsToNull()
        {
            AnyOf<string, List<string>, AdvancedUse> anyOf = (AdvancedUse)null;
            Assert.Null(anyOf);
        }

        [Fact]
        public void ThreeArg_OutboundOperators_ReturnBackingValues()
        {
            var list = new List<string> { "x" };
            var advanced = new AdvancedUse();

            AnyOf<string, List<string>, AdvancedUse> first = "s";
            AnyOf<string, List<string>, AdvancedUse> second = list;
            AnyOf<string, List<string>, AdvancedUse> third = advanced;

            string asString = first;
            List<string> asList = second;
            AdvancedUse asAdvanced = third;

            Assert.Equal("s", asString);
            Assert.Same(list, asList);
            Assert.Same(advanced, asAdvanced);
        }

        [Fact]
        public void TwoArg_Value_ReflectsSecondCase()
        {
            var list = new List<string> { "x" };
            AnyOf<string, List<string>> anyOf = list;

            Assert.Equal(typeof(List<string>), anyOf.Type);
            Assert.Same(list, anyOf.Value);
        }
    }
}
