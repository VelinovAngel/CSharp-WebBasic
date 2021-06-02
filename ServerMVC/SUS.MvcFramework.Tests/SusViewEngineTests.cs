namespace SUS.MvcFramework.Tests
{
    using System;
    using System.IO;
    using Xunit;

    using SUS.MvcFramework.ViewEngine;
    using System.Collections.Generic;

    public partial class SusViewEngineTests
    {
        public object IViewModel { get; private set; }

        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        [InlineData("htmlSorceCode")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                Name = "Doggo Arghentino",
                DateOfBirth = new DateTime(2019, 6, 1),
                Price = 12345.67M,
            };

            IViewEngine viewEngine = new SusViewEngine();
            var view = File.ReadAllText($"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel, null);
            var expectedResult = File.ReadAllText($"ViewTests/{fileName}.Result.html");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestTemplateViewModel()
        {
            IViewEngine viewEngine = new SusViewEngine();
            var actualResult = viewEngine.GetHtml(@"@foreach(var num in Model)
{
<span>@num</span>
}", new List<int>() { 1, 2, 3 }, null);
            var expectedResult = @"<span>1</span>
<span>2</span>
<span>3</span>";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
