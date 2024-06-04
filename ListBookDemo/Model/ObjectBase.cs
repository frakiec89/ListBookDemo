namespace ListBookDemo.DB.Model
{
    public class ObjectBase
    {

        private string _name;

        public string Name { get => _name ??"No" ; set =>_name=value; }
        public string? ImagePath { get; set; }
    }
}
