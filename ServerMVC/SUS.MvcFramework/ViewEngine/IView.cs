namespace SUS.MvcFramework.ViewEngine
{
    public interface IView
    {
        string GetHtml(object viewModel);
    }
}
