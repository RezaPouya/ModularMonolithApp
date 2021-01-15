namespace Framework.Core.BaseModels
{
    public record IdTitileDto<T> where T : struct
    {
        public T Id { get; protected set; }
        public string Title { get; protected set; }
        public string TitleEn { get; protected set;}
    }
}