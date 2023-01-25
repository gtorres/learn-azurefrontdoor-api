namespace FrontDoorAPI.Model
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public object Avatar { get;  set; }
    }
    public class UserViewModelV2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public object Avatar { get; set; }
        public object Country { get; set; }
    }
}
